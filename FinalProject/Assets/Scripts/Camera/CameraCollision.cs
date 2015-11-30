using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour {
    public bool cameraIsColliding;
    public float collisionDistance;
    public Collider playerCollider;
    public Material[] listOfMaterials;
    CameraMechanics cameraMechanics;
    int layerMask = 1;

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
        if (Physics.Raycast(checkRay, out hit, Mathf.Abs(cameraMechanics.getCurrentMagnitude()), layerMask))
        {
            cameraIsColliding = true;
            collisionDistance = -hit.distance;
            if (collisionDistance > -.7f)
            {
                collisionDistance = -.7f;
            }
            setMaterialtransparency((-collisionDistance - .6f));
        }
        else
        {
            setMaterialtransparency(1);
            cameraIsColliding = false;
        }
    }

    void setMaterialtransparency(float alpha)
    {
        foreach (Material mat in listOfMaterials)
        {
            mat.color = new Vector4(1, 1, 1, alpha);
        }
    }
}
