using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station {
	public bool vb;
	public bool p;
	public StationName s;
	public string a;
}


public class DialogEvent {
	public Dialog[] dialog;
}

public class Dialog {
	public string s;
	public string t;
	public bool p = false;
}

public enum StationName {
	Town,
	Ville,
	City
}


public class GameEngine : MonoBehaviour {

	public GameObject currentStation;
	public GameObject currentTunnel;
	public GameObject dialogCanvas;

	private DialogController dialogController;

	public int stationIndex = 0;
	public int tunnelIndex = 0;

	// Use this for initialization
	void Start () {
		dialogController = dialogCanvas.GetComponent<DialogController>();
		Invoke("Begin",2);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Begin() {
		DialogEvent startDialog = events[tunnelIndex];
		Debug.Log(startDialog);
		this.dialogController.StartDialog(startDialog);
	}
		
	private readonly Station[] stations = {
		new Station() {vb = true, p = false, s = StationName.Town, a = "none"},
		new Station() {vb = false, p = true, s = StationName.Ville, a = "none"},
		new Station() {vb = false, p = false, s = StationName.City, a = "none"},
		new Station() {vb = true, p = false, s = StationName.Ville, a = "none"},
		new Station() {vb = false, p = true, s = StationName.City, a = "none"},
	};

	private static readonly string n = ""; // Narrator
	private static readonly string y = "You";
	private static readonly string d = "Daughter";
	private static readonly string s = "???";

	private readonly DialogEvent[] events = new DialogEvent[] {
		tunnel0,
		tunnel1
	};

	public static readonly DialogEvent tunnel0 = new DialogEvent() { dialog = new Dialog[] {
			new Dialog() {s = y, t = "Where, where am I?"},	
			new Dialog() {s = y, t = "I'm on a subway?"},
			new Dialog() {s = n, t = "Your phone begins to ring.", p = true},
			new Dialog() {s = y, t = "...!?", p = true},
			new Dialog() {s = y, t = "...Hello?", p = true},
			new Dialog() {s = d, t = "Hi! **** did *** *** ** *** train ok?"},
			new Dialog() {s = n, t = "The cell service is poor, and there is a lot of static on the line."},
			new Dialog() {s = y, t = "I think so..."},
			new Dialog() {s = d, t = "Excellent! I ****** to call and *** ***** to ****-"},
			new Dialog() {s = y, t = "I can't hear you, I'm underground..."},
			new Dialog() {s = d, t = "OK! Jus*** ***mber: don't get off at the ***** with the broken vending **-"},
			new Dialog() {s = n, t = "The line is dropped."},
		}
	};

	public static readonly DialogEvent tunnel1 = new DialogEvent() { dialog = new Dialog[] {
			new Dialog() {s = s, t = "Your phone is ringing again.", p = true},
			new Dialog() {s = s, t = "You don't recognize the number.", p = true},
			new Dialog() {s = y, t = "...Hello?"},
			new Dialog() {s = s, t = "Hello. Do you need help?"},
			new Dialog() {s = n, t = "Unlike the call with your daughter, this voice comes through strong and clear."},
			new Dialog() {s = y, t = "Yes, I don't know where I am or where I'm supposed to go."},
			new Dialog() {s = s, t = "I can help you with that. Do not get off at Greenville."},
			new Dialog() {s = s, t = "Oh, ok thank-"},
			new Dialog() {s = n, t = "The call abruptly ends."}
		}
	};
}
