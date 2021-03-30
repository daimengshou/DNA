using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Cut : MonoBehaviour {

    public GameObject MenuPanel;//简介的画布
    bool isOpen =true;
    public GameObject EcoRIQieDian;
    public GameObject SmaIQieDian;
    public GameObject Eco_cut;
    public GameObject SmaI_cut;



    public void  ecoCut() {
       Destroy(this .transform.Find("G_C(Clone)").transform.Find("G").transform.Find("LSEZJ_L").gameObject);
        GameObject a = GameObject.FindWithTag("1").transform.gameObject;
        Destroy(a.transform.Find("A").transform.Find("LSEZJ_R").gameObject);
        Transform[] ALL = this.GetComponentsInChildren<Transform>();
        foreach (Transform qj in ALL)
        {
            if (qj.transform.name == "QJ" && qj.transform.parent.transform.name != "G_C(Clone)" && qj.transform.parent.transform.name != "C_G(Clone)")
            {
                Destroy(qj.gameObject);
            }
        }
        EcoRIQieDian.SetActive(true);
        Eco_cut.GetComponent<Button>().enabled = false;

    }

    public void SmaICut()
    {
        GameObject b= GameObject.FindWithTag("2").transform.gameObject;
        Destroy(b.transform.Find("G").transform.Find("LSEZJ_R").gameObject);
        Destroy(b.transform.Find("C").transform.Find("LSEZJ_L").gameObject);
        SmaIQieDian.SetActive(true);
        SmaI_cut.GetComponent<Button>().enabled = false;
    }

    public void OpenMenu()
    {
        if (isOpen == false)
        {
            MenuPanel.transform.DOScale(Vector3.one,0.3f);
        }
        if (isOpen == true)
        {
            MenuPanel.transform.DOScale(new Vector3 (1,0,1), 0.3f);
        }
        isOpen =! isOpen;
    }

}
