using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class keyPressMenu : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			SceneManager.LoadScene ("HomeMenu");
		}
	}
}
