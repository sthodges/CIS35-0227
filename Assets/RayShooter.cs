using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
	private Camera _camera;



	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}

	void OnGUI(){
		int size = 18;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		GUI.Label (new Rect (posX, posY, size, size), "+");
	} //gui


	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3 (_camera.pixelWidth / 2.0f, _camera.pixelHeight / 2.0f, 0.0f);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				//Debug.Log("Hit " + hit.point);
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
				if (target != null) {
					//Debug.Log("Hit Enemy");
					target.ReactToHit();
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}
			} // hit
		} // mouseDown
	}
	private IEnumerator SphereIndicator(Vector3 Pos){
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = Pos;
		yield return new WaitForSeconds (1.0f);
		Destroy (sphere);
	} // sphere
}


