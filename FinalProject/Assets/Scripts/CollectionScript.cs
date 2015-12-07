using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class CollectionScript : MonoBehaviour {
	public int id = 0;
	const int keyCollect = 0;
	const int itemCollect = 1;
	public ObjectiveSound objective;
	
	
	
	
	void OnTriggerEnter(Collider collider)
	{
		
		PlayerStats playerStats = collider.GetComponent<PlayerStats>();
		if (playerStats != null)
		{
			switch (id)
			{
			case keyCollect:
				playerStats.keysCollected++;
				objective.setSound(1);
				break;
			case itemCollect:
				playerStats.itemsCollected++;
				objective.setSound(2);
				break;
			}

			Destroy(this.gameObject);
		}
	}
}
