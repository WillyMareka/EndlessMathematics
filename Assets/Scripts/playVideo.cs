using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playVideo : MonoBehaviour {

//	public MovieTexture gameIntro;
//	private AudioSource audioIntro;



	// Use this for initialization
	void Start () {
		Handheld.PlayFullScreenMovie ("gameIntro.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput,FullScreenMovieScalingMode.AspectFill);

		SceneManager.LoadScene ("HomeMenu");




//		GetComponent<RawImage> ().texture = gameIntro as MovieTexture;
//		gameIntro.Play ();
//
//		audioIntro = GetComponent<AudioSource> ();
//		audioIntro.clip = gameIntro.audioClip;
//		audioIntro.Play ();
	}

//	void Update () {
////		if (Input.anyKeyDown && gameIntro.isPlaying) {
////			SceneManager.LoadScene ("HomeMenu");
////		}
//
//		if (gameIntro.isPlaying == false) {
//			
//		}
//	}


}
