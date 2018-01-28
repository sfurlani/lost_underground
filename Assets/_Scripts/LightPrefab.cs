using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPrefab : MonoBehaviour {

	Rigidbody2D body;
	public Vector2 speed;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
		body.velocity = speed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("wut");
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
