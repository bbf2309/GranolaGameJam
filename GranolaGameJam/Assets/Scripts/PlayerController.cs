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

    private Inventory inventory;

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

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
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
}