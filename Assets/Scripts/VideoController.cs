using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public MovieTexture video;

    private RawImage playerHolder;
    private MovieTexture player;

	// Use this for initialization
	void Awake () {

        if (!video) Debug.LogWarning("Please Enter a Video Source");

        playerHolder = gameObject.transform.GetChild(0).GetComponent<RawImage>();
        playerHolder.texture = video;

        player = playerHolder.mainTexture as MovieTexture;
        if (video) player.loop = true;
    }

    public void Play() {

        if (video) {

            if (player.isPlaying) player.Pause();
            else player.Play();
        }
    }
}
