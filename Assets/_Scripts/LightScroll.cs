using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScroll : MonoBehaviour {

	public float scrollSpeed = 0.5F;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * scrollSpeed * -1.0f;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
