using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
    public Transform door1;
    public Transform door2;
    public Transform door1OpenPosition;
    public Transform door2OpenPosition;
    private Vector3 door1initial;
    private Vector3 door2initial;


	void OnTriggerEnter(Collider collider)
    {
        PlayerStats playerStats = collider.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            if (Application.loadedLevelName == "Office Level 1")
            {
                if (collider.tag == "Player" && playerStats.keysCollected > 0)
                {
                    openDoors();
                }
            }
            else if (Application.loadedLevelName == "Office Level 2")
            {
                if (collider.tag == "Player" && playerStats.itemsCollected > 2)
                {
                    openDoors();
                }
            }
            else
            {
                if (collider.tag == "Player")
                {
                    openDoors();
                }

            }
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
        door2initial = door2.position;
        door1.position = door1OpenPosition.position;
        door2.position = door2OpenPosition.position;
    }

    void closeDoors()
    {
        door1.position = door1initial;
        door2.position = door2initial;
    }
}
