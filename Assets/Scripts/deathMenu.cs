using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class deathMenu : MonoBehaviour {

	public Image backgroundImg;
	public Text currentScore;

	private bool isShown = false; 
	//private bool changeWrong = false;
	private float transition = 0.0f;

	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShown) {
			return;
		}

		transition += Time.deltaTime;
		backgroundImg.color = Color.Lerp (new Color (0,0,0,0), new Color (0,0,0,1), transition);
	}

	public void ToggleFailMenu(float score){
		currentScore.text = "Current High Score : " + ((int)score);
		gameObject.SetActive (true);
		isShown = true;
	}

	public void Restart(){
		SceneManager.LoadScene ("testlevel");
	}

	public void ToMenu(){
		SceneManager.LoadScene ("HomeMenu");
	}
}
