using UnityEngine;
using UnityEngine.SceneManagement;

public class musicScript : MonoBehaviour {

	Scene sn;

	private static musicScript instance = null;
	public static musicScript Instance{
		get { return instance; }
	}

	void Awake(){
		if(instance != null && instance != this){
			Destroy(this.gameObject);
		}else{
			instance = this;
		}
	}

	void Update(){
		if (this.gameObject) {
			sn = SceneManager.GetActiveScene ();
			if (sn.name == "testlevel") {
				Destroy (this.gameObject);
			} else {
				DontDestroyOnLoad (this.gameObject);
			}
		}
	}


}
