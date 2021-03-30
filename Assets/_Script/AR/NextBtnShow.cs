using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextBtnShow : MonoBehaviour {

    public Text AT_Text;
    public Text CG_Text;
    public Button NextBtn;

	// Use this for initialization
	void Start ()
    {
        NextBtn.transform.localScale = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (AT_Text.text.ToString() == "A碱基与T碱基匹配成功" && CG_Text.text.ToString() == "C碱基与G碱基匹配成功")
        {
            NextBtn.transform.localScale = Vector3.one;
        }
	}
}
