using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station {
	public bool vb;
	public bool p;
	public StationName s;
	public Background a;
}


public class DialogEvent {
	public Dialog[] dialog;
}

public class Dialog {
	public string s;
	public string t;
	public bool p = false;
	public string c = "";
}

public enum StationName {
	Town,
	Ville,
	City
}


public class GameEngine : MonoBehaviour {

	public GameObject stationObject;
	public GameObject dialogCanvas;

	private DialogController dialogController;
	private StationController stationController;

	public int stationIndex = 0; // so silly, load station 0 to start
	public int tunnelIndex = 0;

	// Use this for initialization
	void Start () {
		dialogController = dialogCanvas.GetComponent<DialogController>();
		stationController = stationObject.GetComponent<StationController>();

		Begin();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Begin() {
		Invoke("LoadNextTunnel",2);
	}

	public void LoadNextStation() {
		stationIndex++;
		Debug.Log("Loading Station "+stationIndex);
		Station station = stations[stationIndex-1];
		Debug.Log(station);
		stationController.LoadStation(station);
	}

	public void LoadNextTunnel() {
		tunnelIndex++;
		Debug.Log("Loading Tunnel "+tunnelIndex);
		DialogEvent startDialog = events[tunnelIndex-1];
		Debug.Log(startDialog);
		this.dialogController.StartDialog(startDialog);
	}
		
	private readonly Station[] stations = {
		new Station() {vb = true, p = false, s = StationName.Town, a = Background.Drip},
		new Station() {vb = false, p = true, s = StationName.Ville, a = Background.Traffic},
		new Station() {vb = false, p = false, s = StationName.City, a = Background.Busker},
		new Station() {vb = true, p = false, s = StationName.Ville, a = Background.Drip},
		new Station() {vb = false, p = true, s = StationName.City, a = Background.Traffic},
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
			new Dialog() {s = n, t = "Your phone begins to ring.", p = true, c = d},
			new Dialog() {s = y, t = "...!?", p = true, c = d},
			new Dialog() {s = y, t = "...Hello?", p = true, c = d},
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
			new Dialog() {s = s, t = "Your phone is ringing again.", p = true, c = s},
			new Dialog() {s = s, t = "You don't recognize the number.", p = true, c = s},
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
