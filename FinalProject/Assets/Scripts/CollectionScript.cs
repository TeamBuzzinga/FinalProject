using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class CollectionScript : MonoBehaviour {
    public int id = 0;
    const int keyCollect = 0;
    const int itemCollect = 1;


    void OnTriggerEnter(Collider collider)
    {
        PlayerStats playerStats = collider.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            switch (id)
            {
                case keyCollect:
                    playerStats.keysCollected++;
                    break;
                case itemCollect:
                    playerStats.itemsCollected++;
                    break;

            }
            Destroy(this.gameObject);
        }
    }
}
