using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectivesScript : MonoBehaviour {

    public string[] objectives;
    public int[] objectiveGoals;
    public int[] objectiveID;

    public Text textBox;

    Animator anim;
    PlayerStats playerStats;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (getObjectiveUp() && Input.anyKeyDown)
        {
            setUpObjectives();
        }
    }

    public void setUpObjectives()
    {

        anim.SetTrigger("ObjectiveUp");
        string str = "";
        int i = 0;
        foreach (string obj in objectives)
        {
            string checkbox = "[]";
            if (checkObjectiveProgress(objectiveID[i]) == objectiveGoals[i])
            {
                checkbox = "[X]";
            }
            str += (checkbox + obj + "\n");
            i++;
        }
        textBox.text = str;
    }

    int checkObjectiveProgress(int id )
    {
        switch (id)
        {
            case 0:
                return playerStats.keysCollected;
            case 1:
                return playerStats.itemsCollected;
            case 2:
                return playerStats.strikes;
            case 3:
                return playerStats.reachedGoal;
        }
        return 0;
    }

    public bool getObjectiveUp()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ObjectiveUp"))
        {
            return true;
        }
        return false;
    }
}
