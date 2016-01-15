using UnityEngine;
using System.Collections;

public class VideoPlayer : MonoBehaviour
{
    string url = "http://www.unity3d.com/webplayers/Movie/sample.ogg";

    GUITexture gt;

    IEnumerator Start()
    {
        WWW webstie = new WWW(url);

        var movieTexture = webstie.movie;

        while (!movieTexture.isReadyToPlay)
            yield return null;

        gt = GetComponent<GUITexture>();

        gt.texture = movieTexture;

        transform.localScale = Vector3.zero;
        transform.position =  new Vector3(1f, -.5f, 0);
        gt.pixelInset = new Rect(-movieTexture.width, movieTexture.width,
            -movieTexture.height, movieTexture.height);

        var aud = GetComponent<AudioSource>();
        aud.clip = movieTexture.audioClip;

        movieTexture.Play();
        aud.Play();
    }
}
