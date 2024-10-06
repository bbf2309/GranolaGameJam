using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Inventory inventory;
    public Animator animator;
    public GameObject deathSFX;
    // public ParticleSystem deathPS;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
        //  deathPS = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // If the input is moving the player right and the player is facing left...
        if (moveInput > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveInput < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y < 0f)
        {
            animator.SetBool("Descending", true);
            animator.SetBool("Ascending", false);
        }
        else
        {
            animator.SetBool("Descending", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("Ascending", false);
            animator.SetBool("Descending", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
            animator.SetBool("Ascending", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log(collision.gameObject.name + " is the player");

            inventory.keyCount++;

            //destroys attached game object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "DeathZone")
        {
            dead();
            GoToScene("WinEvent");


        }
    }

    void dead()
    {
        Instantiate(deathSFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //IEnumerator NextSceneAfterWait()
    //{
    //    yield return new WaitForSeconds(1.0f);

    //    SceneManager.LoadScene("WinEvent");


    //}
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}