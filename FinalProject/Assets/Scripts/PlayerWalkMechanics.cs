using UnityEngine;
using System.Collections;

public class PlayerWalkMechanics : WalkMechanics {
    public Transform cameraFollow;

    protected override void Start()
    {
        base.Start();
    }

    protected override void updateMovementSpeed()
    {
        float scaling = Mathf.Max(Mathf.Abs(getHInput()), Mathf.Abs(getVInput()));
        Vector3 cameraFwd = cameraFollow.forward - new Vector3(0, cameraFollow.forward.y);
        Vector3 cameraRight = cameraFollow.right - new Vector3(0, cameraFollow.right.y);
        Vector3 goalVector = cameraFwd * getVInput() + cameraRight * getHInput();
        goalVector = goalVector.normalized * scaling * speed;
        rigid.velocity = Vector3.MoveTowards(rigid.velocity, goalVector, Time.fixedDeltaTime * acceleration);
    }

    protected override void updateRotation()
    {
        base.updateRotation();
        if (Mathf.Abs(getVInput()) > .001f || Mathf.Abs(getHInput()) > .001f)
        {
            Vector3 directionInput = (cameraFollow.forward * getVInput() + cameraFollow.right * getHInput());
            directionInput = (directionInput - new Vector3(0, directionInput.y, 0)).normalized;
            float goalRotation = Mathf.Atan2(directionInput.x, directionInput.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, goalRotation, 0)), Time.fixedDeltaTime * rotationAcceleration);
        }



    }
}
