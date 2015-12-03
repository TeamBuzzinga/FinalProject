using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class WalkMechanics : MonoBehaviour {
    public float speed;
    public float acceleration;
    public float rotationAcceleration;
    public Rigidbody rigid;

    public bool movementOn = true;//enable or disable movement in script
    public bool rotateOn = true;
    
    private float lastHInput;
    private float lastVInput;

    bool updateEnabled = true;
	// Use this for initialization
	protected virtual void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        lastHInput = Input.GetAxisRaw("Horizontal");
        lastVInput = Input.GetAxisRaw("Vertical");
	}

    void FixedUpdate()
    {
        if (!updateEnabled)
        {
            return;
        }
        updateMovementSpeed();
        updateRotation();
    }

    protected virtual void updateMovementSpeed()
    {
        if (true)
        {
            return;
        }
        float scaling = Mathf.Max(Mathf.Abs(lastHInput), Mathf.Abs(lastVInput));
        Vector3 goalVelocity = new Vector3(lastHInput, 0, lastVInput).normalized * speed * scaling;
        rigid.velocity = Vector3.MoveTowards(rigid.velocity, goalVelocity, Time.fixedDeltaTime * acceleration);
    }

    protected virtual void updateRotation()
    {
        if (!rotateOn)
        {
            return;
        }


    }

    public float getHInput()
    {
        return lastHInput;
    }

    public float getVInput()
    {
        return lastVInput;
    }

    public bool getIsWalking()
    {
        return Mathf.Abs(lastHInput) > .001f || Mathf.Abs(lastVInput) > .001f;
    }

    public void setUpdateEnabled(bool updateEnabled)
    {
        movementOn = updateEnabled;
        rotateOn = updateEnabled;
    }
}
