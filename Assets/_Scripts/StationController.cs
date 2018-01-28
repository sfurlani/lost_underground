using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour {

	public GameObject gameEngineObject;
	private GameEngine gameEngine;

	private Station currentStation;
	private Animator animator;

	public GameObject pillars;
	public GameObject vending;
	public GameObject broken;
	public GameObject sign;


	// Use this for initialization
	void Start () {
		gameEngine = gameEngineObject.GetComponent<GameEngine>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadStation(Station station) {
		currentStation = station;
		pillars.SetActive(currentStation.p);
		vending.SetActive(!currentStation.vb);
		broken.SetActive(currentStation.vb);
		animator.SetTrigger("Stop");
	}
}
