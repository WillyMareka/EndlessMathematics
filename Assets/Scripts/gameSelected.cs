using UnityEngine;
using System.Collections;

public class gameSelected : MonoBehaviour {

	public static int gamestate = 0;
	public static string currentplayer;


	public void gamechoice(int game){
		if (game != 0) {
			gamestate = game;
		} else {
			Debug.LogWarning ("There is no game selected");
		}
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

	public int getGameState(){
		return gamestate;
	}


}
