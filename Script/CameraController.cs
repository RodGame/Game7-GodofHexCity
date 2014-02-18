using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameObject root;

	// Use this for initialization
	void Start () {
		root = GameObject.FindGameObjectWithTag("Root");
	}
	
	// Update is called once per frame
	void Update () {

		float mouseWheelRatio = 0.5f;
		float mouseMoveRatio = 0.05f;

		float mouseX;
		float mouseY;
		float mouseWheelInput = Input.GetAxis ("Mouse ScrollWheel")*mouseWheelRatio;

		if( mouseWheelInput != 0.0f)
		{
			Debug.Log ("Scroll");
			Camera.main.gameObject.GetComponent<Camera>().orthographicSize -= mouseWheelInput ;
		}


		if(Input.GetMouseButton (0))
		{
			mouseX = Input.GetAxis("Mouse X")*mouseMoveRatio;
			mouseY = Input.GetAxis("Mouse Y")*mouseMoveRatio;
			Vector3 rootMovement = new Vector3(mouseX, mouseY, 0.0f);
			root.transform.position += rootMovement;
		}



	}
}
