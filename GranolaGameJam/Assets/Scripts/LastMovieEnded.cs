using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class LastMovieEnded : MonoBehaviour
{
    public VideoPlayer video;

    // Plays video then references end video method 
    void Awake()
    {
        video.Play();
        video.loopPointReached += CheckOver;
    }

    /// <summary>
    /// Load level selector scene once cutscene finishes 
    /// </summary>
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Menu Scene");
    }
}
