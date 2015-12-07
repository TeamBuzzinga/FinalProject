using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IconHandler : MonoBehaviour {
    public Image food;
    public Image keys;
    PlayerStats playerStats;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerStats.keysCollected > 0)
        {
            keys.enabled = true;
        }
        if (playerStats.itemsCollected > 0)
        {
            food.enabled = true;
        }
	}
}
