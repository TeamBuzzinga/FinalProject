using UnityEngine;
using System.Collections;

public class normaldooropen : MonoBehaviour {
    public Transform door1;
    public Transform door1OpenPosition;
    private Vector3 door1initial;


    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            openDoors();

        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            closeDoors();
        }
    }

    void openDoors()
    {
        door1initial = door1.position;
        door1.position = door1OpenPosition.position;
    }

    void closeDoors()
    {
        door1.position = door1initial;
    }
}
