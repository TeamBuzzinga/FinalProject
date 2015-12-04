using UnityEngine;
using System.Collections;

public class Audio_PlayerMove : MonoBehaviour {

	public AudioClip Walk;
	public AudioClip Run;
	public AudioClip Throw;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	void PlayWalk(){
		audioSource.clip = Walk;
		audioSource.Play ();
	}

	void PlayRun(){
		audioSource.clip = Run;
		audioSource.Play ();
	}

	void PlayThrow(){
		audioSource.clip = Throw;
		audioSource.Play ();
	}
}
