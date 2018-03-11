using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float speed = 5.0f;

    private GameObject infoWin;

	// Use this for initialization
	void Start () {

        infoWin = GameObject.Find("infoWin");
	}
	
	// Update is called once per frame
	void Update () {

	}

	// LateUpdate is called after all Updates
	void LateUpdate() {
		
		if (target && !infoWin.activeInHierarchy) {

			if (Input.GetMouseButton(2)) {

				transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
				transform.RotateAround(target.transform.position, Vector3.right, Input.GetAxis("Mouse Y") * speed);
			}

			transform.LookAt(target, target.transform.up);
		}
	}
}
