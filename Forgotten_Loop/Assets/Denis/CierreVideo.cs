using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CierreVideo : MonoBehaviour
{

    public VideoPlayer Video;

    void Awake()
    {
        Video = GetComponent<VideoPlayer>();
        Video.Play();
        Video.loopPointReached += CheckOver;
    }

    public void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
