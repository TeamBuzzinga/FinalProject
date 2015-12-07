using UnityEngine;
using System.Collections;

public class StrikesAnimator : MonoBehaviour {
    Animator anim;
    PlayerStats playerStats;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("Strikes", playerStats.strikes);
    }
}
