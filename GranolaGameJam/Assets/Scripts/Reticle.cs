using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    private Vector3 mousePosition;
    private BoxCollider2D boxCollider;
    public bool onTarget;
    public GameObject target;
    private AudioSource SFX;
    public DrawLine line;
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        SFX = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        Cursor.visible = false;
        onTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y, +10));
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Kid"))
        {
            Debug.LogWarning("OnTarget!");
            onTarget = true;
            target = collision.gameObject; 
        }
        else
        {
            onTarget = false;
            target = null;
        }

    }


    void Shoot()
    {
        SFX.pitch = Random.Range(1f,3f);
        SFX.Play();
        line.Blast();
        if (onTarget)
        {
            KidController controller = target.GetComponent<KidController>();
            controller.wasShot = true;
            controller.Reset();
            GM.score += controller.points;
        }
    }
}
