using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour {

	public GameObject lightPrefab;
	public GameObject spawnPoint;
	public float relativeSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Fire",1.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire() {
		var light = Instantiate<GameObject>(lightPrefab,spawnPoint.transform.position, Quaternion.identity ,transform);
		//var model = light.GetComponent<LightPrefab>();
	}
}
