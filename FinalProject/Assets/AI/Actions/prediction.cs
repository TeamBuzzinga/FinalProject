using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class prediction : RAINAction
{
    public Transform player;
    Rigidbody playerRigid;
    Vector3 futureLocation = new Vector3();
    float calculateTimer;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		player = GameObject.FindGameObjectWithTag("player").transform;
        playerRigid = player.GetComponent<Rigidbody>();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        updateFutureLocation(ai);
        
        return ActionResult.SUCCESS;
    }

    void updateFutureLocation(RAIN.Core.AI ai)
    {
        //calculateTimer += ai.WorkingMemory.GetItem<float>("calculateTime");
        Vector3 playerFwd = player.forward;
        Vector3 playerVel = playerRigid.velocity;
        futureLocation = player.position + playerFwd * playerVel.magnitude * 3;
        Debug.Log(futureLocation);

        ai.WorkingMemory.SetItem<Vector3>("futureLocation", futureLocation);
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}