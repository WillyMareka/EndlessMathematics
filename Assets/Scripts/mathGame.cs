using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class mathGame : MonoBehaviour {
	
	int randNumber1, randNumber2, generateanswer, boxselect;
	int tip1, tip2, tipanswer, lasttry = 0, lcount = 0, mcount = 0, rcount = 0;
	public GameObject emptyObj, choiceObj, GS, PS;
	public Text questionbox, pauseTip;
	private int[] numbers;

	int gametype = 0;

	private GameObject leftObj,middleObj,rightObj,go,leftGlow,middleGlow,rightGlow;
	private TextMesh leftText,middleText,rightText;
	private float spawnZ = 0.0f, tileSize = 26.0f, safeZone = 32.0f;
	private float spawnZ2 = 50.0f;
	private Transform playerTransform;
	private int i = 0;
	private List<GameObject> activeTiles, activeTiles2;
	private bool isPaused = false;


	void Start () {
		gametype = GS.GetComponent<gameSelected> ().getGameState();

		tip1 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));
		tip2 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));

		if (gametype == 1) {
			//Addition Tip

			tipanswer = tip1 + tip2;
			pauseTip.text = "Addition example : " + tip1 +" + __ = "+ tipanswer + ";  Answer is "+ tip2;

		}else if(gametype == 2){
			//Subtraction Tip

			tipanswer = tip1 + tip2;
			pauseTip.text = "Subtraction example : " + tipanswer +" - __ = "+ tip1 + ";  Answer is "+ tip2;

		}else if(gametype == 3){
			//Multiplication Tip

			tipanswer = tip1 * tip2;
			pauseTip.text = "Multiplication example : " + tip1 +" X __ = "+ tipanswer + ";  Answer is "+ tip2;

		}else if(gametype == 4){
			//Division Tip

			tipanswer = tip1 * tip2;
			pauseTip.text = "Division example : " + tipanswer +" / __ = "+ tip1 + ";  Answer is "+ tip2;

		}

		activeTiles = new List<GameObject> ();
		activeTiles2 = new List<GameObject> ();

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		GenerateEmpties ();


	}

	public void GenerateEmpties(){
		for (int t = 0; t < 4; t++) {
			go = Instantiate (emptyObj) as GameObject;
			go.transform.SetParent (transform);

			if(t > 1){
				go.transform.position = Vector3.forward * spawnZ;
				spawnZ += tileSize;
				activeTiles.Add (go);
			}else{
				go.transform.position = Vector3.forward * spawnZ2;
				spawnZ2 += tileSize;
				activeTiles2.Add (go);
			}
		}
	}

	void Update () {
		
		if(Input.GetKeyDown (KeyCode.Escape)){
			if (isPaused == false) {
				PS.GetComponent<pauseScript> ().PauseGame ();
				isPaused = true;
			} else {
				PS.GetComponent<pauseScript> ().PauseGame ();
				isPaused = false;
			}
		}

		if (playerTransform.position.z - safeZone > i * tileSize) {
			DeleteTile ();
			i++;
		}
	}



	void DeleteTile(){
		Destroy (activeTiles[0]);
		activeTiles.RemoveAt (0);
		SpawnEmpty ();
	}


	void GenerateOptions(){
		//Creation of choice boxes for player
		go = Instantiate (choiceObj) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileSize;
		activeTiles.Add (go);

		//Acquiring the children gameObjects within the prefab
		leftObj = go.transform.Find("leftbox").gameObject;
		middleObj = go.transform.Find ("middlebox").gameObject;
		rightObj = go.transform.Find ("rightbox").gameObject;

		//Acquiring the text component from children gameObjects 
		leftText = leftObj.gameObject.GetComponentInChildren<TextMesh> ();
		middleText = middleObj.gameObject.GetComponentInChildren<TextMesh> ();
		rightText = rightObj.gameObject.GetComponentInChildren<TextMesh> ();
	}

	void RandomAssigning(){
		boxselect = (int)(Mathf.Abs(Random.Range (1.0f,6.0f)));

		if((lasttry == 1 || lasttry == 4) && lcount == 2){
			numbers = new int[]{2,3,5,6};
			boxselect = numbers[Random.Range(0,numbers.Length)];
			lcount = 0;
		}else if((lasttry == 2 || lasttry == 5) && mcount == 2){
			numbers = new int[]{1,3,4,6};
			boxselect = numbers[Random.Range(0,numbers.Length)];
			mcount = 0;
		}else if((lasttry == 3 || lasttry == 6) && rcount == 2){
			numbers = new int[]{1,2,4,5};
			boxselect = numbers[Random.Range(0,numbers.Length)];
			rcount = 0;
		}

		lasttry = boxselect;

		switch (boxselect) {
		case 1:
			leftText.text = randNumber2.ToString ();
			middleText.text = (randNumber2 + 1).ToString ();
			rightText.text = (randNumber2 - 1).ToString ();
			lcount++;
				break;

		case 2:
			leftText.text = (randNumber2-1).ToString();
			middleText.text = randNumber2.ToString();
			rightText.text = (randNumber2+1).ToString();
		    mcount++;
			break;

		case 3:
			leftText.text = (randNumber2+1).ToString();
			middleText.text = (randNumber2-1).ToString();
			rightText.text = randNumber2.ToString();
		    rcount++;
			break;

		case 4:
			leftText.text = randNumber2.ToString();
			middleText.text = (randNumber2-1).ToString();
			rightText.text = (randNumber2+1).ToString();
		    lcount++;
			break;

		case 5:
			leftText.text = (randNumber2+1).ToString();
			middleText.text = randNumber2.ToString();
			rightText.text = (randNumber2-1).ToString();
		    mcount++;
			break;

		case 6:
			leftText.text = (randNumber2-1).ToString();
			middleText.text = (randNumber2+1).ToString();
			rightText.text = randNumber2.ToString();
		    rcount++;
			break;

		default:
			Debug.LogWarning ("Problem with boxselect assigning");
			break;
		}



		//Assigning game tags to the children gameObjects from generated prefab
		if(leftText.text == randNumber2.ToString()){
			leftObj.transform.GetChild (1).transform.GetChild (0).gameObject.tag = "Right";

		}else{
			leftObj.transform.GetChild (1).transform.GetChild (0).gameObject.tag = "Wrong";
		}

		if(middleText.text == randNumber2.ToString()){
			middleObj.transform.GetChild (1).transform.GetChild (0).gameObject.tag = "Right";

		}else{
			middleObj.transform.GetChild (1).transform.GetChild (0).gameObject.tag = "Wrong";
		}

		if(rightText.text == randNumber2.ToString()){
			rightObj.transform.GetChild (1).transform.GetChild (0).gameObject.tag = "Right";
		}else{
			rightObj.transform.GetChild (1).transform.GetChild (0).gameObject.tag = "Wrong";
		}
			
	}

	void SpawnEmpty(){
			go = Instantiate (emptyObj) as GameObject;
			go.transform.SetParent (transform);
			go.transform.position = Vector3.forward * spawnZ2;
			spawnZ2 += tileSize;
			activeTiles2.Add (go);
		
	}

	public void AdditionTiles(){
		//randNumber2 is correct answer...
		//...the rest are wrong

		//Number 1 & 2 generation
		randNumber1 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));
		randNumber2 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));

		//Addition Game Calculation
		generateanswer = randNumber1 + randNumber2;

		GenerateOptions ();
		RandomAssigning ();

		Destroy (activeTiles2[0]);
		activeTiles2.RemoveAt (0);

		questionbox.text = "" + randNumber1 + " + __ = " + generateanswer + "";

	}




	public void SubtractionTiles(){
		//randNumber2 is correct answer...
		//...the rest are wrong

		//Number 1 & 2 generation
		randNumber1 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));
		randNumber2 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));

		//Substraction Game Calculation
		generateanswer = randNumber1 + randNumber2;

		GenerateOptions ();
		RandomAssigning ();

		Destroy (activeTiles2[0]);
		activeTiles2.RemoveAt (0);

		//Debug.Log (randNumber1 +" + "+ randNumber2 +" = "+ generateanswer);
		questionbox.text = "" + generateanswer + " - __ = " + randNumber1 + "";

	}

	public void MultiplicationTiles(){
		//randNumber2 is correct answer...
		//...the rest are wrong

		//Number 1 & 2 generation
		randNumber1 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));
		randNumber2 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));

		//Multiplication Game Calculation
		generateanswer = randNumber1 * randNumber2;

		GenerateOptions ();
		RandomAssigning ();

		Destroy (activeTiles2[0]);
		activeTiles2.RemoveAt (0);

		//Debug.Log (randNumber1 +" + "+ randNumber2 +" = "+ generateanswer);
		questionbox.text = "" + randNumber1 + " X __ = " + generateanswer + "";

	}

	public void DivisionTiles(){
		//randNumber2 is correct answer...
		//...the rest are wrong

		//Number 1 & 2 generation
		randNumber1 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));
		randNumber2 = (int)(Mathf.Abs(Random.Range (1.0f,10.0f)));

		Destroy (activeTiles2[0]);
		activeTiles2.RemoveAt (0);

		//Division Game Calculation
		generateanswer = randNumber1 * randNumber2;

		GenerateOptions ();
		RandomAssigning ();


		//Debug.Log (randNumber1 +" + "+ randNumber2 +" = "+ generateanswer);
		questionbox.text = "" + generateanswer + " / __ = " + randNumber1 + "";

	}


}
