using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour {
    public AudioClip[] aClips = new AudioClip[0];
    int currentTrack;
    AudioSource aSource;

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}

    public void playSound()
    {
        aSource.Stop();
        if (aClips.Length > 0)
        {
            aSource.clip = aClips[currentTrack];
        }
        aSource.Play();
    }

    public void playRandomizedPitch(float min, float max)
    {
        setPitch(Random.Range(min, max));
        playSound();
    }

    public void stopSound()
    {
        aSource.Stop();
    }

    public void setLoopOn(bool loopOn)
    {
        aSource.loop = loopOn;
    }

    public void setCurrentTrack(int currentTrack)
    {
        this.currentTrack = currentTrack;
    }

    public void setVolume(float volume)
    {
        aSource.volume = volume;
    }

    public void setPitch(float pitch)
    {
        aSource.pitch = pitch;
    }
}
