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
            if (checkObjectiveComplete(playerStats))
            {
                playerStats.reachedGoal++;
                winAnim.SetTrigger("WinGame");
            }
        }


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
