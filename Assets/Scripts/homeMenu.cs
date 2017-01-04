using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class homeMenu : MonoBehaviour {

	public Image nameChanger;
	private gameSelected GS;
	private bool nameCanChange = false;
	GameObject imgname;
	Scene cscene;

	void Start(){
		Time.timeScale = 1;
		GS = GetComponent<gameSelected> ();

		if (cscene.name == "HomeMenu") {
			nameChanger.gameObject.SetActive (nameCanChange);
		}
	}

	public void ToHomeMenu(){
		SceneManager.LoadScene ("HomeMenu");
	}

	void Update(){
		
		if(Input.GetKey (KeyCode.Escape)){
			cscene = SceneManager.GetActiveScene ();
			if (cscene.name != "HomeMenu") {
				SceneManager.LoadScene ("HomeMenu");
			}
		}

		GameObject imgname = GameObject.Find ("changeplayerpanel/Image/currentPlayer");

		if(imgname){
			
			Text currentname = imgname.GetComponent<Text> ();

			if (GS.getCurrentPlayer () == "" || GS.getCurrentPlayer () == "Add Player" || GS.getCurrentPlayer () == "empty slot") {
				currentname.text = "Create a new player name...";
			} else {
				currentname.text = "Current Player : " + GS.getCurrentPlayer();
			}
		}
	}

	public void ToGame(){
		SceneManager.LoadScene ("GameSelect");
	}

	public void ToScores(){
		SceneManager.LoadScene ("HighScores");
	}

	public void ToAchievements(){
		SceneManager.LoadScene ("Achievements");
	}

	public void ToOptions(){
		SceneManager.LoadScene ("Options");
	}

	public void ToCredits(){
		SceneManager.LoadScene ("Credits");
	}

	public void QuitGame(){
		Application.Quit();
	}
		

	public void changeNameEnable(){
		nameCanChange = !nameCanChange;

		if(nameCanChange){
			nameChanger.gameObject.SetActive (true);

		}else{
			nameChanger.gameObject.SetActive (false);
		}
	}

}
