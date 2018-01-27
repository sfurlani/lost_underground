using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeFilter : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		animator.SetTrigger("OpenEyes");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
