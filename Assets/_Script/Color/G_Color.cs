using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Color : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // this.GetComponent<Renderer>().material.color = Color.red;
       this.GetComponent<Renderer>().material.color = new Color32(250,100,112,255);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
