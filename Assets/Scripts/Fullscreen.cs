using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour {

    private RawImage image;

	// Use this for initialization
	void Awake () {

        image = transform.GetChild(1).GetComponent<RawImage>();
	}

    public void Close () {

    }

    public void Open() {

    }
}
