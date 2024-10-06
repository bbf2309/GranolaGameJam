using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
