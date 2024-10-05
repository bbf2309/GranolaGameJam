using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
public class Timer : MonoBehaviour
{
    private float timeDuration = 3f * 60; //3 minutes multipled by 60 since everything is in seconds
    private float timer;

    [SerializeField] //shows up in the editor/inspector
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI seperator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    private float flashTimer;
    private float flashDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; //every frame/update will subtract the elapsed time
            UpdateTimerDisplay(timer);
        }
        else
        {
            Flash();
        }

    }

    private void ResetTimer()
    {
        timer = timeDuration;
    }

    /// <summary>
    /// Displays the time
    /// </summary>
    /// <param name="time"></param>
    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60); //rounds value down
        float seconds = Mathf.FloorToInt(time % 60); //gets what is leftover after dividing by 60

        //format how time is applied to the string
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if (timer != 0) //prevents timer from dropping below zero
        {
            timer = 0;
            UpdateTimerDisplay(timer);
        }

        if (flashTimer <= 0)
        {
            flashTimer = flashDuration;
        }
        else if (flashTimer >= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        seperator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }
}

