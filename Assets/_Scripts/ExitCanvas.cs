using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Ending {
	Good,
	Lost,
	Never,
	Bad
}

public class ExitCanvas : MonoBehaviour {

	public GameObject exitGroup;
	public GameObject exitDialog;
	public GameObject closeEyesObject;

	private Text exitDialogText;

	private string[] currentEnding;
	private int currentIndex;

	// Use this for initialization
	void Start () {
		exitDialogText = gameObject.GetComponent<Text>();
		exitGroup.SetActive(false);
		closeEyesObject.SetActive(false);
		Invoke("StartDialog",1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartDialog () {
		
		Injector inj = FindObjectOfType<Injector>();
		if (inj == null) {
			Debug.Log("Could Not Find Injector");
			return;
		}

		switch (inj.ending) {
		case Ending.Good:
			currentEnding = goodEnding;
			break;
		case Ending.Bad:
			currentEnding = badEnding;
			break;
		case Ending.Never:
			currentEnding = neverEnding;
			break;
		case Ending.Lost:
			currentEnding = lostEnding;
			break;
		}
		Destroy(inj.gameObject); // now that we've read it, remove it
		exitDialogText.text = "";
		exitGroup.SetActive(true);
		AdvanceDialog();
	}

	public void AdvanceDialog () {
		
		currentIndex++;
		if (currentIndex > currentEnding.GetLength(0)) {
			exitGroup.SetActive(false);
			closeEyesObject.SetActive(true);
		}
		exitDialogText.text = currentEnding[currentIndex-1];
	}

	private string[] goodEnding = {
		"As you step out of the station",
		"You are greeted by",
		"The warm smiling faces of your daughter and her family",
		"You hug, step into the car, and enjoy the peaceful ride back to their house",
		"It is so peaceful, in fact, that you begin to fall asleep..."
	};

	private string[] neverEnding = {
		"You continue to ride the subway car down the tracks",
		"It takes you a few minutes, but you realize the next stop is much farther apart than the last",
		"You wait for five, ten, fifteen minutes...",
		"But still the train does not stop",
		"Panic sets in and you try to find the emergency stop",
		"Or pry the doors open",
		"Or smash the windows",
		"Exausted, You sit in the eerie glow of the car, for hours",
		"Finally the exaustion overtakes you..."
	};

	private string[] lostEnding = {
		"As you step out of the station",
		"You are greeted by",
		"the unfamiliar sights of a city you've never been in before",
		"You try to make calls on your phone but the battery is dead",
		"You try to ask people for help but they all shove you off as some kind of beggar",
		"You end up sitting along in the dark on a park bench",
		"Exausted from your search, you slump over..."
	};

	private string[] badEnding = {
		"As you step out of the station",
		"You are greeted by",
		"A young man you... sort of recognize",
		"He introduces himself and then you immediately recognize his voice from the phone",
		"He offers to drive you to your family's house",
		"You thank him - he has been nothing but helpful and kind",
		"Sitting in the back seat of his car, the stress of the train ride is slowly melting away",
		"You find your eyes heavy as a gentle peace overcomes you..."
	};
}


