using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class nameManager : MonoBehaviour {

	public InputField nameInput;
	public Dropdown dropDown;

	public GameObject imgname;
	private gameSelected GS;
	private List<string> activenames;

	string[] names = new string[7]{"Add Player","Add Player","Add Player","Add Player","Add Player","Add Player","Add Player"};
	string playernames = "";
	string firstTimeName;

	Scene sn;

	void Start(){
		sn = SceneManager.GetActiveScene ();
		GS = GetComponent<gameSelected> ();
		firstTimeName = PlayerPrefs.GetString("FirstPlayer");

		//if (sn.name == "GameSelect") {
			if (firstTimeName == "true" || firstTimeName == "" || firstTimeName == null) {
				PlayerPrefs.SetString ("FirstPlayer", "true");
				imgname.SetActive (true);
			} else {
				imgname.SetActive (false);
				//Debug.Log ("Reached");
			}
		//} 

		activenames = new List<string>();

		RetrieveNames();

		for (int n = 0; n < names.Length; n++)
		{
			if (names[n] == GS.getCurrentPlayer())
			{
				dropDown.value = n;
				break;
			}
		}

	}

	private void PopulateList()
	{
		int counter = 0;
		sn = SceneManager.GetActiveScene ();

		activenames.Clear();
		dropDown.ClearOptions();

			
		foreach (string namer in names) {
			if (sn.name == "HomeMenu") {
				if (namer == "Add Player") {
					break;
				}
			} 
			activenames.Add (namer);
			counter++;
		}

		if (counter == 0) {
			activenames.Add ("No names");
		} 
		dropDown.AddOptions (activenames);
		

	}

	public void NamesOnChange(int index)
	{
		if (names [index] == "Add Player") {
			
			imgname.gameObject.SetActive (true);

		} else {
			
			GS.setCurrentPlayer(names[index]);
			dropDown.value = index;

		}
			
	}

	public void RetrieveNames(){
		string tempNames = PlayerPrefs.GetString("AllPlayerNames");

		if (tempNames != "") {
			
			string[] tempNamesArray = tempNames.Split(",".ToCharArray());

			for(int i=0; i<tempNamesArray.Length; i++)
			{
				names[i]=tempNamesArray[i];
			}
		}

		PopulateList();
	}

	public void StoreNames()
	{
		PlayerPrefs.SetString("AllPlayerNames", "");
		playernames = "";

		for (int n = 0; n < names.Length; n++)
		{
			if (n == names.Length - 1)
			{
				playernames += names[n].ToString();
			}
			else
			{
				playernames += names[n].ToString() + ",";
			}
		}

		PlayerPrefs.SetString("AllPlayerNames", playernames);
		PopulateList();
	}

	public void GetName(string newname){
		sn = SceneManager.GetActiveScene ();

		if (newname.Equals ("")) {
			Debug.Log("Cannot enter empty name...Please enter before saving");
			return;
		}

		if (names.Contains("Add Player")){
			for (int index = 0; index < names.Length; index++)
			{
				if (names[index] == "Add Player")
				{
					names[index] = newname;
					break;
				}
			}
		}
		else
		{
			for (int n = 0; n < names.Length - 1; n++) {
				names [n] = names [n + 1];
				names[9] = newname;
			}

		}
	
	StoreNames();
	GS.setCurrentPlayer(newname);
	nameInput.text = "";

		if (sn.name == "GameSelect") {
			imgname.gameObject.SetActive(false);
		} else if(sn.name == "HomeMenu"){

			for(int nm = 0; nm < names.Length; nm++){
				if (names[nm] == newname) {
					dropDown.value = nm;
					break;
				}
			}
		}
	}
		
	public void CancelName(){
		nameInput.text = "";
		imgname.gameObject.SetActive (false);
		PopulateList ();

	}


}
