using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {

    public bool lighton = true;
    public GameObject light1;


	// Use this for initialization
	void Start () {
	    
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (light1.GetComponent<Light>().intensity < 0.5f)
            {
                light1.GetComponent<Light>().intensity = 0.7f;
                lighton = true;
            }
            else
            {
                light1.GetComponent<Light>().intensity = 0.3f;
                lighton = false;
            }

             
        }

    }










	// Update is called once per frame
	void Update () {
	
	}
}
