using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using UnityEngine.UIElements;

public class KidController : MonoBehaviour
{
    [Header("Kid Variables")]
    public float points;
    [Tooltip("moveTime is time in seconds it takes for kid to become fully exposed")]
    public float moveTime;
    public float timeExposed;
    public Transform spawnPoint;
    public Transform finalPoint;
    
    [Header("Attributes")]
    public bool wasPwned;
    public bool isWaitingOrMoving;
    public int waitTime;

  

    // Start is called before the first frame update
    void Start()
    {
        waitTime = (int)Random.Range(3f, 10f);
        wasPwned = false;
        isWaitingOrMoving = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isWaitingOrMoving)
        {
            JumpOut();
        }

        if (wasPwned)
        {
            Reset();
        }


    }
/*
 * Method: JumpOut
 * Purpose: Bring kid to finalPoint, stay there for timeExposed, then invoke retreat
 * No parameters or returns
 */
    public void JumpOut()
    {
        isWaitingOrMoving = true;
        transform.DOMove(finalPoint.position, moveTime);
        Invoke("PrepRetreat", moveTime);
    }

/* Method: PrepRetreat
* Purpose: Call retreat after timeExposed secondss
* No parameters or returns
*/
    public void PrepRetreat()
    {
        Invoke("Retreat", timeExposed);
    }
/*
* Method: Retreat
* Purpose: Bring kid back to spawnpoint if it isnt already there
* No parameters or returns
*/
    public void Retreat()
    {
        if (gameObject.transform.position != spawnPoint.position) transform.DOMove(spawnPoint.position, moveTime);
        Invoke("StopMoving", moveTime);

    }
/*
 * Method: StopMoving
 * Purpose: Snap kid to starting position and wait for next peek
 * No parameters or returns
 */

    public void StopMoving()
    {
        gameObject.transform.position = spawnPoint.position;
        isWaitingOrMoving = false;
    }

 /*
 * Method: Reset
 * Purpose: Snap kid to starting position after being shot and wait for next peek
 * No parameters or returns
 */
    public void Reset()
    {
        gameObject.transform.position = spawnPoint.position;
        waitTime = (int)Random.Range(3f, 10f);
        Invoke("JumpOut", waitTime);
        isWaitingOrMoving = false;
        wasPwned = false;
    }
}
