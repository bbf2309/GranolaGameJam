using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer LR;
    public GameObject GO1;
    public GameObject GO2;

    public float laserTime;

    // Start is called before the first frame update
    void Start()
    {
        LR.positionCount = 2;

        LR.SetPosition(0, GO1.transform.position);
        LR.SetPosition(1, GO2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        LR.SetPosition(0, GO1.transform.position);
        LR.SetPosition(1, GO2.transform.position);
    }

    public void Blast()
    {
        LR.gameObject.transform.position = new Vector3(LR.gameObject.transform.position.x, LR.gameObject.transform.position.y, 0);
        Invoke("HideLaser", laserTime);
    }
    public void HideLaser()
    {
        LR.gameObject.transform.position = new Vector3(LR.gameObject.transform.position.x, LR.gameObject.transform.position.y, 1);
    }
}
