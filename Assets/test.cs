﻿using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetButtonDown("Fire1")){
			transform.position=new Vector3(0,0,0);
		}
	}
}
