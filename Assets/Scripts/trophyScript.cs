using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class trophyScript : MonoBehaviour {

	private GameObject achieved,notachieved;

	private GameObject add100h,sub100h,mult100h,div100h,add250e,sub250e,mult250e,div250e,level2;

	private GameObject add500h,sub500h,mult500h,div500h,add1000e,sub1000e,mult1000e,div1000e,level3;

	private GameObject add1500h,sub1500h,mult1500h,div1500h,add3000e,sub3000e,mult3000e,div3000e,level4;

	private GameObject add2000h,sub2000h,mult2000h,div2000h,add5000e,sub5000e,mult5000e,div5000e,level5;

	private int addscore,subtractscore,multiplyscore,dividescore;
	private int addexperience,subtractexperience,multiplyexperience,divideexperience;
	private int playerlevel;
	string currentplayer;

	// Use this for initialization
	void Start () {
		currentplayer = PlayerPrefs.GetString("CurrentPlayer");

		//First section
		add100h = this.gameObject.transform.GetChild(0).gameObject;
		sub100h = this.gameObject.transform.GetChild(1).gameObject;
		mult100h = this.gameObject.transform.GetChild(2).gameObject;
		div100h = this.gameObject.transform.GetChild(3).gameObject;

		add250e = this.gameObject.transform.GetChild(4).gameObject;
		sub250e = this.gameObject.transform.GetChild(5).gameObject;
		mult250e = this.gameObject.transform.GetChild(6).gameObject;
		div250e = this.gameObject.transform.GetChild(7).gameObject;

		level2 = this.gameObject.transform.GetChild(8).gameObject;

		//Second section

		add500h = this.gameObject.transform.GetChild(9).gameObject;
		sub500h = this.gameObject.transform.GetChild(10).gameObject;
		mult500h = this.gameObject.transform.GetChild(11).gameObject;
		div500h = this.gameObject.transform.GetChild(12).gameObject;

		add1000e = this.gameObject.transform.GetChild(13).gameObject;
		sub1000e = this.gameObject.transform.GetChild(14).gameObject;
		mult1000e = this.gameObject.transform.GetChild(15).gameObject;
		div1000e = this.gameObject.transform.GetChild(16).gameObject;

		level3 = this.gameObject.transform.GetChild(17).gameObject;

		//Third section

		add1500h = this.gameObject.transform.GetChild(18).gameObject;
		sub1500h = this.gameObject.transform.GetChild(19).gameObject;
		mult1500h = this.gameObject.transform.GetChild(20).gameObject;
		div1500h = this.gameObject.transform.GetChild(21).gameObject;

		add3000e = this.gameObject.transform.GetChild(22).gameObject;
		sub3000e = this.gameObject.transform.GetChild(23).gameObject;
		mult3000e = this.gameObject.transform.GetChild(24).gameObject;
		div3000e = this.gameObject.transform.GetChild(25).gameObject;

		level4 = this.gameObject.transform.GetChild(26).gameObject;

		//Fourth section

		add2000h = this.gameObject.transform.GetChild(27).gameObject;
		sub2000h = this.gameObject.transform.GetChild(28).gameObject;
		mult2000h = this.gameObject.transform.GetChild(29).gameObject;
		div2000h = this.gameObject.transform.GetChild(30).gameObject;

		add5000e = this.gameObject.transform.GetChild(31).gameObject;
		sub5000e = this.gameObject.transform.GetChild(32).gameObject;
		mult5000e = this.gameObject.transform.GetChild(33).gameObject;
		div5000e = this.gameObject.transform.GetChild(34).gameObject;

		level5 = this.gameObject.transform.GetChild(35).gameObject;

		//High scores...

		addscore = ((int)PlayerPrefs.GetFloat (currentplayer+"_Addscore"));
		subtractscore = ((int)PlayerPrefs.GetFloat (currentplayer+"_Subtractscore"));
		multiplyscore = ((int)PlayerPrefs.GetFloat (currentplayer+"_Multiplicationscore"));
		dividescore = ((int)PlayerPrefs.GetFloat (currentplayer+"_Divisionscore"));

		//Experience Points...
		addexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Addexp"));
		subtractexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Subtractexp"));
		multiplyexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Multiplyexp"));
		divideexperience = ((int)PlayerPrefs.GetFloat (currentplayer+"_Divideexp"));

		playerlevel = ((int)PlayerPrefs.GetFloat (currentplayer+"_PlayerLevel"));

		//Function to update the achievements

		AchieveUpdate ();
	}

	void RemoveLocked(GameObject go){
		go.SetActive (false);
	}

	void EnableAchievement(GameObject go){
		go.SetActive (true);
	}

	void AchieveUpdate(){
		//....HighScores...//
		//Add HighScores

		if (addscore >= 100 && addscore < 500) {
			achieved = add100h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add100h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(addscore >= 500 && addscore < 1500){
			achieved = add500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(addscore >= 1500 && addscore < 2000){
			achieved = add1500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add1500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(addscore >= 2000){
			achieved = add2000h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add2000h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}


		//Subtract HighScores

		if(subtractscore >= 100 && subtractscore < 500){
			achieved = sub100h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub100h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(subtractscore >= 500 && subtractscore < 1500){
			achieved = sub500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(subtractscore >= 1500 && subtractscore < 2000){
			achieved = sub1500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub1500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(subtractscore >= 2000){
			achieved = sub2000h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub2000h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		//Multiply HighScores

		if(multiplyscore >= 100){
			achieved = mult100h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult100h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(multiplyscore >= 500){
			achieved = mult500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(multiplyscore >= 1500){
			achieved = mult1500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult1500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(multiplyscore >= 2000){
			achieved = mult2000h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult2000h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		//Divide HighScores

		if(dividescore >= 100){
			achieved = div100h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div100h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(dividescore >= 500){
			achieved = div500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(dividescore >= 1500){
			achieved = div1500h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div1500h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(dividescore >= 2000){
			achieved = div2000h.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div2000h.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		//....End of HighScores...//

		//....Experiences...//
		//Add Experiences

		if(addexperience >= 250){
			achieved = add250e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add250e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(addexperience >= 1000){
			achieved = add1000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add1000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(addexperience >= 3000){
			achieved = add3000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add3000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(addexperience >= 5000){
			achieved = add5000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = add5000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}


		//Subtract Experiences

		if(subtractexperience >= 250){
			achieved = sub250e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub250e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(subtractexperience >= 1000){
			achieved = sub1000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub1000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(subtractexperience >= 3000){
			achieved = sub3000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub3000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(subtractexperience >= 5000){
			achieved = sub5000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = sub5000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		//Multiply Experiences

		if(multiplyexperience >= 250){
			achieved = mult250e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult250e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(multiplyexperience >= 1000){
			achieved = mult1000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult1000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(multiplyexperience >= 3000){
			achieved = mult3000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult3000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(multiplyexperience >= 5000){
			achieved = mult5000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = mult5000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		//Divide Experiences

		if(divideexperience >= 250){
			achieved = div250e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div250e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(divideexperience >= 1000){
			achieved = div1000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div1000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(divideexperience >= 3000){
			achieved = div3000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div3000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(divideexperience >= 5000){
			achieved = div5000e.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = div5000e.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		//....End of Experiences...//


		//....Levels...//

		if(playerlevel == 2){
			achieved = level2.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = level2.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(playerlevel == 3){
			achieved = level3.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = level3.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(playerlevel == 4){
			achieved = level4.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = level4.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}

		if(playerlevel == 5){
			achieved = level5.gameObject.transform.GetChild (2).gameObject;
			RemoveLocked (achieved);
		} else {
			notachieved = level5.gameObject.transform.GetChild (0).gameObject;
			RemoveLocked (notachieved);
		}
		//....End of Levels...//

	}



}
