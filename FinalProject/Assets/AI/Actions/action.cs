using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class action : RAINAction
{
	private GameObject gameObject;
	private Animator animator;
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		gameObject = ai.WorkingMemory.GetItem<GameObject> ("varCharClose");
		animator = gameObject.GetComponent<Animator> ();
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		animator.SetBool ("TakeDamage", false);
		
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}