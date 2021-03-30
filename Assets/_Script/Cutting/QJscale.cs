using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QJscale : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform[] JJD = this.GetComponentsInChildren<Transform>();
        foreach (Transform qj in JJD)
        {
            if (qj.transform.name == "0" || qj.transform.name == "1" || qj.transform.name == "2")
            {
                qj.transform.localScale = new Vector3(0.08F, 0.637F, 0.08F);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
