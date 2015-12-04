using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectivesScript : MonoBehaviour {

    public string[] objectives;
    public int[] objectiveGoals;

    public Text textBox;

    PlayerStats playerStats;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public void setUpObjectives()
    {

    }


}
