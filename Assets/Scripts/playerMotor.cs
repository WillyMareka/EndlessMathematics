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
	int exp, characterinput, gametype = 0;
	private bool canMove = false;

	public Image imageTip;
	public float speed = 5.0f;
	public GameObject GS,MG,controllers;


	//[SerializeField] private float minimumSwipeDistanceY;
	private float minimumSwipeDistanceX = 200;
	private Touch t = default(Touch);
	private Vector3 startPosition = Vector3.zero;


	void Start () {
		gametype = GS.GetComponent<gameSelected> ().getGameState();
		characterinput = GS.GetComponent<gameSelected> ().getCharacterInput();

		controllers.SetActive (false);

		controller = GetComponent<CharacterController>();

		moveVector = Vector3.zero;
		lane = 0;
		Time.timeScale = 1;
		startTime = Time.deltaTime;

	}
	

	void Update () {
		
		if (isWrong) {
			return;
		}

		if(GameObject.Find("Canvas/ImageTip") != null){
			if ((Input.anyKeyDown) || Time.time >= 7) {
				RemoveTip ();
			}
		}
			
		controller.Move ((Vector3.forward * speed) * Time.deltaTime);


		if (Time.time - startTime < animationDuration && canMove == false) {
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
			canMove = true;
			Destroy (imageTip.gameObject);
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
				GetComponent<score> ().OnWrongAnswer (gametype);

			} else if (other.tag == "Right") {
				switch (gametype) {
				case 1:
					MG.GetComponent<mathGame> ().AdditionTiles ();
					exp = ((int)PlayerPrefs.GetFloat ("Addexp") + (int)experience);
					PlayerPrefs.SetFloat ("Addexp", exp);
					//Destroy (other.gameObject);
					break;

					case 2:
					MG.GetComponent<mathGame> ().SubtractionTiles ();
					exp = ((int)PlayerPrefs.GetFloat ("Subtractexp") + (int)experience);
					PlayerPrefs.SetFloat ("Subtractexp", exp);
					//Destroy (other.gameObject);
					break;

					case 3:
					MG.GetComponent<mathGame> ().MultiplicationTiles ();
					exp = ((int)PlayerPrefs.GetFloat ("Multiplyexp") + (int)experience);
					PlayerPrefs.SetFloat ("Multiplyexp", exp);
					//Destroy (other.gameObject);
					break;

					case 4:
					MG.GetComponent<mathGame> ().DivisionTiles ();
					exp = ((int)PlayerPrefs.GetFloat ("Divideexp") + (int)experience);
					PlayerPrefs.SetFloat ("Divideexp", exp);
					//Destroy (other.gameObject);
					break;

					default:
						Debug.Log ("No game type selected");
					break;
				}
			}
		}
	}




}
