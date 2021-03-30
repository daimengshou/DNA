using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//用到UI组件时，需要引用

public class A_OnTrigger : MonoBehaviour
{

    public GameObject A_T;
    public GameObject A;
    public GameObject T;
    public Text AT_Text;
    public GameObject AT;
    //public Camera ARCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.ToString() == "T碱基")
        {
         //   Vector3 Pos = this.gameObject.transform.position;
           // Vector3 Pos =ARCamera. GetComponent <Transform>().position;
            A.SetActive(false);
            T.SetActive(false);

            other.gameObject.SetActive(false);
          GameObject AT_Ins=Instantiate(A_T,new Vector3(3f,3F,0),Quaternion.identity);//碰撞后实例一个AT整体
            AT_Ins.transform.localScale =Vector3.one;
           

            AT_Text.text = this.gameObject.name.ToString() + "与" + other.gameObject.name.ToString() + "匹配成功";
            AT.SetActive(true);

        }
        if (other.gameObject.name.ToString() == "C碱基" || other.gameObject.name.ToString() == "G碱基")
        {
            AT_Text.text = this.gameObject.name.ToString() + "与" + other.gameObject.name.ToString() + "不匹配";
        }
    }


}
