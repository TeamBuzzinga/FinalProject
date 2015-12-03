using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class catch_player3 : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

        if (ai.WorkingMemory.ItemExists("catch_time"))
        {

            int caught_time = ai.WorkingMemory.GetItem<int>("catch_time");
           // bool leave = ai.WorkingMemory.GetItem<bool>("leave");


           
                caught_time++;
                ai.WorkingMemory.SetItem<int>("catch_time", caught_time);
                ai.Motor.Speed++;
                //ai.WorkingMemory.SetItem<bool>("leave", false);
                //Debug.Log (leave);


        }

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}