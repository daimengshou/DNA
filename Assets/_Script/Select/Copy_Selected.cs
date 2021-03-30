using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Copy_Selected : MonoBehaviour {

    public Toggle A ;
    public Toggle D;
    public Toggle C;

    public GameObject D_TEXT;
    public GameObject Error;

    public GameObject A_TEXT_2;
    public GameObject Error_2;

    public GameObject C_TEXT;
    public GameObject C_Error;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void D_Select(bool isOn)
    {

        if (D.isOn)
        {
            D_TEXT.SetActive(true);
            Error.SetActive(false);
        }
        if (!D.isOn)
        {
            D_TEXT.SetActive(false);
            Error.SetActive(true);
        }
    }

    public void A_Select_2(bool isOn)
    {

        if (A.isOn)
        {
            A_TEXT_2.SetActive(true);
            Error_2.SetActive(false);
        }
        if (!A.isOn)
        {
            A_TEXT_2.SetActive(false);
            Error_2.SetActive(true);
        }
    }

    public void C_Select(bool isOn)
    {

        if (C.isOn)
        {
            C_TEXT.SetActive(true);
            C_Error.SetActive(false);
        }
        if (!C.isOn)
        {
            C_TEXT.SetActive(false);
            C_Error.SetActive(true);
        }
    }
}
