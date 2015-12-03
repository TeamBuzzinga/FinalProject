using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	// Use this for initialization
    Vector3 _rotate;
    public float speed=5;
    ParticleSystem[] p_systems;
	void Start () {
        _rotate = new Vector3(0,90,0);
        p_systems = GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
       if(p_systems[0].isPlaying)
            transform.Rotate(_rotate * speed * Time.deltaTime);
       
	}
}
