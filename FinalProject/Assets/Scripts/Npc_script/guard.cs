using UnityEngine;
using System.Collections;
using RAIN.Core;
using RAIN.Action;

public class guard : MonoBehaviour {

	private AIRig npc;
	private GameObject player;
    private ParticleSystem[] p_systems;
    private Animator player_animator;
    private bool hit=false;
    private Transform guard_location;

    private AudioSource dizzy;

    public GameObject exclamation1;
    public GameObject exclamation2;
    private GameObject[] switches;

	// Use this for initialization
	void Start () {
		npc = GetComponentInChildren<AIRig>();
        p_systems = GetComponentsInChildren<ParticleSystem>();
        player_animator = GetComponent<Animator>();
        dizzy = GetComponent<AudioSource>();
        guard_location = GetComponent<Transform>();
        npc.AI.Mind.AI.WorkingMemory.SetItem<Vector3>("initial_location", guard_location.position);

        switches = GameObject.FindGameObjectsWithTag("Switch");


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


    bool check_lighton()
    {

        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].GetComponent<LightControl>().lighton == false)
            {
                return false;
            }
        }

        return true;
    }

    void Update()
    {
        npc.AI.Mind.AI.WorkingMemory.SetItem<bool>("lighton", check_lighton());

       


        if (npc.AI.Mind.AI.WorkingMemory.GetItem<bool>("stun"))
        {
            if (!dizzy.isPlaying)
                dizzy.Play();
            for (int i = 0; i < p_systems.Length; i++)//start dizzy particle effect
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
            dizzy.Stop();
            for (int i = 0; i < p_systems.Length; i++)
            {
                if (p_systems[i].name != "dust")//stop dizzy
                {
                    p_systems[i].Stop();
                }
            }
        }

        if (player_animator.GetFloat("Speed") > 1)
        {
            
            for (int i = 0; i < p_systems.Length; i++)
            {
                if (p_systems[i].name == "dust")//start dust
                    p_systems[i].Play();
            }
        }
        else
        {
            
            for (int i = 0; i < p_systems.Length; i++)
            {
                if (p_systems[i].name == "dust")//start dust
                    p_systems[i].Stop();
            }
        }

        if (npc.AI.Mind.AI.WorkingMemory.GetItem<GameObject>("soundLocation") != null)
        {
            exclamation1.GetComponent<MeshRenderer>().enabled = true;
            exclamation2.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            exclamation1.GetComponent<MeshRenderer>().enabled = false;
            exclamation2.GetComponent<MeshRenderer>().enabled = false;
        }






    }




}
