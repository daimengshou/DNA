using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//做场景加载时必须引用的
using UnityEngine.UI;

public class PeiDui : MonoBehaviour {

    public GameObject A;
    public GameObject T;
    public GameObject C;
    public GameObject G;

    public GameObject ABtn;
    public GameObject TBtn;
    public GameObject CBtn;
    public GameObject GBtn;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void A_Create()
    {
        A.SetActive(true);
        ABtn.GetComponent<Button>().enabled = false;
    }

    public void T_Create()
    {
        T.SetActive(true);
        TBtn.GetComponent<Button>().enabled = false;
    }

    public void C_Create()
    {
        C.SetActive(true);
        CBtn.GetComponent<Button>().enabled = false;
    }

    public void G_Create()
    {
        G.SetActive(true);
        GBtn.GetComponent<Button>().enabled = false;
    }

    public void Next()
    {
        SceneManager.LoadScene("Error"); 
    }

    public void Return()
    {
        SceneManager.LoadScene("3D_DNA");
    }
    public void Reload()
    {
        SceneManager.LoadScene("Peidui");
    }
}
