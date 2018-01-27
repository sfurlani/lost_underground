using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

	private int	Stations = 5;
	private int Tunnels = 5;

	public GameObject stationPrefab;
	public GameObject tunnelPrefab;

	public GameObject currentLocation; // tunnel or station

	public GameObject stationCanvas;
	public GameObject tunnelCanvas;

	private GameObject[] allStations;
	private GameObject[] allTunnels;

	// Use this for initialization
	void Start () {
		
		allStations = new GameObject[Stations];
		for (var i = 0; i < Stations; i++) {
			var station = Instantiate<GameObject>(stationPrefab, transform);
			var data = station.GetComponent<StationDataModel>();
			data.vending = GameData.vendings[i];
			data.lurch = GameData.lurches[i];
			data.suffix = GameData.suffixes[i];
			data.audio = GameData.audio[i];
		}

		allTunnels = new GameObject[Tunnels];
		for (var i = 0; i < Tunnels; i++) {
			
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

struct GameData {
	public static readonly bool[] vendings = {true, false, true, false, true};
	public static readonly bool[] lurches = {false, true, true, false, true};
	public static readonly string[] suffixes = {"town", "ville", "ville", "city", "town"};
	public static readonly string[] audio = {"music", "traffic", "music", "water", "quiet"};
}
