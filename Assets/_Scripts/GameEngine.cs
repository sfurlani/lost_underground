using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public GameObject endingInjectorPrefab;

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
		stationController.music.GetComponent<BackgroundMusic>().playBackground(Background.Trains);
		Invoke("LoadNextTunnel",2);
	}

	public void LoadNextStation() {
		stationIndex++;
		if (stationIndex > stations.GetLength(0)) {
			NeverEnding();
			return;
		}
		Debug.Log("Loading Station "+stationIndex);
		Station station = stations[stationIndex-1];
		Debug.Log(station);
		stationController.LoadStation(station);
	}

	public void LoadNextTunnel() {
		tunnelIndex++;
		if (tunnelIndex > events.GetLength(0)) {
			NeverEnding();
			return;
		}
		Debug.Log("Loading Tunnel "+tunnelIndex);
		DialogEvent startDialog = events[tunnelIndex-1];
		Debug.Log(startDialog);
		this.dialogController.StartDialog(startDialog);
	}

	private void NeverEnding() {
		Debug.Log("Loading Never Ending");
		GameObject ending = Instantiate(endingInjectorPrefab);
		ending.GetComponent<Injector>().ending = Ending.Never;
		SceneManager.LoadScene("final");
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
	private static readonly string m = "Marcus";
	private static readonly string s = "???";

	private readonly DialogEvent[] events = new DialogEvent[] {
		tunnel0,
		tunnel1,
		tunnel2,
		tunnel3
	};

	public static readonly DialogEvent _tunnel0 = new DialogEvent() { dialog = new Dialog[] {
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

	public static readonly DialogEvent _tunnel1 = new DialogEvent() { dialog = new Dialog[] {
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


	public static readonly DialogEvent tunnel0 = new DialogEvent() { dialog = new Dialog[] {
			new Dialog() {s = y, t = "Where, where am I?"},	
			new Dialog() {s = y, t = "I'm on a subway?"},
			new Dialog() {s = n, t = "Your phone begins to ring.", p = true, c = d},
			new Dialog() {s = y, t = "...!?", p = true, c = d}, 
			new Dialog() {s = y, t = "...Hello?", p = true, c = d},
			new Dialog() {s = d, t = "Hi! **** did *** *** ** *** train ok?", p = true, c = d},
			new Dialog() {s = n, t = "The cell service is poor, and there is a lot of static on the line.", p = true, c = d},
			new Dialog() {s = y, t = "I think so...", p = true, c = d},
			new Dialog() {s = d, t = "Excellent! I ****** to call and *** ***** to ****-", p = true, c = d},
			new Dialog() {s = y, t = "I can't hear you, I'm underground...", p = true, c = d},
			new Dialog() {s = d, t = "OK! Jus*** ***mber: don't get off at the ***** with the broken vending **-", p = true, c = d},
			new Dialog() {s = n, t = "The line is dropped."},
		}
	};

public static readonly DialogEvent tunnel1 = new DialogEvent() { dialog = new Dialog[] {
			new Dialog() {s = n, t = "Your phone is ringing again.", p = true, c = s},
			new Dialog() {s = s, t = "You don't recognize the number.", p = true, c = s},
			new Dialog() {s = y, t = "...Hello?", p = true, c = s},
			new Dialog() {s = s, t = "Hello. Do you need help?", p = true, c = s},
			new Dialog() {s = n, t = "Unlike the call with your daughter, this voice comes through strong and clear.", p = true, c = s},
			new Dialog() {s = y, t = "Yes, I don't know where I am or where I'm supposed to go.", p = true, c = s},
			new Dialog() {s = s, t = "I can help you with that. Do not get off at Greenville.", p = true, c = s},
			new Dialog() {s = s, t = "Oh, ok thank-", p = true, c = s},
			new Dialog() {s = n, t = "The call abruptly ends."}
		}
	};

public static readonly DialogEvent tunnel2 = new DialogEvent() { dialog = new Dialog[] {
		new Dialog() {s = n, t = "An old friend, Marcus, is calling.", p = true, c = m},
		new Dialog() {s = m, t = "Do you remember ***************ville line? We were so *********stupid.", p = true, c = m},
		new Dialog() {s = y, t = "Marcus! Can you hear me?", p = true, c = m},
		new Dialog() {s = m, t = "****surprised we survived...", p = true, c = m},
		new Dialog() {s = y, t = "Marcus, do you know what stop I get off at? I'm lost.", p = true, c = m},
		new Dialog() {s = n, t = "Marcus is gone."}
	}
};

public static readonly DialogEvent tunnel3 = new DialogEvent() { dialog = new Dialog[] {
		new Dialog() {s = n, t = "Your ******** is calling again.", p = true, c = s},
		new Dialog() {s = d, t = "Da*, can you **ar me?", p = true, c = s},
		new Dialog() {s = y, t = "Who is this, hello? Can you help me? I'm lost.", p = true, c = s},
	new Dialog() {s = d, t = "Oh no. ***, what station are you at?", p = true, c = s},
new Dialog() {s = y, t = "I'm on the train going somewhere. We just passed a stop with a broken vending machine.", p = true, c = s},
new Dialog() {s = d, t = "Ok, good. Get off ****vil-- No wait, get off at ****town. I'll be there soon.", p = true, c = s},
new Dialog() {s = n, t = "They're gone."}
}
};

public static readonly DialogEvent tunnel4 = new DialogEvent() { dialog = new Dialog[] {
		new Dialog() {s = d, t = "Those buskers have really improved over the years, haven't they? ", p = true, c = d},
		new Dialog() {s = d, t = "Remember when you first moved? They were awful. I'm happy to see they never gave up.", p = true, c = d},
		new Dialog() {s = d, t = "It makes me happy to hear them still going at it whenever I pick you up.", p = true, c = d},
	new Dialog() {s = n, t = "The call drops."}
}
	};
}