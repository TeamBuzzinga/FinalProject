using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {
    public int checkKeyCollected;
    public int checkItemsCollected;
    public string nextLevelName = "RyanMainMenu";
    Animator winAnim;



    void Start()
    {
        winAnim = GameObject.FindGameObjectWithTag("Win").GetComponent<Animator>();

    }


    public void OnTriggerEnter(Collider collider)
    {
        PlayerStats playerStats = collider.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            //Dingfeng checks the objective completion when the player enters the door. Check dooropen.cs
            
            //if (checkObjectiveComplete(playerStats))
            //{
                playerStats.reachedGoal++;

                //winAnim.SetTrigger("WinGame");
            //}

              
                   
        }


    }

    public void OnLevelClick()
    {
        if (Application.loadedLevelName == "Office Level 1")
            Application.LoadLevel("Office Level 2");
        else if (Application.loadedLevelName == "Office Level 2")
            Application.LoadLevel("Office Level 3");
        else
            Application.LoadLevel(nextLevelName);

    }

    bool checkObjectiveComplete(PlayerStats playerStats)
    {
        if (playerStats.keysCollected < checkKeyCollected)
        {
            return false;
        }
        if (playerStats.itemsCollected < checkItemsCollected)
        {
            return false;
        }
        return true; 
    }
}
