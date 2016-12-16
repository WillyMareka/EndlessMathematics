using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerChosen : MonoBehaviour {

	public Material[] material;

	Renderer rend;

	void Start () {

		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = material[0];
	}
	
	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player") {
			if (gameObject.tag == "Right") {
				rend.sharedMaterial = material [1];
			} else if (gameObject.tag == "Wrong") {
				rend.sharedMaterial = material [2];
			} else {
				rend.sharedMaterial = material [0];
				Debug.Log ("Game Object not assigned a tag");
			}
		}
	}

}
