using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    int itemsCollected = 0;
    int keysCollected = 0;
    int strikes = 0;//How often the player has been spotted

    public void collectKey()
    {
        keysCollected++;
    }

    public void collectItem()
    {
        itemsCollected++;
    }

    public void playerStrike()
    {
        strikes++;
    }

    public int getStrikes()
    {
        return strikes;
    }

    public int getTotalKeys()
    {
        return keysCollected;
    }

    public int getTotlaItems()
    {
        return itemsCollected;
    }
}
