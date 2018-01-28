using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

	public GameObject dialogObject;
	private DialogController dialogController;

	// Use this for initialization
	void Start () {
		dialogController = dialogObject.GetComponent<DialogController>();
		gameObject.GetComponent<Button>().onClick.AddListener(TapCallback);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TapCallback() {

	}
}
