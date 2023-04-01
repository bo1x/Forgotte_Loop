using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CierreVideo : MonoBehaviour
{

    public VideoPlayer Video;

    void Awake()
    {
        Video = GetComponent<VideoPlayer>();
        Video.Play();
        Video.loopPointReached += CheckOver;
    }

    void CheckOver(VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }
}
