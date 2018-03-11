using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour { 

    // Custom serializable class
    [Serializable]
    public class Slide {

        public string name;
        public Texture image;
    }

    public List<Slide> Slides = new List<Slide>();
    public float timer = 1.0f;

    private int curSlide = -1;
    private float lastTime = 0.0f;

	// Use this for initialization
	void Start () {

        nextSlide();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (timer > 0 && Slides.Count > 0) {

            if (lastTime >= timer) {

                nextSlide();
                lastTime = 0;
            }
            lastTime += Time.deltaTime;
        }
	}

    private void nextSlide() {

        if (++curSlide >= Slides.Count) curSlide = 0;

        gameObject.GetComponent<RawImage>().texture = Slides[curSlide].image;
    }
}
