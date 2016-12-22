using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class nameManager : MonoBehaviour {

	public InputField nameInput;
	//public Text playerName;
	public Dropdown dropDown;

	private GameObject imgname;
	private gameSelected GS;
	private List<string> activenames;

	string[] names = new string[7]{"New Player","empty slot","empty slot","empty slot","empty slot","empty slot","empty slot"};
	string playernames = "";
	string firstTimeName;



	void Start(){
		
		imgname = GameObject.Find ("newplayerpanel");
		GS = GetComponent<gameSelected> ();
		firstTimeName = PlayerPrefs.GetString("FirstPlayer");

		if (firstTimeName == "true" || firstTimeName == "" || firstTimeName == null) {
			PlayerPrefs.SetString ("FirstPlayer", "true");
			imgname.gameObject.SetActive (true);
		} else {
			imgname.gameObject.SetActive(false);
		}

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
		activenames.Clear();
		dropDown.ClearOptions();
		//activenames.Add("New Player");

		foreach (string name in names) {
			activenames.Add (name);
		}
		dropDown.AddOptions(activenames);

		//string cname = GS.getCurrentPlayer ();

//		if (cname == "" || cname == null) {
//			playerName.text = "Choose Name";
//		} else {
//			playerName.text = GS.getCurrentPlayer();
//		}
	}

	public void NamesOnChange(int index)
	{
		if (names [index] == "empty slot" || names [index] == "New Player") {
			//playerName.text = "Choose Name";
			imgname.gameObject.SetActive (true);

		} else {
			
			//playerName.text = names[index];
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
		//Debug.Log ("reached : "+ PlayerPrefs.GetString("AllPlayerNames"));
		PopulateList();
	}

	public void GetName(string newname){
		if (newname.Equals ("")) {
			Debug.Log("Cannot enter empty name...Please enter before saving");
			return;
		}

		if (names.Contains("empty slot")){
			for (int index = 0; index < names.Length; ++index)
			{
				if (names[index] == "empty slot")
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
	//playerName.text = newname;
	nameInput.text = "";
	imgname.gameObject.SetActive(false);

	}
		
	public void CancelName(){
		nameInput.text = "";
		imgname.gameObject.SetActive (false);
		PopulateList ();

	}


}
