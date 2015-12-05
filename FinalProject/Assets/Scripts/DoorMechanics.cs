using UnityEngine;
using System.Collections;

public class DoorMechanics : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			anim.SetBool("Open", true);
		}
	}
	public void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			anim.SetBool("Open", false);
		}
	}
}
