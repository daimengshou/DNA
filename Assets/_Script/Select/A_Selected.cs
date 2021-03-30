using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_Selected : MonoBehaviour {

    public Toggle A ;
    public Toggle D;
    public Toggle A1;

    public GameObject A_TEXT;
    public GameObject Error;

    public GameObject A_TEXT_2;
    public GameObject Error_2;

    public GameObject D_TEXT;
    public GameObject D_Error;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void A_Select(bool isOn)
    {

        if (A.isOn)
        {
            A_TEXT.SetActive(true);
            Error.SetActive(false);
        }
        if (!A.isOn)
        {
            A_TEXT.SetActive(false);
            Error.SetActive(true);
        }
    }

    public void A_Select_2(bool isOn)
    {

        if (A1.isOn)
        {
            A_TEXT_2.SetActive(true);
            Error_2.SetActive(false);
        }
        if (!A1.isOn)
        {
            A_TEXT_2.SetActive(false);
            Error_2.SetActive(true);
        }
    }

    public void D_Select(bool isOn)
    {

        if (D.isOn)
        {
            D_TEXT.SetActive(true);
            D_Error.SetActive(false);
        }
        if (!D.isOn)
        {
            D_TEXT.SetActive(false);
            D_Error.SetActive(true);
        }
    }
}
