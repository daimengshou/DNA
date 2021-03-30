using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class MovePos : MonoBehaviour
{

    GameObject[] JJD;//碱基对
    List<GameObject> jjd = new List<GameObject>();

    GameObject[] DP;//DNA片段碱基对
    List<GameObject> dp = new List<GameObject>();


    public GameObject Create;
    /// <summary>
    /// 空物体存放上半部的黏性末端
    /// </summary>
    public GameObject A_T;
    public GameObject A_T1;
    public GameObject T_A;
    public GameObject T_A1;



    // Use this for initialization
    void Start()
    {
        Create.transform.DOMove(new Vector3(0f, -0.55f, 2.3f), 10f);
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

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.name == "A_T test(Clone)" || other.transform.name == "T_A test (Clone)") && (jjd.IndexOf(other.transform.gameObject) == 3 || jjd.IndexOf(other.transform.gameObject) == 4 || jjd.IndexOf(other.transform.gameObject) == 5 || jjd.IndexOf(other.transform.gameObject) == 6))
        {

            for (int i = 0; i < DP.Length; i++)
            {
                dp[i].transform.parent = Create.transform;
            }


            ////////////////////////////////用于处理上半部分黏性末端的角度问题/////////////
            GameObject.FindWithTag("A").transform.parent = A_T.transform;
            A_T.transform.localRotation = Quaternion.Euler(0, -144, 0);
            GameObject.FindWithTag("A1").transform.parent = A_T1.transform;
            A_T1.transform.localRotation = Quaternion.Euler(0, -144, 0);
            GameObject.FindWithTag("T").transform.parent = T_A.transform;
            T_A.transform.localRotation = Quaternion.Euler(0, -144, 0);
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
                Create.GetComponent<Rotation>().enabled = true;
      
            }
  
        }

    }

}
