using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    private Vector3 mousePosition;
    private BoxCollider2D boxCollider;
    public bool onTarget;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        Cursor.visible = false;
        onTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y, +8));
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kid"))
        {
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
        if (onTarget)
        {
            target.GetComponent<KidController>().Reset();
        }
    }
}
