using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour {
    public bool cameraIsColliding;
    public float collisionDistance;
    public Collider playerCollider;
    CameraMechanics cameraMechanics;

    void Start()
    {
        cameraMechanics = GetComponent<CameraMechanics>();
    }

    void Update()
    {
        checkCollision();
    }

    void checkCollision()
    {
        Ray checkRay = new Ray(cameraMechanics.getTargetFollow().position, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(checkRay, out hit, Mathf.Abs(cameraMechanics.getCurrentMagnitude())))
        {
            cameraIsColliding = true;
            collisionDistance = -hit.distance;
            if (collisionDistance > -.45f)
            {
                collisionDistance = -.45f;
            }
        }
        else cameraIsColliding = false;
    }
}
