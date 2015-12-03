using UnityEngine;
using System.Collections;
using RAIN.Core;
using RAIN.Action;

public class NpcTakeDamage : MonoBehaviour {

	private AIRig npc;
	private GameObject player;
    private ParticleSystem[] particle;
    private Animator player_animator;
	// Use this for initialization
	void Start () {
		npc = GetComponentInChildren<AIRig>();
        particle = GetComponentsInChildren<ParticleSystem>();
        player_animator = GetComponent<Animator>();
	}

	public void takeDamage() {
		if (npc.AI.Mind.AI.WorkingMemory.ItemExists ("myHealth") && npc.AI.Mind.AI.WorkingMemory.ItemExists ("varCharClose")) {
			Debug.Log("Inside takeDamage");
			if (npc.AI.Mind.AI.WorkingMemory.GetItem<GameObject>("varCharClose") != null) {
				int myHealth = npc.AI.Mind.AI.WorkingMemory.GetItem<int>("myHealth");
				myHealth = myHealth - 10;
				npc.AI.Mind.AI.WorkingMemory.SetItem<int>("myHealth",myHealth);
			}
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
            if (player_animator.GetFloat("Speed") > 0)
            {
                for(int i=0;i<particle.Length;i++)
                {
                    if(particle[i].name=="dust")
                        particle[i].Play();
                }
            }
            else
            {
                for(int i=0;i<particle.Length;i++)
                {
                    if(particle[i].name=="dust")
                        particle[i].Stop();
                }
            }



            if (npc.AI.Mind.AI.WorkingMemory.GetItem<bool>("stun"))
            {
                for (int i = 0; i < particle.Length; i++)
                {
                    if (particle[i].name != "dust")
                    {
                        if (particle[i].isStopped)
                            particle[i].Play();
                    }
                }
            }
            else
            {
                for (int i = 0; i < particle.Length; i++)
                {
                    if (particle[i].name != "dust")
                    {
                        particle[i].Stop();
                    }
                }
            }






                
    }


}
