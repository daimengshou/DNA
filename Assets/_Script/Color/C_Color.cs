﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Color : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //this.GetComponent<Renderer>().material.color = Color.green;
        this.GetComponent<Renderer>().material.color = new Color32(185,187, 110, 255);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
