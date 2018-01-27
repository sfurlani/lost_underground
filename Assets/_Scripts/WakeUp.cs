using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUp : MonoBehaviour {

	Animator animator;
	Button button;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(Fade);
		Debug.Log("I was made");
	}

	void Fade () {
		animator.SetTrigger("Fade");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
