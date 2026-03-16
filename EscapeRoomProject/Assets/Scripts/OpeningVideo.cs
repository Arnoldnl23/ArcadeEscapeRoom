using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class OpeningVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float delay = 5f;

    IEnumerator Start()
    {
        videoPlayer.Stop();      // make sure it doesn't auto play
        yield return new WaitForSeconds(delay);
        videoPlayer.Play();
    }
}