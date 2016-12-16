using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	private float playerScore = -7;
	private int difficultyLevel = 1;
	private int maxDifficulty = 3;
	private int scoreToNextLevel = 50;

	private bool isWrong = false;
	private playerMotor PM;

	public deathMenu DM;
	public Text scoreText;

	string currentplayer;

	void Start ()   {
		currentplayer = PlayerPrefs.GetString("CurrentPlayer");
		PM = GetComponent<playerMotor> ();
	}

	void Update () {


		if (isWrong) {
			return;
		}

		if(playerScore >= scoreToNextLevel){
			LevelUp ();
		}

		playerScore += Time.deltaTime * difficultyLevel;
		scoreText.text = ((int)playerScore).ToString();
	}

	public void LevelUp(){

		if (difficultyLevel == maxDifficulty) {
			return;
		}

		scoreToNextLevel *= 3;
		difficultyLevel++;

		PM.SetSpeed (difficultyLevel); 
	}

	public void SetIsWrong(){
		isWrong = false;
	}

	public void OnWrongAnswer (int gametype){
		isWrong = true;

		switch (gametype) {
		case 1:
			
			if (PlayerPrefs.GetFloat (currentplayer+"_Addscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer+"_Addscore", playerScore);
			}
			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Addscore"));

			break;

		case 2:

			if (PlayerPrefs.GetFloat (currentplayer+"_Subtractscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer+"_Subtractscore", playerScore);
			}
			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Subtractscore"));

			break;

		case 3:

			if (PlayerPrefs.GetFloat (currentplayer+"_Multiplicationscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer+"_Multiplicationscore", playerScore);
			}
			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Multiplicationscore"));

			break;

		case 4:

			if (PlayerPrefs.GetFloat (currentplayer+"_Divisionscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer+"_Divisionscore", playerScore);
			}
			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Divisionscore"));

			break;

		default:

			Debug.Log ("No game selected, no scores recorded");

			break;

		}

	}
}
