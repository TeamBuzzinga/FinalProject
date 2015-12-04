using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class catch_player2 : RAINAction
{
	private GameObject gameObject;
	private Animator animator;
    GameObject player;



	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		//gameObject = ai.WorkingMemory.GetItem<GameObject> ("varCharClose");
		//animator = gameObject.GetComponent<Animator> ();

        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		//animator.SetTrigger ("TakeDamage");
		if(ai.WorkingMemory.ItemExists("catch_time"))
		{
			
			int caught_time=ai.WorkingMemory.GetItem<int>("catch_time");
			
			if (caught_time <= 3)
			{

                player.GetComponent<PlayerStats>().strikes++;



				caught_time++;
				ai.WorkingMemory.SetItem<int>("catch_time",caught_time);
			}
		}
		
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}