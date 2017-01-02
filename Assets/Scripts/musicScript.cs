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
		if (PlayerPrefs.GetInt ("MusicInput") == 1) {
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	void Update(){
		if (this.gameObject) {
			sn = SceneManager.GetActiveScene ();
			if(PlayerPrefs.GetInt ("MusicInput") == 1){
				if (sn.name == "testlevel") {
					Destroy (this.gameObject);
				} else {
					DontDestroyOnLoad (this.gameObject);
				}
			}

		}
	}


}
