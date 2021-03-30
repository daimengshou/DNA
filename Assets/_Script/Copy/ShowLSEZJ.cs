using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLSEZJ : MonoBehaviour {
    public GameObject DNA_TWO;


	// Use this for initialization
	void Start () {
        Transform[] JJD = DNA_TWO.GetComponentsInChildren<Transform>();


        foreach (Transform qj in JJD)
        {
            if (qj.transform.tag=="JJD_ONE_L")
            {
                if (qj.transform.name == "A_T")
                {
                    qj.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                }
                if (qj.transform.name == "T_A")
                {
                    qj.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                }
                if (qj.transform.name == "C_G")
                {
                    qj.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                }
                if (qj.transform.name == "G_C")
                {
                    qj.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                }
            }
            if (qj.transform.tag =="JJD_L")
            { 
            if (qj.transform.name == "A_T")
            {
                qj.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
            }
            if (qj.transform.name == "T_A")
            {
                qj.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
            }
            if (qj.transform.name == "C_G")
            {
                qj.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
            }
            if (qj.transform.name == "G_C")
            {
                qj.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
            }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
