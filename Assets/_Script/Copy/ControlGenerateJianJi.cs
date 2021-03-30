using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------
//此脚本用来控制产生随机游离碱基的数量
//-------------------------------------

public class ControlGenerateJianJi : MonoBehaviour {

    Transform[] JianJi;//用来获取子物体体存放的数组
    List<Transform> JianJiTf = new List<Transform>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        JianJi = this.GetComponentsInChildren<Transform>();//获取该物体下所有的子物体
        ControlJianJiNumbers(JianJi);
       
	}


    void ControlJianJiNumbers(Transform[] JianJi)
    {
        foreach(Transform tf in JianJi)
        {
            //print(tf.transform.name);
            if (tf.transform.name == "A_R(Clone)" || tf.transform.name == "T_R(Clone)" ||
               tf.transform .name == "C_R(Clone)" || tf.transform .name == "G_R(Clone)" ||
               tf.transform .name == "A_L(Clone)" || tf.transform .name == "T_L(Clone)" ||
               tf.transform.name == "C_L(Clone)" || tf.transform .name == "G_L(Clone)")
            {
                JianJiTf.Add(tf.transform);

                // print(JianJiTf.Count);
                //for (int i = 0; i < JianJiTf.Count; i++)
                //{

                //    print(JianJiTf[i].transform.name);
                //}
                if (JianJiTf.Count >1000.0f)
                {
                    //print("到了限制条件了");
                    this.gameObject.GetComponent<CreateYouLiJianJi>().enabled = false;
                }
            }

        }
        
    }

}
