﻿using System.Collections;
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
			inputTap.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
			inputSwipe.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		}

		musictype = GS.getMusic ();
		if (musictype == 2) {
			musicOn.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
			musicOff.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);

		} else if(musictype == 1) {
			musicOn.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
			musicOff.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		}

		soundtype = GS.getSound ();
		if (soundtype == 2) {
			soundOn.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
			soundOff.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);

		} else if(soundtype == 1) {
			soundOn.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
			soundOff.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
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

	public void MusicOff(){
		musicOn.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		musicOff.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		GS.setMusic (2);
	}

	public void MusicOn(){
		musicOn.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		musicOff.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		GS.setMusic (1);
	}

	public void SoundOff(){
		soundOn.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		soundOff.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		GS.setSound (2);
	}

	public void SoundOn(){
		soundOn.GetComponent<Image> ().color = new Color (148f/255f,255f/255f,162f/255f);
		soundOff.GetComponent<Image> ().color = new Color (255f/255f,109f/255f,109f/255f);
		GS.setSound (1);
	}

}
