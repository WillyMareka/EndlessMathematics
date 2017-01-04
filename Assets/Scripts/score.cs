using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	private float playerScore = -7;
	private float playerExp = 0;
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

		if (Time.deltaTime > 0) {
			playerScore += Time.deltaTime * difficultyLevel;
			playerExp = playerScore * 2;
		}

		if (playerScore < 0) {
			scoreText.text = ("Get ready");
		} else {
			scoreText.text = ((int)playerScore).ToString();
		}

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
			
			if (PlayerPrefs.GetFloat (currentplayer + "_Addscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer + "_Addscore", playerScore);
			}
			playerExp += PlayerPrefs.GetFloat (currentplayer + "_Addexp");
			PlayerPrefs.SetFloat (currentplayer + "_Addexp", playerExp);

			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Addexp"));

			break;

		case 2:

			if (PlayerPrefs.GetFloat (currentplayer+"_Subtractscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer+"_Subtractscore", playerScore);
			}
			playerExp += PlayerPrefs.GetFloat (currentplayer + "_Subtractexp");
			PlayerPrefs.SetFloat (currentplayer + "_Subtractexp", playerExp);

			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Subtractexp"));

			break;

		case 3:

			if (PlayerPrefs.GetFloat (currentplayer+"_Multiplicationscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer+"_Multiplicationscore", playerScore);
			}
			playerExp += PlayerPrefs.GetFloat (currentplayer + "_Multiplicationexp");
			PlayerPrefs.SetFloat (currentplayer + "_Multiplicationexp", playerExp);

			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Multiplicationscore"));

			break;

		case 4:

			if (PlayerPrefs.GetFloat (currentplayer+"_Divisionscore") < playerScore) {
				PlayerPrefs.SetFloat (currentplayer+"_Divisionscore", playerScore);
			}
			playerExp += PlayerPrefs.GetFloat (currentplayer + "_Divisionexp");
			PlayerPrefs.SetFloat (currentplayer + "_Divisionexp", playerExp);

			DM.ToggleFailMenu (PlayerPrefs.GetFloat (currentplayer+"_Divisionscore"));

			break;

		default:

			Debug.Log ("No game selected, no scores recorded");

			break;

		}

	}
}
