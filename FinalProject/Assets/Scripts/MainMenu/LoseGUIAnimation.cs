using UnityEngine;
using System.Collections;

public class LoseGUIAnimation : MonoBehaviour {
    Animator anim;
    PlayerStats playerStats;
    bool playerLost;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (playerStats.strikes > 3 && !playerLost)
        {
            anim.SetTrigger("LoseGame");
        }
    }
}
