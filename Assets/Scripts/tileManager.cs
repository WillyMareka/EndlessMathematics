using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileSize = 16.0f;
	private int amountOfTiles = 6;
	private float safeZone = 20.0f;
	private int lastPrefabIndex = 0;

	private List<GameObject> activeTiles;

	void Start () {
		
		activeTiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for(int t = 0; t < amountOfTiles; t++){

			if (t < 3) {
				SpawnTile (0);
			} else {
				SpawnTile ();
			}

		}
	}
		
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - amountOfTiles * tileSize)) {
			SpawnTile ();
			DeleteTile ();
		}
	}

	void DeleteTile(){
		Destroy (activeTiles[0]);
		activeTiles.RemoveAt (0);
	}

	void SpawnTile (int prefabIndex = -1){
		GameObject go;
		if (prefabIndex == -1) {
			go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		} else {
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		}

		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileSize;
		activeTiles.Add (go);
	}

	int RandomPrefabIndex(){
		if (tilePrefabs.Length <= 1) {
			return 0;
		}

		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex){
			randomIndex = Random.Range (1, tilePrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}



}
