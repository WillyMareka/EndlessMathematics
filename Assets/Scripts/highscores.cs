using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highscores : MonoBehaviour {

	public Text addscore, subtractscore, multiplyscore, dividescore;
	public Text addexp, subtractexp, multiplytexp, divideexp;
	public Text playerLevel;

	int addexperience, subtractexperience, multiplyexperience, divideexperience, updateNextLevel, level = 0;
	float playerlevel;
	int toNextPlayerLevel = 250;
	string currentplayer;

	private gameSelected GS;

	// Use this for initialization
	void Start () {
		currentplayer = PlayerPrefs.GetString("CurrentPlayer");
		GS = GetComponent<gameSelected> ();

		addscore.text = "Highscore : " + ((int)PlayerPrefs.GetFloat (currentplayer+"_Addscore"));
		subtractscore.text = "Highscore : " + ((int)PlayerPrefs.GetFloat (currentplayer+"_Subtractscore"));
		multiplyscore.text = "Highscore : " + ((int)PlayerPrefs.GetFloat (currentplayer+"_Multiplicationscore"));
		dividescore.text = "Highscore : " + ((int)PlayerPrefs.GetFloat (currentplayer+"_Divisionscore"));

		addexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Addexp"));
		subtractexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Subtractexp"));
		multiplyexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Multiplyexp"));
		divideexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Divideexp"));

		playerlevel = PlayerPrefs.GetFloat (currentplayer+"_PlayerLevel");

		addexp.text = "Experience : " + addexperience;
		subtractexp.text = "Experience : " + subtractexperience;
		multiplytexp.text = "Experience : " + multiplyexperience;
		divideexp.text = "Experience : " + divideexperience;

		setLevel ();

		if(GS.getMusic() == 0){
			GameObject gomusic = GameObject.Find ("HomeMusic");
			Destroy (gomusic, 0);
		}
	}

	void setLevel(){
		
		updateNextLevel = ((int)PlayerPrefs.GetFloat (currentplayer+"_NextLevelUp"));

		if(toNextPlayerLevel > updateNextLevel){
			updateNextLevel = toNextPlayerLevel;
		}

		level = ((addexperience + subtractexperience + multiplyexperience + divideexperience) / 4);

		if(level >= updateNextLevel){
			playerlevel++;
			updateNextLevel *= 2;
			PlayerPrefs.SetFloat (currentplayer+"_PlayerLevel", playerlevel);
			PlayerPrefs.SetFloat (currentplayer+"_NextLevelUp", updateNextLevel);
		}

		//Assigning the player Level text
		GetPlayer ();

	}

	public void GetPlayer(){
		if(playerlevel <= 1){
			if (currentplayer == "") {
				playerLevel.text = "Player's Level : 1";
			}else{
				playerLevel.text = currentplayer + "'s Level : 1";
			}
		}else{
			playerLevel.text = currentplayer + "'s Level : " + ((int)playerlevel);
		}
	}

}
