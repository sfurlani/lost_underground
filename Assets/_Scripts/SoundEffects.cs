using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundEffect {
	DoorOpen,
	DoorClose,
	PhoneRing,
	Click
}

public class SoundEffects : MonoBehaviour {

	public AudioSource source;

	public AudioClip open;
	public AudioClip close;
	public AudioClip ring;
	public AudioClip click;

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playSFX(SoundEffect effect) {
		switch ( effect) {
		case SoundEffect.Click:
			source.clip = click;
			break;
		case SoundEffect.DoorOpen:
			source.clip = open;
			break;
		case SoundEffect.DoorClose:
			source.clip = close;
			break;
		case SoundEffect.PhoneRing:
			source.clip = ring;
			break;
		default:
			return;
		}
		source.Play();
	}
}
