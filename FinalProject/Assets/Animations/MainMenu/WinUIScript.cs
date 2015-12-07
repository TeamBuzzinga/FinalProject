using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinUIScript : MonoBehaviour {
    public Text timeScore;
    public Text strikesScore;
    public Text totalScore;
    Animator anim;
    PlayerStats playerStats;
    float time;
    bool winCalled;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        print(playerStats.reachedGoal);
	    if (playerStats.reachedGoal > 0 && !winCalled)
        {
            int tScore = (int)((180f - time) * 5);
            int sScore = (int)((3 - playerStats.strikes) * 150);
            timeScore.text = "Time Bonus: " + tScore + " Pts";
            strikesScore.text = "Stike Bonus: " + sScore + " Pts";
            totalScore.text = "Total: " + (sScore + tScore) + " Pts";
            anim.SetTrigger("Win");
            
            winCalled = true;

        }
	}

    
}
