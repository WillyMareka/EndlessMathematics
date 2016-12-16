using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class homeMenu : MonoBehaviour {

	//General Options
	private gameSelected GS;

	void Start(){
		Time.timeScale = 1;
		GS = GetComponent<gameSelected> ();
	}

	public void ToHomeMenu(){
		SceneManager.LoadScene ("HomeMenu");
	}

	void Update(){
		if(Input.GetKey (KeyCode.Escape)){
			Scene cscene = SceneManager.GetActiveScene ();
			if (cscene.name != "HomeMenu") {
				SceneManager.LoadScene ("HomeMenu");
			}
		}
	}

	//General Options

	//Home Menu Options

	public void ToGame(){
		SceneManager.LoadScene ("GameSelect");
	}

	public void ToScores(){
		SceneManager.LoadScene ("HighScores");
	}

	public void ToAchievements(){
		SceneManager.LoadScene ("Achievements");
	}

	public void ToCredits(){
		SceneManager.LoadScene ("Credits");
	}

	public void QuitGame(){
		Application.Quit();
	}

	//Home Menu Options

	//Game Select Options

	public void AdditionGame(){
		GS.gamechoice(1);
		SceneManager.LoadScene ("testlevel");
	}

	public void SubstractionGame(){
		GS.gamechoice(2);
		SceneManager.LoadScene ("testlevel");
	}

	public void MultiplicationGame(){
		GS.gamechoice(3);
		SceneManager.LoadScene ("testlevel");
	}

	public void DivisionGame(){
		GS.gamechoice(4);
		SceneManager.LoadScene ("testlevel");
	}

}
