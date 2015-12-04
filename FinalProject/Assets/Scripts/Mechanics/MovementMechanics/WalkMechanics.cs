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
		if (Input.GetKey(KeyCode.LeftShift))
		{
			lastVInput *= .1f;
			lastHInput *= .1f;
		}
		if (!movementOn)
		{
			lastHInput = 0;
			lastVInput = 0;
		}
		checkForDoor ();
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
	
	public void checkForDoor()
	{
		//Debug.Log ("Checking for Door");
		Ray ray1 = new Ray(transform.position + Vector3.up, transform.forward);
		Debug.DrawRay(transform.position + Vector3.up, transform.forward);
		RaycastHit objectHit = new RaycastHit();
		
		if (Physics.Raycast(ray1, out objectHit)) {
			if(objectHit.distance <= .2f && objectHit.transform.tag=="Door"){
				Debug.Log ("Door Found");
				//					push = objectHit.transform.gameObject.GetComponent<AddForcetoObject> ();
				//					push.addForce();
			}
		}
	}
}
