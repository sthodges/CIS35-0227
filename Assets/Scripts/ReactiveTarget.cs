using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReactToHit(){
		WanderingAI behavior = GetComponent<WanderingAI> ();
		if (behavior != null) {
			behavior.wasKilled ();
		} // wanderingai?


		StartCoroutine (Die ());
	} // hit

	private IEnumerator Die(){
		this.transform.Rotate (-75.0f, 0.0f, 0.0f);
		yield return new WaitForSeconds (1.5f);
		Destroy (this.gameObject);
	} // die

}
