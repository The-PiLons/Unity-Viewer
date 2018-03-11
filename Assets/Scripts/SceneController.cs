using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {


	public List<Button> expanable = new List<Button>();

	private Camera cam;
	private GameObject infoWin;
	private Transform target;
	private List<Vector3> initPos = new List<Vector3>();

	public struct FullScreened {

		public Vector3 initPos, initScale;
		public bool open;
		public Button item;

		public FullScreened(Vector3 _initPos, Vector3 _initScale, bool _open, Button _item) {

			initPos = _initPos;
			initScale = _initScale;
			open = _open;
			item = _item;
		}
	}

    public struct Parts {

        public Transform pos, initPos;

        public Parts(Transform _pos, Transform _initPos) {

            pos = _pos;
            initPos = _initPos;
        }
    }

    public FullScreened fullScreenItem;

	// Use this for initialization
	void Start () {

		cam = Camera.main;
        infoWin = GameObject.Find("infoWin");
		Transform robot = cam.GetComponent<CameraController>().target;

		for (int i = 0; i < robot.childCount; i++) initPos.Add(robot.GetChild(i).transform.position);

		infoWin.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (infoWin.activeInHierarchy) {

			if (Input.GetKeyUp(KeyCode.Escape)) {

				if (fullScreenItem.open) ToggleSlideShow(fullScreenItem.item);
				else infoWin.SetActive(!infoWin.gameObject.activeInHierarchy);
			}
		}

		else {

			if (Input.GetMouseButtonDown(0)) {

				RaycastHit hit;
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit)) {

					Debug.DrawLine(cam.transform.position, hit.point, Color.red);
					Debug.Log(hit.transform.parent.name);

                    if (hit.transform.parent.transform.tag == "Subsection") target = hit.transform.parent.transform;
				}
			}

			if (target) {

				if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftAlt)) target.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4.0f));
				else if (Input.GetMouseButtonDown(0)) openInfoWin(target.name);
				else target = null;
			}
		}
	}

	private void openInfoWin(string name) {

		Text Title = infoWin.transform.GetChild(1).GetComponent<Text>();
		Title.text = name;

		infoWin.SetActive(!infoWin.gameObject.activeInHierarchy);
	}

	public void Reset() {

		Transform robot = cam.GetComponent<CameraController>().target;

		for (int i = 0; i < robot.childCount; i++) robot.GetChild(i).transform.position = initPos[i];

		infoWin.SetActive(false);
	}

    public void Explode() {

        GameObject r = GameObject.Find("Robot");
        List<Transform> parts = new List<Transform>();

        for (short i = 0; i < r.transform.childCount; i++) parts.Add(r.transform.GetChild(i));

        float pos = -1.5f;
        foreach (var item in parts) {

            item.position = new Vector3(pos, 0, 0.0f);
            pos += 2.0f;
        }
    }

	public void ToggleSlideShow(Button item) {

		if (!fullScreenItem.open) {

			fullScreenItem = new FullScreened(item.transform.localPosition, item.transform.localScale, true, item);

			item.transform.localPosition = new Vector3(0.0f, 0.0f, 1.0f);
			item.transform.localScale = new Vector3(3.5f, 3.5f, 1.0f);

			Debug.Log(item.name);
		}

		else {

			item.transform.localPosition = fullScreenItem.initPos;
			item.transform.localScale = fullScreenItem.initScale;
			fullScreenItem.open = false;
		}
	}
}
