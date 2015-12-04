using UnityEngine;
using System.Collections;

public class ThrowMechanics : MonoBehaviour {
    public float coolDown;
    public float spawnBallDelay;
    public GameObject ball;
    public Transform throwPosition;
    public float throwForce;
    public Vector3 direction = new Vector3(1, 0, 0);
    float ballDealyTimer = 0;
    float cdTimer = 0;
    Animator anim;
    PlayerStats playerStats;
    PlayerWalkMechanics walkMechanics;

    void Update()
    {
        cdTimer = Mathf.MoveTowards(cdTimer, 0, Time.deltaTime);
        
        if (Input.GetButtonUp("Fire1") && playerStats.papaerBalls > 0 && cdTimer <= 0)
        {
            throwBall();
        }
       
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            walkMechanics.movementOn = false;

            float goalY = walkMechanics.cameraFollow.transform.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, goalY, 0), Time.fixedDeltaTime * 10);
        }
        else
        {
            walkMechanics.movementOn = true;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
        walkMechanics = GetComponent<PlayerWalkMechanics>();
    }

    void throwBall()
    {
        anim.SetTrigger("Throw");
        ballDealyTimer = spawnBallDelay;
        cdTimer = coolDown;
        GameObject obj = (GameObject)Instantiate(ball, throwPosition.position, new Quaternion());
        Vector3 throwDirection = (direction.x * transform.forward + direction.y * transform.up + direction.z * transform.right).normalized;
        obj.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce);
        obj.GetComponent<DestroyOnTrigger>().ignoreTrigger(GetComponent<Collider>());
        playerStats.papaerBalls--;
    }

    

}
