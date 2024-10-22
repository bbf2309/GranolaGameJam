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
        LR.SetPosition(0, new Vector3 (GO1.transform.position.x, GO1.transform.position.y, 0));
        LR.SetPosition(1, new Vector3 (GO2.transform.position.x, GO2.transform.position.y, 0));
    }

    public void Blast()
    {
        LR.sortingOrder = 2;
        Invoke("HideLaser", laserTime);
    }
    public void HideLaser()
    {
        LR.sortingOrder = -2;
    }
}
