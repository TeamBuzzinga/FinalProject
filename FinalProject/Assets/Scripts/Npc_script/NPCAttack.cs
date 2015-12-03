using UnityEngine;
using System.Collections;
using RAIN.Core;
using RAIN.Action;

public class NPCAttack : MonoBehaviour {

	private AIRig npc;
	private GameObject player;
	private Animator player_animator;
	// Use this for initialization
	void Start () {
		npc = GetComponentInChildren<AIRig>();
	}
	
	public void playerReact() {
		player = npc.AI.Mind.AI.WorkingMemory.GetItem<GameObject> ("varCharClose");
		player_animator = player.GetComponent<Animator> ();
		player_animator.SetTrigger ("TakeDamage");
	}
}
