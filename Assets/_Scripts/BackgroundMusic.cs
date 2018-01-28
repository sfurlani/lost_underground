using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Background {
	Trains,
	Busker,
	Drip,
	Traffic,
	None
}

public class BackgroundMusic : MonoBehaviour {

	private AudioSource source;

	public AudioClip tracks;
	public AudioClip busker;
	public AudioClip drips;
	public AudioClip traffic;

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playBackground(Background bg) {
		if (source.isPlaying) {
			source.Stop();
		}
		switch (bg) {
		case Background.Trains:
			source.clip = tracks;
			break;
		case Background.Traffic:
			source.clip = traffic;
			break;
		case Background.Drip:
			source.clip = drips;
			break;
		case Background.Busker:
			source.clip = busker;
			break;
		default:
			// don't play anything
			return;
		}
		source.Play();
	}
}
