using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class JianDao : MonoBehaviour {

    public GameObject Create;
    GameObject[] JJD;//碱基对

     public GameObject DNAPart; 


    List<GameObject> jjd = new List<GameObject>();
         int  index1 ;//int的默认值为0，切记，在做氢键断裂时应注意
         int   index2 ;

    // Use this for initialization
    void Start()
    {
        JJD = GameObject.FindGameObjectsWithTag("JJD").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
    }

    // Update is called once per frame
    void Update()
        {

       }

    private void OnTriggerEnter(Collider other)
    {
        Transform[] ALL =Create.GetComponentsInChildren<Transform>();
        for (int i = 0; i < JJD.Length; i++)
        {        
            jjd.Add(JJD[i].gameObject);
        }
        /////////////剪切磷酸二脂键，使得其断开//////////////////////
        /////////////每一侧的链只能剪切一侧，位点固定死了(不足点)///////////////////////////
        if (other.gameObject.name == "LSEZJ_L" && jjd.IndexOf(other.transform.parent.transform.parent.gameObject) == 2)
        {
            print("碰到L");
            index1 = jjd.IndexOf(other.transform.parent.transform.parent.gameObject);//获取所碰撞到物体在数组中的下标
            Create.GetComponent<Rotation>().enabled = false;//停止旋转
            Destroy(other.gameObject);//将碰撞到的磷酸二酯键删除
            foreach (Transform LSJ in ALL)
            {
                if (LSJ.transform.name == "LSEZJ_L")
                {
                    LSJ.GetComponent<CapsuleCollider>().enabled = false;//将处于同一侧的磷酸二脂键的碰撞体去除，控制一侧只能剪切一次
                }
            }
        }
        if (other.gameObject.name == "LSEZJ_R" && jjd.IndexOf(other.transform.parent.transform.parent.gameObject) == 6)
        {
            print("碰到R");
            index2 = jjd.IndexOf(other.transform.parent.transform.parent.gameObject);
            Destroy(other.gameObject);
            foreach (Transform LSJ in ALL)
            {
                if (LSJ.transform.name == "LSEZJ_R")
                {
                    LSJ.GetComponent<CapsuleCollider>().enabled = false;
                }
            }
        }


        #region 向下拉伸
        //if (index1 != 0 && index2 != 0)//限制int的默认值带来的影响,位点控制了，因此只要一种情况
        //{

        //    ////////////////////使得剪切后向下移动，为之后的DNA重组做准备
        //    for (int i = 0; i < index2 + 1; i++)
        //    {
        //        if (i < index1 + 1)
        //        {
        //            jjd[i].transform.localPosition = new Vector3(0, (i - 6) * 1.5f, 0);
        //        }
        //        if (i >= index1 + 1 && i < index2 + 1)
        //        {
        //            if (jjd[i].transform.name == "A_T test(Clone)")
        //            {
        //                float y = jjd[i].transform.Find("T").localPosition.y;

        //                jjd[i].transform.Find("T").localPosition = new Vector3(jjd[i].transform.Find("T").localPosition.x, jjd[i].transform.Find("T").position.y - 9f + 0.2480f, jjd[i].transform.Find("T").localPosition.z);//此处用了修正，不足处
        //            }
        //            if (jjd[i].transform.name == "T_A test (Clone)")
        //            {
        //                jjd[i].transform.Find("A").localPosition = new Vector3(jjd[i].transform.Find("A").localPosition.x, jjd[i].transform.Find("A").position.y - 9f + 0.2480f, jjd[i].transform.Find("A").localPosition.z);
        //            }
        //        }
        //    }
        //    if (index1 < index2)
        //    {
        //        DNAPart.SetActive(true);
        //        for (int i = index1 + 1; i < index2 + 1; i++)
        //        {

        //            Transform[] QJ = jjd[i].GetComponentsInChildren<Transform>();
        //            foreach (Transform qj in QJ)
        //            {
        //                if (qj.transform.name == "0" || qj.transform.name == "1" || qj.transform.name == "2")
        //                {
        //                    Destroy(qj.transform.gameObject);   //使氢键断裂

        //                }

        //            }
        //        }
        //    }
        //}
        #endregion



        if (index1 != 0 && index2 != 0)//限制int的默认值带来的影响,位点控制了，因此只要一种情况
        {


            if (index1 < index2)
            {
                DNAPart.SetActive(true);
                for (int i = index1 + 1; i < index2 + 1; i++)
                {
                    Transform[] QJ = jjd[i].GetComponentsInChildren<Transform>();
                    foreach (Transform qj in QJ)
                    {
                        if (qj.transform.name == "0" || qj.transform.name == "1" || qj.transform.name == "2")
                        {
                            Destroy(qj.transform.gameObject);   //使氢键断裂

                        }

                    }
                }
            }
            ////////////////////使得剪切后向下移动，为之后的DNA重组做准备
            for (int i = index1; i < index2 + 4; i++)
            {
           
                if (i > index2)
                {
                    jjd[i].transform.localPosition = new Vector3(0, (i + 6) * 1.5f, 0);
                }
                if (i >= index1 + 1 && i < index2 + 1)
                {
                    
                    if (jjd[i].transform.name == "A_T test(Clone)")
                    {
                         
                         jjd[i].transform.Find("A").localPosition = new Vector3(jjd[i].transform.Find("A").localPosition.x,0.248f+ 9f, jjd[i].transform.Find("A").localPosition.z);//此处用了修正，不足处
          
                    }
                    if (jjd[i].transform.name == "T_A test (Clone)")
                    {
                       
                        jjd[i].transform.Find("T").localPosition = new Vector3(jjd[i].transform.Find("T").localPosition.x, 0.248f+ 9f, jjd[i].transform.Find("T").localPosition.z);
                        
                    }
                }
            }
        }
    }
}
    

