using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_color : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // this.GetComponent<Renderer>().material.color = Color.blue;
        this.GetComponent<Renderer>().material.color = new Color32(34,200,177,255);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
