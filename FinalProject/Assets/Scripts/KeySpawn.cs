using UnityEngine;
using System.Collections;


public class KeySpawn : MonoBehaviour {

	public Vector3[] spawnPoints = new Vector3[5];
	public Transform carKey;
	// Use this for initialization
	void Start () {
		int positionIndex = Random.Range (0, 5);
		//Debug.Log (positionIndex.ToString());
		Instantiate (carKey, spawnPoints [positionIndex], Quaternion.identity);
	}
}
