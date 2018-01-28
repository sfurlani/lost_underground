using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

	public GameObject gameEngineObject;
	private GameEngine gameEngine;

	private DialogEvent currentDialog;
	private int dialogIndex = 0;

	public GameObject phone;
	public GameObject caller;
	public GameObject speaker;
	public GameObject dialog;
	public GameObject textBox;
	public GameObject background;

	private Text callerText;
	private Text speakerText;
	private Text dialogText;

	private bool hasRung = false;
	public GameObject sfx;
	private SoundEffects sfxController;


	// Use this for initialization
	void Start () {
		callerText = caller.GetComponent<Text>();
		speakerText = speaker.GetComponent<Text>();
		dialogText = dialog.GetComponent<Text>();
		gameEngine = gameEngineObject.GetComponent<GameEngine>();
		sfxController = sfx.GetComponent<SoundEffects>();

		background.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartDialog(DialogEvent dialogEvent) {
		dialogIndex = 0;
		hasRung = false;
		this.currentDialog = dialogEvent;
		background.SetActive(true);
		LoadFrame(this.currentDialog.dialog[dialogIndex]);
	}

	public void LoadFrame(Dialog dialog) {
		
		if (dialog.s == "") {
			speakerText.text = dialog.s;
			callerText.text = dialog.c;
		    dialogText.text = dialog.t;
		} else {
			speakerText.text = dialog.s + ":";
			callerText.text = dialog.c;
			dialogText.text = "\"" + dialog.t + "\"";
		}
		phone.SetActive(dialog.p);
		caller.SetActive(dialog.p);
		if (!hasRung && dialog.p) {
			sfxController.playSFX(SoundEffect.PhoneRing);
			hasRung = true;
		}
	}

	public void LoadNext() {
		//Debug.Log("Load Next");
		dialogIndex++;
		if ( dialogIndex >= currentDialog.dialog.Length ) {
			EndDialog();
			return;
		}
		LoadFrame(currentDialog.dialog[dialogIndex]);
	}

	public void EndDialog() {
		background.SetActive(false);
		Debug.Log("End Dialog");
		gameEngine.LoadNextStation();
	}
}
