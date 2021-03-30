using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using DG.Tweening;

public class MovePosition : MonoBehaviour
{
    GameObject[] JJD;//碱基对
    List<GameObject> jjd = new List<GameObject>();
    GameObject[] DP;//DNA片段碱基对
    List<GameObject> dp = new List<GameObject>();
     GameObject Create;
    /// <summary>
    /// 空物体存放上半部的黏性末端
    /// </summary>
    //public GameObject A_T;
    //public GameObject A_T1;
    //public GameObject T_A;
    //public GameObject T_A1;

    GameObject A_T_NEW;
    GameObject A_T1;
    GameObject T_A_NEW;
    GameObject T_A1;

    // Use this for initialization
    void Start()
    {
        Create = this.GetComponent<CreateDNAPart>().create;
        Transform[] QJ = Create.GetComponentsInChildren<Transform>();
        foreach (Transform qj in QJ)
        {
            if (qj.transform.name == "A_T")
            {
                A_T_NEW = qj.transform.gameObject;
            }
            if (qj.transform.name == "A_T1")
            {
                A_T1 = qj.transform.gameObject;
            }
            if (qj.transform.name == "T_A")
            {
                T_A_NEW = qj.transform.gameObject;
            }
            if (qj.transform.name == "T_A1")
            {
                T_A1 = qj.transform.gameObject;
            }
        }
     //   Create.transform.DOMove(new Vector3(0f, -0.55f, 2.3f), 10f);
        JJD = GameObject.FindGameObjectsWithTag("JJD").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
        DP = GameObject.FindGameObjectsWithTag("DP").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
        for (int i = 0; i < JJD.Length; i++)
        {
            jjd.Add(JJD[i].gameObject);
        }

        for (int i = 0; i < DP.Length; i++)
        {
            dp.Add(DP[i].gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.name == "A_T test(Clone)" || other.transform.name == "T_A test (Clone)") && (jjd.IndexOf(other.transform.gameObject) == 3 || jjd.IndexOf(other.transform.gameObject) == 4 || jjd.IndexOf(other.transform.gameObject) == 5 || jjd.IndexOf(other.transform.gameObject) == 6))
        {
            this.GetComponent<MoveMei>().enabled = false;
            for (int i = 0; i < DP.Length; i++)
            {
                dp[i].transform.parent = Create.transform;
            }
            ////////////////////////////////用于处理上半部分黏性末端的角度问题/////////////
            GameObject.FindWithTag("A").transform.parent = A_T_NEW.transform;
            A_T_NEW.transform.localRotation = Quaternion.Euler(0, -144, 0);
            GameObject.FindWithTag("A1").transform.parent = A_T1.transform;
            A_T1.transform.localRotation = Quaternion.Euler(0, -144, 0);
            GameObject.FindWithTag("T").transform.parent = T_A_NEW.transform;
            T_A_NEW.transform.localRotation = Quaternion.Euler(0, -144, 0);
            GameObject.FindWithTag("T1").transform.parent = T_A1.transform;
            T_A1.transform.localRotation = Quaternion.Euler(0, -144, 0);
            ///////////////////////////////////////////////////////////////////////////////

            ///////////////////////将DNA片段放置特定位置
            for (int i = 0; i < DP.Length; i++)
            {
          
                dp[i].transform.parent = Create.transform;

            }

            //////////////对于另一端的碱基对进行正确的旋转
            for (int i = 7; i < 10; i++)
            {
                jjd[i].transform.localRotation = Quaternion.Euler(0, (i + 6) * 36, 0);
            }
            /////////对于DNA片段在下端的黏性末端进行正确的摆放
            //for (int i = 0; i < 4; i++)
            //{
            //    dp[i].transform.position = jjd[i+3].transform.position;
            //    dp[i].transform.localRotation = jjd[i+3].transform.localRotation;
            //}

            //////////////////////DNA片段中的完整的碱基对拜访
            //for (int i = 0; i <6; i++)
            //{
            //    dp[i].transform.localPosition = new Vector3(0,(i+3)*1.5f, 0);
            //    dp[i].transform.localRotation = Quaternion.Euler(0,(i+3)*36, 0); 
            //}
            for (int i = 0; i < DP.Length; i++)
            {
                dp[i].transform.localPosition = new Vector3(0, (i + 3) * 1.5f, 0);
                dp[i].transform.localRotation = Quaternion.Euler(0, (i + 3) * 36, 0);
                //if (dp[i].transform.name == "A_T test(Clone)" || dp[i].transform.name == "T_A test (Clone)" || dp[i].transform.name == "C_G test(Clone)" || dp[i].transform.name == "G_C test(Clone)")
                //{
                //    dp[i].transform.Find("QJ").transform.Find("0").transform.localScale = new Vector3(0.08f, 0.637f, 0.08f);
                //    dp[i].transform.Find("QJ").transform.Find("1").transform.localScale = new Vector3(0.08f, 0.637f, 0.08f);
                //    dp[i].transform.Find("QJ").transform.Find("2").transform.localScale = new Vector3(0.08f, 0.637f, 0.08f);
                //}
           //    Create.GetComponent<Rotation>().enabled = true;   
            }
  
        }

    }

}
