using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerChosen : MonoBehaviour {

	public Material[] material;
	public GameObject go;

	Renderer rend;

	void Start () {
		go.SetActive (false);
		rend = GetComponent<Renderer> ();
		rend.enabled = false;
		rend.sharedMaterial = material[0];
		Invoke ("ChoiceAppear", 0.5f);
	}

	void ChoiceAppear(){
		go.SetActive (true);
		rend.enabled = true;
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
