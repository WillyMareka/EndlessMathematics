using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMotor : MonoBehaviour {

	private float lane;
	private CharacterController controller;
	private Vector3 moveVector;
	private float animationDuration = 7.0f; 
	private bool isWrong = false;
	private float startTime;
	private float experience = 5;
	private bool checkTip = true;
	private int exp = 0, characterinput, gametype = 0, canProduceSound;
	private bool isPaused = false;
	private float minimumSwipeDistanceX = 200;
	private string currentplayer;
	private Touch t = default(Touch);
	private Vector3 startPosition = Vector3.zero;
	private AudioSource audioSource;

	public Image imageTip;
	public float speed = 5.0f;
	public GameObject GS,MG,PS,controllers;
	public AudioClip correctSound, incorrectSound;
	//public Text errorFinder;




	void Start () {
		gametype = GS.GetComponent<gameSelected> ().getGameState();
		currentplayer = GS.GetComponent<gameSelected> ().getCurrentPlayer();
		characterinput = GS.GetComponent<gameSelected> ().getCharacterInput();
		canProduceSound = GS.GetComponent<gameSelected> ().getSound ();
		controllers.SetActive (false);

		controller = GetComponent<CharacterController>();
		audioSource = GetComponent<AudioSource> ();

		moveVector = Vector3.zero;
		lane = 0;
		Time.timeScale = 1;
		startTime = Time.deltaTime;

	}
	

	void Update () {
		
		if (isWrong) {
			return;
		} else {
			if(Input.GetKeyDown (KeyCode.Escape)){
				if (isPaused == false) {
					PS.GetComponent<pauseScript> ().PauseGame ();
					isPaused = true;
				} else {
					PS.GetComponent<pauseScript> ().PauseGame ();
					isPaused = false;
				}
			}
		}

		if(GameObject.Find("Canvas/ImageTip") != null){
			if ((Input.anyKeyDown) || Time.time >= 7) {
				RemoveTip ();
			}
		}
			
		controller.Move ((Vector3.forward * speed) * Time.deltaTime);


		if (Time.time - startTime < animationDuration) {
			return;
		}

		switch(characterinput){
		case 0:
			controllers.SetActive (true);

			if (Input.GetKeyDown (KeyCode.D)) {
				if (lane < 3.0f) {
					lane += 3.0f;
				}
			} else if (Input.GetKeyDown (KeyCode.A)) {
				if (lane > -3.0f) {
					lane -= 3.0f;
				}
			}

			if (Input.GetMouseButtonDown (0)) {
				if (Input.mousePosition.y > Screen.height / 3.5) {
					if (Input.mousePosition.x > Screen.width / 2) {
						if (lane < 3.0f) {
							lane += 3.0f;
						}
					} else {
						if (lane > -3.0f) {
							lane -= 3.0f;
						}
					}
				}			
			}
				
			break;

		case 1:
			
			if (Input.touchCount > 0 ){
				t = Input.touches[0];

				switch (t.phase) {

				case TouchPhase.Began:
					startPosition = t.position;
					return;

				case TouchPhase.Ended:
					Vector3 positionDelta = (Vector3)t.position - startPosition;

					if (Mathf.Abs (positionDelta.x) > minimumSwipeDistanceX) {
						if (positionDelta.x > 0) {
							if (lane < 3.0f) {
								lane += 3.0f;
							}
						} else {
							if (lane > -3.0f) {
								lane -= 3.0f;
							}
						}
					}

					return;

				default:
					Debug.Log ("Swipper no swipping...");
					return;
				}
			}

			break;

		default:
			Debug.Log ("No input has been selected");
			break;
		}
			
		moveVector = transform.position;
		moveVector.x = lane;
		transform.position = moveVector;

	}

	public void SetSpeed(float newspeed){
		speed = 5.0f + newspeed;
		experience += 5.0f;
	}
		
	void RemoveTip(){
		if (checkTip == true) {
			
			imageTip.gameObject.SetActive(false);
			checkTip = false;
		}

		switch (gametype) {
		case 1:
			MG.GetComponent<mathGame> ().AdditionTiles ();
			break;

		case 2:
			MG.GetComponent<mathGame> ().SubtractionTiles ();
			break;

		case 3:
			MG.GetComponent<mathGame> ().MultiplicationTiles ();
			break;

		case 4:
			MG.GetComponent<mathGame> ().DivisionTiles ();
			break;

		default:
			Debug.Log ("No game type selected");
			break;
		}
	}

	void OnTriggerEnter(Collider other){
		
		if (other.transform.position.z > transform.position.z + 0.1f) {
			if (other.tag == "Wrong") {
				isWrong = true;

				if(canProduceSound == 1){
					audioSource.clip = incorrectSound;
					audioSource.Play ();
				}
				//errorFinder.text = ("Reached");
				GetComponent<score> ().OnWrongAnswer (gametype);

			} else if (other.tag == "Right") {
				if (canProduceSound == 1) {
					audioSource.clip = correctSound;
					audioSource.Play ();
				}

				switch (gametype) {
				case 1:
					MG.GetComponent<mathGame> ().AdditionTiles ();

					if(PlayerPrefs.GetFloat (currentplayer+"_Addexp") == 0){
						exp = (int)experience;
					}else{
						exp = ((int)PlayerPrefs.GetFloat (currentplayer+"_Addexp") + (int)experience);
					}

					PlayerPrefs.SetFloat (currentplayer+"_Addexp", exp);
					break;

					case 2:
					MG.GetComponent<mathGame> ().SubtractionTiles ();

					if(PlayerPrefs.GetFloat (currentplayer+"_Addexp") == 0){
						exp = (int)experience;
					}else{
						exp = ((int)PlayerPrefs.GetFloat (currentplayer+"_Subtractexp") + (int)experience);
					}
						
					PlayerPrefs.SetFloat (currentplayer+"_Subtractexp", exp);
					break;

					case 3:
					MG.GetComponent<mathGame> ().MultiplicationTiles ();

					if(PlayerPrefs.GetFloat (currentplayer+"_Addexp") == 0){
						exp = (int)experience;
					}else{
						exp = ((int)PlayerPrefs.GetFloat (currentplayer+"_Multiplyexp") + (int)experience);
					}


					PlayerPrefs.SetFloat (currentplayer+"_Multiplyexp", exp);
					break;

					case 4:
					MG.GetComponent<mathGame> ().DivisionTiles ();

					if(PlayerPrefs.GetFloat (currentplayer+"_Addexp") == 0){
						exp = (int)experience;
					}else{
						exp = ((int)PlayerPrefs.GetFloat (currentplayer+"_Divideexp") + (int)experience);
					}


					PlayerPrefs.SetFloat (currentplayer+"_Divideexp", exp);
					break;

					default:
						Debug.Log ("No game type selected");
					break;
				}

			}
		}
	}




}
