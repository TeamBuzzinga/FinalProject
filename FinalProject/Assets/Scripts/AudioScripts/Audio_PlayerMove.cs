using UnityEngine;
using System.Collections;

public class Audio_PlayerMove : MonoBehaviour {

	public AudioClip Walk;
	public AudioClip Run;
	public AudioClip Throw;
	private AudioSource audioSource;
	private float footstepVolume = .5f;
	private float otherVolume = 1f;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void PlayWalk(){
		audioSource.clip = Walk;
		audioSource.pitch = Random.Range(1f,1.5f);
		audioSource.volume = footstepVolume;
		audioSource.Play ();
	}

	void PlayRun(){
		audioSource.clip = Run;
		audioSource.pitch = Random.Range(1f,1.5f);
		audioSource.volume = footstepVolume;
		audioSource.Play ();
	}

	void PlayThrow(){
		audioSource.clip = Throw;
		audioSource.volume = otherVolume;
		audioSource.Play ();
	}
}
