using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class take_damage : RAINAction
{
	private GameObject gameObject;
	private Animator animator;
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		gameObject = ai.WorkingMemory.GetItem<GameObject> ("varCharClose");
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		if (ai.WorkingMemory.ItemExists ("myHealth")) {
			if (Input.GetKeyDown (KeyCode.V) || true) {
				Debug.Log("Inside key down v");
				int myHealth=ai.WorkingMemory.GetItem<int>("myHealth");
				myHealth -= 10;
				ai.WorkingMemory.SetItem<int>("myHealth",myHealth);
			}
		}
		
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}