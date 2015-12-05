using UnityEngine;
using System.Collections;

public class LoseGUIAnimation : MonoBehaviour {
    public float timeUntilRestart = 10;
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
        if (playerLost)
        {
            timeUntilRestart = Mathf.MoveTowards(timeUntilRestart, 0, Time.deltaTime);
            if (timeUntilRestart <= 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (playerStats.strikes > 2 && !playerLost)
        {
            playerLost = true;
            anim.SetTrigger("LoseGame");
        }
    }


}
