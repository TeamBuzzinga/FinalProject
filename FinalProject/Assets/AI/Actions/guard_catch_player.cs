using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class guard_catch_player : RAINAction
{

    GameObject player;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

		if(ai.WorkingMemory.ItemExists("catch_time"))
		{

			int caught_time=ai.WorkingMemory.GetItem<int>("catch_time");
			bool leave=ai.WorkingMemory.GetItem<bool>("leave");
            bool stun = ai.WorkingMemory.GetItem<bool>("stun");

			if (caught_time <= 3 && leave && !stun)
			{

                player.GetComponent<PlayerStats>().strikes++;


				caught_time++;
				ai.WorkingMemory.SetItem<int>("catch_time",caught_time);
				ai.Motor.Speed++;
				ai.WorkingMemory.SetItem<bool>("leave",false);
				//Debug.Log (leave);

			}

		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}