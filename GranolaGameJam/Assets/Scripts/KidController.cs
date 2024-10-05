using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KidController : MonoBehaviour
{
    [Header("Kid Variables")]
    public float points;
    [Tooltip("speed is time in seconds it takes for kid to become fully exposed")]
    public float speed;
    public float timeExposed;
    public Transform spawnPoint;
    public Transform finalPoint;
    
    [Header("Attributes")]
    public bool wasPwned;
    public bool isWaitingOrMoving;
    public int waitTime;
    public int currentTime;

  

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
        if(!wasPwned) JumpOut(); 

        /*if (wasPwned)
        {
            Reset();
            StopAllCoroutines();
        }
        else if(!isWaitingOrMoving)
        {
            StartCoroutine(Wait());
        }*/

    }
/*
 * Method: JumpOut
 * Purpose: Bring kid to finalPoint, stay there for timeExposed, then invoke retreat
 * No parameters or returns
 */
    public void JumpOut()
    {
        wasPwned= true;
        Vector3.Lerp(spawnPoint.position, finalPoint.position, speed);
        Invoke("PrepRetreat", speed);
    }

 /*
 * Method: Retreat
 * Purpose: Bring kid back to spawnpoint if it isnt already there
 * No parameters or returns
 */
    public void PrepRetreat()
    {
        Invoke("Retreat", timeExposed);
    }

    public void Retreat()
    {
        if (gameObject.transform.position != spawnPoint.position) Vector3.Lerp(finalPoint.position, spawnPoint.position, speed);
        wasPwned = false;
    }

    public void Reset()
    {
        gameObject.transform.position = spawnPoint.position;
        waitTime = (int)Random.Range(3f, 10f);
        isWaitingOrMoving = false;
    }

/*
 * Method: WaitTime
 * Purpose: Wait for waitTime seconds 
 */
    IEnumerator Wait()
    {
        isWaitingOrMoving = true;
        if (currentTime < waitTime)
        {
            currentTime++;
            yield return new WaitForSeconds(1f);
        }
        else
        {
            JumpOut();
            StopCoroutine(Wait());
        }
    }
}
