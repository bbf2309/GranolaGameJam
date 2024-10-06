using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FogContoller : MonoBehaviour
{
    public GameObject GO1;
    public GameObject GO2;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GO1.transform.position;
        transform.DOMove(GO2.transform.position, 20);
        Invoke("MoveAgain", 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveAgain()
    {
        float yVal = Random.Range(-6f, 0f);
        GO1.transform.position = new Vector3 (GO1.transform.position.x, yVal, GO1.transform.position.z);
        GO2.transform.position = new Vector3 (GO2.transform.position.x, yVal, GO2.transform.position.z);

        transform.position = GO1.transform.position;
        transform.DOMove(GO2.transform.position, 20);
        Invoke("MoveAgain", 20);
    }
}
