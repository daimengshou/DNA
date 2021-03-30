using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class B_GetObject : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    GameObject obj;
    public Text ErrorText;
    Vector3 Pos;

    public GameObject A_L;
    public GameObject T_L;
    public GameObject C_L;
    public GameObject G_L;
    List<GameObject> jjd = new List<GameObject>();
    List<GameObject> jjd_R = new List<GameObject>();




    //public Text A_Img;
    //public Text B_Img;

    public GameObject B_DNA;
    //public GameObject ReLoad;
    //public GameObject Exit;

  //  List<GameObject> QJD = new List<GameObject>();

    int i ;//记录鼠标左键的点击次数
    int j;//记录鼠标右键的点击次数

    public GameObject Error;




    // Use this for initialization
    void Start()
    {
        Transform[] JJD =Error.GetComponentsInChildren<Transform>();
        foreach (Transform jjd in JJD)
        {
            if (jjd.transform.name == "A_R(Clone)" || jjd.transform.name == "T_R(Clone)" || jjd.transform.name == "C_R(Clone)" || jjd.transform.name == "G_R(Clone)")
            {
                jjd.GetComponent<BoxCollider>().isTrigger = false;
                jjd_R.Add(jjd.transform.gameObject);
            }
        }
        for (int i = 0; i < jjd_R.Count; i++)
        {
        Transform[] JJD_R = jjd_R[i].GetComponentsInChildren<Transform>();
        foreach (Transform jjd in JJD_R)
        {

        
        if (jjd.transform.name == "Cylinder" || jjd.transform.name == "Cylinder (1)" || jjd.transform.name == "Cylinder (2)"
               || jjd.transform.name == "0" || jjd.transform.name == "1" || jjd.transform.name == "2"
                )
            {
                jjd.GetComponent<CapsuleCollider>().enabled = false;
            }
            if (jjd.transform.name == "磷酸")
            {
                jjd.GetComponent<SphereCollider>().enabled = false;
            }
        }
    }
}

    // Update is called once per frame
    void Update()
    {
        //Transform[] JJD = Error.GetComponentsInChildren<Transform>();
        //foreach (Transform jjd in JJD)
        //{
        //    if (jjd.transform.name == "A_R(Clone)" || jjd.transform.name == "T_R(Clone)" || jjd.transform.name == "C_R(Clone)" || jjd.transform.name == "G_R(Clone)")
        //    {
        //        jjd.GetComponent<BoxCollider>().enabled = false;
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //////////////用按钮式的点击，只要是获取点击物的位置//////
            //if (Physics.Raycast(ray, out hit))
            //{
            //    obj = hit.collider.gameObject;
            //    Debug.Log(obj.transform.name);
            //    Pos = obj.transform.position;
            //}

            ////////////通过鼠标直接点击，实现轮播翻牌的效果/////
            #region   
            if (Physics.Raycast(ray, out hit))
            {

                i += 1;
                obj = hit.collider.gameObject;

                Pos = obj.transform.position;
                //if (obj.transform.name == "A_R(Clone)" || obj.transform.name == "T_R(Clone)" || obj.transform.name == "C_R(Clone)" || obj.transform.name == "G_R(Clone)")
                //{
                //    print("不该点");
                //}

                if (obj.transform.name != "A_R(Clone)"&&obj.transform.name != "T_R(Clone)" &&obj.transform.name != "C_R(Clone)"&& obj.transform.name != "G_R(Clone)")
                {

                    if (obj.transform.parent.transform.name == "A_T")
                    {
                        if (i == 1)
                        {
                            GameObject Object1 = GameObject.Instantiate(A_L);
                            Object1.transform.GetComponent<BoxCollider>().enabled = false;
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择正确";
                            i = 0;
                        }
                    }
                    if (obj.transform.parent.transform.name == "T_A")
                    {
                        if (i == 1)
                        {
                            GameObject Object1 = GameObject.Instantiate(A_L);
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择错误";
                        }
                        if (i == 2)
                        {
                            GameObject Object1 = GameObject.Instantiate(T_L);
                            Object1.transform.GetComponent<BoxCollider>().enabled = false;
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择正确";
                            i = 0;

                        }
                    }
                    if (obj.transform.parent.transform.name == "C_G")
                    {
                        if (i == 1)
                        {
                            GameObject Object1 = GameObject.Instantiate(A_L);
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择错误";
                        }
                        if (i == 2)
                        {
                            GameObject Object1 = GameObject.Instantiate(T_L);
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择错误";
                        }
                        if (i == 3)
                        {
                            GameObject Object1 = GameObject.Instantiate(C_L);
                            Object1.transform.GetComponent<BoxCollider>().enabled = false;
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择正确";
                            i = 0;
                        }

                    }
                    if (obj.transform.parent.transform.name == "G_C")
                    {
                        if (i == 1)
                        {
                            GameObject Object1 = GameObject.Instantiate(A_L);
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择错误";
                        }
                        if (i == 2)
                        {
                            GameObject Object1 = GameObject.Instantiate(T_L);
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择错误";
                        }
                        if (i == 3)
                        {
                            GameObject Object1 = GameObject.Instantiate(C_L);
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择错误";
                        }
                        if (i == 4)
                        {
                            GameObject Object1 = GameObject.Instantiate(G_L);
                            Object1.transform.GetComponent<BoxCollider>().enabled = false;
                            Object1.transform.position = Pos;
                            Object1.transform.parent = obj.transform.parent.transform;
                            Destroy(obj.transform.gameObject);
                            ErrorText.text = "您选择正确";
                            i = 0;

                        }

                    }
                }
                #endregion

            }

        }
        #region 不要
        //if (Input.GetMouseButtonDown(1))
        //{
        //    j += 1;
        //    if (j == 10)
        //    {
        //        B_Img.transform.gameObject.SetActive(true);
        //        A_Img.transform.gameObject.SetActive(false);
        //        ReLoad.SetActive(true);
        //        Exit.SetActive(true);
        //    }
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        ///////////////鼠标右键拖拽物体移动/////////存在问题(第一个物体正常，其他物体拖拽不正常)
        //        //Vector3 ScreenPoint = Camera.main.WorldToScreenPoint(hit.collider.gameObject.transform.position);
        //        //hit.collider.gameObject.transform.parent.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));


        //        QJD.Add(hit.collider.transform.parent.transform.gameObject);
        //        hit.collider.gameObject.transform.parent.transform.position = new Vector3(5, 0, 0);
        //        for (int i = 0; i < QJD.Count; i++)
        //        {
        //            QJD[i].transform.DOMove(new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z), 5f);
        //            QJD[i].transform.parent = B_DNA.transform;
        //            //QJD[i].transform.position = new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z);
        //            QJD[i].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
        //        }


        //    }
        //}
        #endregion

    }









}
