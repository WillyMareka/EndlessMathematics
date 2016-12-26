using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class optionsManager : MonoBehaviour {

	public Button inputTap, inputSwipe;
	public Button musicOn, musicOff;
	public Button soundOn, soundOff;

	int inputtype,musictype,soundtype;

	bool changedinput;

	private gameSelected GS;

	void Start () {
		GS = GetComponent<gameSelected> ();

		inputtype = GS.getCharacterInput ();
		if (inputtype == 0) {
			inputTap.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
			inputSwipe.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		} else if(inputtype == 1) {
			inputSwipe.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
			inputTap.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		}
	}

	public void InputToTap(){
		inputTap.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		inputSwipe.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		GS.setCharacterInput (0);
	}

	public void InputToSwipe(){
		inputTap.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		inputSwipe.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		GS.setCharacterInput (1);
	}


	public void MusicOn(){
		musicOn.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		musicOff.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		GS.setMusic (0);
	}

	public void MusicOff(){
		musicOn.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		musicOff.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		GS.setMusic (1);
	}


	public void SoundOn(){
		soundOn.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		soundOff.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		GS.setSound (0);
	}

	public void SoundOff(){
		soundOn.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		soundOff.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		GS.setSound (1);
	}



}
