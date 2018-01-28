using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationController : MonoBehaviour {

	public GameObject gameEngineObject;
	private GameEngine gameEngine;

	private Station currentStation;
	private Animator animator;

	public GameObject pillars;
	public GameObject vending;
	public GameObject broken;

	public GameObject doors;

	public GameObject city;
	public GameObject town;
	public GameObject ville;

	public GameObject music;
	private BackgroundMusic musicController;

	public GameObject sfx;
	private SoundEffects sfxController;

	// Use this for initialization
	void Start () {
		gameEngine = gameEngineObject.GetComponent<GameEngine>();
		animator = gameObject.GetComponent<Animator>();
		musicController = music.GetComponent<BackgroundMusic>();
		sfxController = sfx.GetComponent<SoundEffects>();
		musicController.playBackground(Background.Trains);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadStation(Station station) {
		currentStation = station;
		pillars.SetActive(currentStation.p);
		vending.SetActive(!currentStation.vb);
		broken.SetActive(currentStation.vb);
		city.SetActive(false);
		town.SetActive(false);
		ville.SetActive(false);
		switch (station.s) {
		case StationName.City:
			city.SetActive(true);
			break;
		case StationName.Town:
			town.SetActive(true);
			break;
		default:
		case StationName.Ville:
			ville.SetActive(true);
			break;
		}
		animator.SetTrigger("Stop");
	}

	public void StopEvent() {
		doors.GetComponent<Animator>().SetTrigger("Open");
		sfxController.playSFX(SoundEffect.DoorOpen);
		musicController.playBackground(currentStation.a);
		Invoke("CloseDoor",10.0f);
	}

	public void CloseDoor() {
		sfxController.playSFX(SoundEffect.DoorClose);
		doors.GetComponent<Animator>().SetTrigger("Close");
		Invoke("StartTrain",1.0f);
	}

	public void StartTrain() {
		animator.SetTrigger("Start");
		musicController.playBackground(Background.Trains);
	}

	public void RunningEvent() {
		gameEngine.LoadNextTunnel();
	}
}
