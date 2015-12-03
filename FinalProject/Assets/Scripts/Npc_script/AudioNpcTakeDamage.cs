using UnityEngine;
using System.Collections;
using RAIN.Core;
using RAIN.Action;

public class AudioNpcTakeDamage : MonoBehaviour {

	private AIRig npc;
	private GameObject player;
    private ParticleSystem[] p_systems;
    private Animator player_animator;
    private bool hit=false;
	// Use this for initialization
	void Start () {
		npc = GetComponentInChildren<AIRig>();
        p_systems = GetComponentsInChildren<ParticleSystem>();
        player_animator = GetComponent<Animator>();
	}

	public void takeDamage() {
		if (npc.AI.Mind.AI.WorkingMemory.ItemExists ("stun") ) {
			Debug.Log("stunstun");
			npc.AI.Mind.AI.WorkingMemory.SetItem<bool>("stun",true);
			}
		}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            npc.AI.Mind.AI.WorkingMemory.SetItem<bool>("stun", true);
        }
    }

    void Update()
    {

        if (npc.AI.Mind.AI.WorkingMemory.GetItem<bool>("stun"))
        {
            for (int i = 0; i < p_systems.Length; i++)
            {
                if (p_systems[i].name != "dust")
                {
                    if (p_systems[i].isStopped)
                        p_systems[i].Play();
                }
            }
        }
        else
        {
            for (int i = 0; i < p_systems.Length; i++)
            {
                if (p_systems[i].name != "dust")
                {
                    p_systems[i].Stop();
                }
            }
        }

        if (player_animator.GetFloat("Speed") > 1)
        {
            
            for (int i = 0; i < p_systems.Length; i++)
            {
                if (p_systems[i].name == "dust")
                    p_systems[i].Play();
            }
        }
        else
        {
            
            for (int i = 0; i < p_systems.Length; i++)
            {
                if (p_systems[i].name == "dust")
                    p_systems[i].Stop();
            }
        }





    }




}
