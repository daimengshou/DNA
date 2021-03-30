using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Color : MonoBehaviour {

	// Use this for initialization
	void Start () {
     // this.GetComponent<Renderer>().material.color = Color.grey;
      this.GetComponent<Renderer>().material.color = new Color32(229,226,217,255);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
