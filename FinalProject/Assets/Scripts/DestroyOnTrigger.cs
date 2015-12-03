using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour {
    public void ignoreTrigger(Collider collider)
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), collider);
    }

    void OnTriggerEnter(Collider collider)
    {
        Destroy(this.gameObject);
    }
}
