using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {

    public bool lighton = true;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

	// Use this for initialization
	void Start () {
	    
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            light1.GetComponent<Light>().enabled = !light1.GetComponent<Light>().enabled;
            light2.GetComponent<Light>().enabled = !light2.GetComponent<Light>().enabled;
            light3.GetComponent<Light>().enabled = !light3.GetComponent<Light>().enabled;
            lighton = light1.GetComponent<Light>().enabled;
        }

    }










	// Update is called once per frame
	void Update () {
	
	}
}
