using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_OnTrigger : MonoBehaviour {

    public GameObject C_G;
    public GameObject C;
    public GameObject G;
    public Text CG_Text;
    public GameObject CG;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.ToString() == "G碱基")
        {
          // Vector3 Pos= this.gameObject.transform.position;

            C.SetActive(false);
            G.SetActive(false);
          GameObject CG_Ins=  Instantiate(C_G,new Vector3(3f,-1f,0), Quaternion.identity);//碰撞后实例化的一个整体CG
            CG_Ins.transform.localScale =Vector3.one;
        

            CG_Text.text = this.gameObject.name.ToString() + "与" + other.gameObject.name.ToString() + "匹配成功";
            CG.SetActive(true);
        }
        if (other.gameObject.name.ToString() == "A碱基" || other.gameObject.name.ToString() == "T碱基")
        {
            CG_Text.text = this.gameObject.name.ToString() + "与" + other.gameObject.name.ToString() + "不匹配";
        }
    }


}


