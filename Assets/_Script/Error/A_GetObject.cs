using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class A_GetObject : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    GameObject obj;
    public Text ErrorText;
    Vector3 Pos;

    public GameObject A_L;
    public GameObject T_L;
    public GameObject C_L;
    public GameObject G_L;

    //public Text A_Img;
    //public Text B_Img;

    public GameObject A_DNA;
    //public GameObject ReLoad;
    //public GameObject Exit;

    //List<GameObject> QJD = new List<GameObject>();//存储二维纠错后的碱基对


    int i ;//记录鼠标左键的点击次数
  //  int j;//记录鼠标右键的点击次数




    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
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
                print(obj.transform.name);
                if (obj.transform.name != "A_R(Clone)" && obj.transform.name != "T_R(Clone)" && obj.transform.name != "C_R(Clone)" && obj.transform.name != "G_R(Clone)")
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
            }
            #endregion
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    j += 1;
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        ///////////////鼠标右键拖拽物体移动/////////存在问题(第一个物体正常，其他物体拖拽不正常)
        //        //Vector3 ScreenPoint = Camera.main.WorldToScreenPoint(hit.collider.gameObject.transform.position);
        //        //hit.collider.gameObject.transform.parent.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));

        //        if (j == 11)
        //        {
        //            A_DNA.GetComponent<Rotation>().enabled = true;
        //            A_Img.transform.gameObject.SetActive(true);
        //            B_Img.transform.gameObject.SetActive(false);
        //            ReLoad.SetActive(true);
        //            Exit.SetActive(true);
        //        }

        //        QJD.Add(hit.collider.transform.parent.transform.gameObject);
        //        hit.collider.gameObject.transform.parent.transform.position = new Vector3(5, 0, 0);
        //        for (int i = 0; i < QJD.Count; i++)
        //        {
        //           // QJD[i].transform.DOMove(new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z), 5f);
               
        //            if (i == 0)
        //            {
        //                QJD[i].transform.position = new Vector3(5,0,-1);
        //               //QJD[i].transform.DOMove(new Vector3(5, 0, -1),1f);
        //            }
        //            if (i != 0 && i * 34 < 90)
        //            {
        //              QJD[i].transform.position = new Vector3(5-( Mathf.Sin((i * 34) * Mathf.Deg2Rad)), i * (-0.9f), -(Mathf.Cos((i * 34) * Mathf.Deg2Rad)));
        //                //QJD[i].transform.DOMove(new Vector3(5 - (Mathf.Sin((i * 34) * Mathf.Deg2Rad)), i * (-0.9f), -(Mathf.Cos((i * 34) * Mathf.Deg2Rad))), 1f);
        //            }
        //            if (i != 0 && i * 34 > 90 && i * 34 < 180)
        //            {
        //               QJD[i].transform.position = new Vector3(5-( Mathf.Cos((i * 34 - 90) * Mathf.Deg2Rad)), i * (-0.9f), ( Mathf.Sin((i * 34 - 90) * Mathf.Deg2Rad)));
        //                //QJD[i].transform.DOMove(new Vector3(5 - (Mathf.Cos((i * 34 - 90) * Mathf.Deg2Rad)), i * (-0.9f), (Mathf.Sin((i * 34 - 90) * Mathf.Deg2Rad))), 1f);
        //            }
        //            if (i != 0 && i * 34 > 180 && i * 34 < 270)
        //            {
        //                QJD[i].transform.position = new Vector3(5+( Mathf.Sin((i * 34 - 180) * Mathf.Deg2Rad)), i * (-0.9f), (Mathf.Cos((i * 34 - 180) * Mathf.Deg2Rad)));
        //                //QJD[i].transform.DOMove(new Vector3(5 + (Mathf.Sin((i * 34 - 180) * Mathf.Deg2Rad)), i * (-0.9f), (Mathf.Cos((i * 34 - 180) * Mathf.Deg2Rad))), 1f);
        //            }
        //            if (i != 0 && i * 34 > 270 && i * 34 < 360)
        //            {
        //              QJD[i].transform.position = new Vector3(5+(Mathf.Cos((i * 34 - 270) * Mathf.Deg2Rad)), i * (-0.9f), -( Mathf.Sin((i * 34 - 270) * Mathf.Deg2Rad)));
        //              // QJD[i].transform.DOMove(new Vector3(5 + (Mathf.Cos((i * 34 - 270) * Mathf.Deg2Rad)), i * (-0.9f), -(Mathf.Sin((i * 34 - 270) * Mathf.Deg2Rad))), 1f);
        //            }
        //            QJD[i].transform.parent = A_DNA.transform;
        //            QJD[i].transform.localRotation = Quaternion.Euler(0, i * 34, 0);
        //        }


        //    }
        //}



    }









}
