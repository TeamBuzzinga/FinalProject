using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectivesScript : MonoBehaviour {

    public string[] objectives;
    public int[] objectiveGoals;
    public int[] objectiveID;

    public Text textBox;

    PlayerStats playerStats;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        setUpObjectives();
    }

    public void setUpObjectives()
    {
        string str = "";
        foreach (string obj in objectives)
        {
            
            str += ("[]" + obj + "\n");
        }
        textBox.text = str;
    }

    bool checkObjectiveCompleted(int id )
    {
     
        return false;
    }


}
