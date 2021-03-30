using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//做场景加载时必须引用的

public class SelectType : MonoBehaviour {

    public Text TopText;
    public GameObject Error;
    public GameObject B_DNA;
    public GameObject A_DNA;
    public Button ClearBtn;
    public Toggle A_Toggle;
    public Toggle B_Toggle;
    public Text ErrorText;
    public GameObject main_camera;
    public GameObject Buzou;
    public GameObject ReturnBtn;
    public GameObject Arrow;
    public GameObject Text;
    public GameObject Name;
    public GameObject Exit1;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void A_Selected(bool isOn)
    {
        B_Toggle.GetComponent<Toggle>().enabled = false;
        if (isOn)
        {
            TopText.text = "A_DNA";
            Error.GetComponent<A_RandomCreate>().enabled = true;
            Camera.main.GetComponent<A_GetObject>().enabled = true;
            Camera.main.GetComponent<B_GetObject>().enabled = false;
        }
    }
    public void B_Selected(bool isOn)
    {
        A_Toggle.GetComponent<Toggle>().enabled = false;
        if (isOn)
        {
            TopText.text = "B_DNA";
            Error.GetComponent<B_RandomCreate>().enabled = true;
            Camera.main.GetComponent<B_GetObject>().enabled = true;
            Camera.main.GetComponent<A_GetObject>().enabled = false;
        }
    }

    public void CLear()
    {
        Destroy(Name.gameObject);
        ErrorText.enabled = false;
        Destroy(ClearBtn.gameObject);
        Destroy(Buzou.gameObject);
        TopText.transform.gameObject.SetActive(true);
        Error.transform.position = new Vector3(-9.5f, -2, 0);
        Destroy(A_Toggle.gameObject);
        Destroy(B_Toggle.gameObject);
        Destroy(ReturnBtn.gameObject);
        Arrow.SetActive(true);
        Text.SetActive(true);
        Destroy(Exit1.gameObject);
        if (A_Toggle.isOn)
        {
            A_DNA.SetActive(true);
            B_DNA.SetActive(false);
            main_camera.GetComponent<A_GetObject>().enabled = false;
            main_camera.GetComponent<A_Move>().enabled = true;
            Destroy(A_Toggle.gameObject);
            Destroy(B_Toggle.gameObject);

        }
        if (B_Toggle.isOn)
        {
            B_DNA.SetActive(true);
            A_DNA.SetActive(false);
            Destroy(A_Toggle.gameObject);
            Destroy(B_Toggle.gameObject);
            main_camera.GetComponent<B_GetObject>().enabled = false;
            main_camera.GetComponent<B_Move>().enabled = true;
        }
        Transform[] jjd = Error.GetComponentsInChildren<Transform>();
        foreach (Transform JJD in jjd)
        {
            if (JJD.transform.name == "A_L(Clone)" || JJD.transform.name == "T_L(Clone)" || JJD.transform.name =="C_L(Clone)" || JJD.transform.name == "G_L(Clone)"
                || JJD.transform.name == "A_R(Clone)" || JJD.transform.name == "T_R(Clone)" || JJD.transform.name == "C_R(Clone)" || JJD.transform.name == "G_R(Clone)"
                || JJD.transform.name == "A碱基" || JJD.transform.name == "T碱基" || JJD.transform.name == "C碱基" || JJD.transform.name == "G碱基"
                )
            {
                JJD.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (JJD .transform.name == "Cylinder" || JJD .transform.name == "Cylinder (1)" || JJD .transform.name == "Cylinder (2)"
               || JJD .transform.name == "0" ||JJD .transform.name == "1" || JJD .transform.name == "2"
             )
            {
               JJD.GetComponent<CapsuleCollider>().enabled = false;
            }
            if (JJD.transform.name == "磷酸")
            {
                JJD.GetComponent<SphereCollider>().enabled = false;
            }
        }
    }

    public void ReLoad()
    {
        SceneManager.LoadScene("Error");
    }
    public void Return()
    {
        SceneManager.LoadScene("Peidui");
    }

    public void Next()
    {
        SceneManager.LoadScene("Error_problem");

    }
}
