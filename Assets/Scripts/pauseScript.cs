using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour {

	private bool isPaused;

	public Image pauseImage;
	public Text pausetext;

	// Use this for initialization
	void Start () {
		isPaused = false;
		pausetext.text = "Pause";
		gameObject.SetActive (false);
	}

	public void PauseGame(){
		isPaused = !isPaused;

		if (isPaused) {
			Time.timeScale = 0;
			gameObject.SetActive (true);
			pausetext.text = "Continue";
		}else if(!isPaused){
			Time.timeScale = 1;
			gameObject.SetActive (false);
			pausetext.text = "Pause";
		}
	}

}
