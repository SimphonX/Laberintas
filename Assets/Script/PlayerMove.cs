﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMove : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
		var x = Input.GetAxis("Horizontal")*0.05f;
		var y = Input.GetAxis("Vertical")*0.05f;
		
		transform.Translate(x, y, 0);
	}
}
