using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameSelected : MonoBehaviour {

	public static int gamestate = 0;
	public static string currentplayer;
	public static int characterinput = 0;


	public void gamechoice(int game){
		if (game != 0) {
			gamestate = game;
		} else {
			Debug.LogWarning ("There is no game selected");
		}
	}

	public void ToHomeMenu(){
		SceneManager.LoadScene ("HomeMenu");
	}

	public void setCurrentPlayer(string name){
		
		if (currentplayer == "") {
			currentplayer = "empty slot";
		} else {
			currentplayer = name;
		}
		//Debug.Log (currentplayer);
		PlayerPrefs.SetString ("FirstPlayer", "false");
		PlayerPrefs.SetString ("CurrentPlayer", currentplayer);

	}

	public string getCurrentPlayer(){
		currentplayer = PlayerPrefs.GetString ("CurrentPlayer");
		return currentplayer;
	}

	public int getCharacterInput(){
		characterinput = PlayerPrefs.GetInt ("CharacterInput");

		if (characterinput == null) {
			characterinput = 0;
		}

		return characterinput;
	}

	public void setCharacterInput(int cinput){
		if (cinput == null) {
			characterinput = 0;
		} else {
			characterinput = cinput;
		}
		PlayerPrefs.SetInt ("CharacterInput", characterinput);
	}

	public int getGameState(){
		return gamestate;
	}

	public void AdditionGame(){
		gamechoice(1);
		SceneManager.LoadScene ("testlevel");
	}

	public void SubstractionGame(){
		gamechoice(2);
		SceneManager.LoadScene ("testlevel");
	}

	public void MultiplicationGame(){
		gamechoice(3);
		SceneManager.LoadScene ("testlevel");
	}

	public void DivisionGame(){
		gamechoice(4);
		SceneManager.LoadScene ("testlevel");
	}


}
