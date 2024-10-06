using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*
 * Reticle.CS
 * Created by Ben Fox
 * for Granola.GG x RIT IGM Game Jam
 * 
 */
public class Reticle : MonoBehaviour
{
    private Vector3 mousePosition;
    private BoxCollider2D boxCollider;
    public bool onTarget;
    public GameObject target;
    private AudioSource SFX;
    public DrawLine line;
    public GameManager GM;
    public float reload;
    private float lastShootTime;
    private bool readyToFire;

    // Start is called before the first frame update
    void Start()
    {
        readyToFire = true;
        SFX = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        Cursor.visible = false;
        onTarget = false;
        lastShootTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        if (readyToFire) transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, +10));

        if (Input.GetMouseButtonDown(0) && (Time.time > lastShootTime + reload))
        {
            line.Blast();
            readyToFire = false;
            Invoke("MakeReadyToFire", reload);
            Shoot();
            lastShootTime = Time.time; 
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

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kid"))
        {
            onTarget = false;
            target = null;
        }
    }


    void Shoot()
    {
        SFX.pitch = Random.Range(1f,3f);
        SFX.Play();
        
        if (onTarget)
        {
            KidController controller = target.GetComponent<KidController>();
            controller.wasShot = true;
            controller.Reset();
            GM.score += controller.points;
        }
    }

    void MakeReadyToFire()
    {
        readyToFire = true;
    }
}
