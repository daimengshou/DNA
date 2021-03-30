using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        // if (other.transform.name == "A_R(Clone)" || other.transform.name == "T_R(Clone)" ||
        //other.transform.name == "C_R(Clone)" || other.transform.name == "G_R(Clone)" ||
        //other.transform.name == "A_L(Clone)" || other.transform.name == "T_L(Clone)" ||
        //other.transform.name == "C_L(Clone)" || other.transform.name == "G_L(Clone)")
        // {
        //     other.GetComponent<RandomRotateJianJi>().enabled = false;
        //     other.GetComponent<RandomMoveJianJi>().enabled = false;
        // }

        if (other.transform.name == "Cube")
        {
            //this .GetComponent<RandomRotateJianJi>().enabled = false;
            //this .GetComponent<RandomMoveJianJi>().enabled = false;
            print("碰到了");
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
