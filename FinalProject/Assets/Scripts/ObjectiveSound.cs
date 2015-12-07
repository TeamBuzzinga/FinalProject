using UnityEngine;
using System.Collections;

public class ObjectiveSound : MonoBehaviour {

	public int sound;
	public AudioClip Key;
	public AudioClip Fruit;
	public AudioClip Switch;

	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		sound = 0;
	}
	// Update is called once per frame
	void Update () {
		PlaySound ();
	}

	public void setSound (int i) {
		sound = i;
	}

	void PlaySound() {
		if (sound == 1) {
			audioSource.clip = Key;
			audioSource.Play ();
			sound = 0;
		} else if (sound == 2) {
			audioSource.clip = Fruit;
			audioSource.Play ();
			sound = 0;
		} else if (sound == 3) {
			audioSource.clip = Switch;
			audioSource.Play ();
			sound = 0;
		}
	}

}
