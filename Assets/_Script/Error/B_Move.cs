using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class B_Move : MonoBehaviour {

    Ray ray;
    RaycastHit hit;

    Vector3 Pos;



    public Text A_Img;
    public Text B_Img;
    public GameObject A_Fushi;
    public GameObject B_Fushi;

    public GameObject B_DNA;
    public GameObject ReLoad;
    public GameObject Exit;

    public GameObject panel;
    List<GameObject> QJD = new List<GameObject>();

    public GameObject Arrow;
    public GameObject Text;
    public GameObject Error;
    //GameObject [] JIANJI;
    List<GameObject> jjd = new List<GameObject>();

    int j;//记录鼠标右键的点击次数
    int i = 0;



    // Use this for initialization
    void Start () {
        //Transform[] JJD = Error.GetComponentsInChildren<Transform>();
        //foreach (Transform jjd in JJD)
        //{
        //    if (jjd.transform.name == "A_L(Clone)" || jjd.transform.name == "T_L(Clone)" || jjd.transform.name == "C_L(Clone)" || jjd.transform.name == "G_L(Clone)")
        //    {
        //        jjd.GetComponent<BoxCollider>().enabled = true;
        //    }
        //}

        //Transform[] JIANJIDUI = Error.GetComponentsInChildren<Transform>();
        //foreach (Transform jjd in JIANJIDUI )
        //{
        //    if (jjd.transform.name == "A_T" || jjd.transform.name == "T_A" || jjd.transform.name == "C_G" || jjd.transform.name == "G_C")
        //    {
        //        jjd.transform.tag = "JJD";
        //    }
        //}
    GameObject[]  JIANJI = GameObject.FindGameObjectsWithTag("JJD").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
        for (int i = 0; i < JIANJI.Length; i++)
        {
            jjd.Add(JIANJI[i].gameObject);
            //  print(jjd[i].transform.name+i);
        }

        for (int i = 0; i < 1; i++)
        {
            Transform[] JJD = jjd[i].GetComponentsInChildren<Transform>();
            foreach (Transform jjd in JJD)
            {
                if (jjd.transform.name == "A_L(Clone)" || jjd.transform.name == "T_L(Clone)" || jjd.transform.name == "C_L(Clone)" || jjd.transform.name == "G_L(Clone)"
                    || jjd.transform.name == "A_R(Clone)" || jjd.transform.name == "T_R(Clone)" || jjd.transform.name == "C_R(Clone)" || jjd.transform.name == "G_R(Clone)")
                {
                    jjd.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                if (hit.collider.transform.parent.transform.name == "A_T" || hit.collider.transform.parent.transform.name == "T_A" || hit.collider.transform.parent.transform.name == "C_G" || hit.collider.transform.parent.transform.name == "G_C")
                {
                    j += 1;
                }
                if (j == 10)
                {
                    B_Img.transform.gameObject.SetActive(true);
                    A_Img.transform.gameObject.SetActive(false);
                    B_Fushi.transform.gameObject.SetActive(true);
                    A_Fushi.transform.gameObject.SetActive(false);
                    ReLoad.SetActive(true);
                    Exit.SetActive(true);
                    panel.SetActive(true);
                    Destroy(Arrow.gameObject);
                    Destroy(Text.gameObject);
                }

                ///////////////鼠标右键拖拽物体移动/////////存在问题(第一个物体正常，其他物体拖拽不正常)
                //Vector3 ScreenPoint = Camera.main.WorldToScreenPoint(hit.collider.gameObject.transform.position);
                //hit.collider.gameObject.transform.parent.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));
                //print(jjd.IndexOf(hit.transform.parent.gameObject));
                //print(hit.transform.name);
                //        QJD.Add(hit.collider.transform.parent.transform. gameObject);
                //   //     hit.collider.gameObject.transform.parent.transform.position = new Vector3(5, 0, 0);
                //        for (int i = 0; i < QJD.Count; i++)
                //        {
                //    //  QJD[i].transform.DOMove(new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z), 5f);


                //    // QJD[i].transform.DOMove(new Vector3(jjd[i].transform.position.x, jjd[i].transform.position.y - 2 * i, jjd[i].transform.position.z), 5f);
                //    QJD[i].transform.parent = B_DNA.transform;
                //    QJD[i].transform.localPosition=(new Vector3(0, -2 * jjd.IndexOf(hit.transform.parent.gameObject) , 0));
                //    //QJD[i].transform.position = new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z);
                //    //    QJD[i].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
                //    QJD[i].transform.localRotation = Quaternion.Euler(jjd[i].transform.localRotation.x, i*36, jjd[i].transform.localRotation.z);

                QJD.Add(hit.collider.transform.parent.transform.gameObject);
                    hit.collider.gameObject.transform.parent.transform.position = new Vector3(5, 0, 0);

                    for (; i < QJD.Count; i++)
                    {
                    if (i != 9)
                    {
                        //  QJD[i].transform.DOMove(new Vector3(QJD[i].transform.position.x,(jjd.IndexOf(hit.transform.gameObject.transform.parent.gameObject)-i) * (-2f), QJD[i].transform.position.z), 5f);
                        QJD[i].transform.DOMove(new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z), 5f);
                        QJD[i].transform.parent = B_DNA.transform;
                        //QJD[i].transform.position = new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z);
                        QJD[i].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
                        Transform[] JJD = jjd[i + 1].GetComponentsInChildren<Transform>();
                        foreach (Transform jjd in JJD)
                        {
                            if (jjd.transform.name == "A_L(Clone)" || jjd.transform.name == "T_L(Clone)" || jjd.transform.name == "C_L(Clone)" || jjd.transform.name == "G_L(Clone)"
                                || jjd.transform.name == "A_R(Clone)" || jjd.transform.name == "T_R(Clone)" || jjd.transform.name == "C_R(Clone)" || jjd.transform.name == "G_R(Clone)")
                            {
                                jjd.GetComponent<BoxCollider>().enabled = true;
                            }
                        }
                        Transform[] JJD_OLD = jjd[i].GetComponentsInChildren<Transform>();
                        foreach (Transform jjd in JJD_OLD)
                        {
                            if (jjd.transform.name == "A_L(Clone)" || jjd.transform.name == "T_L(Clone)" || jjd.transform.name == "C_L(Clone)" || jjd.transform.name == "G_L(Clone)"
                                || jjd.transform.name == "A_R(Clone)" || jjd.transform.name == "T_R(Clone)" || jjd.transform.name == "C_R(Clone)" || jjd.transform.name == "G_R(Clone)")
                            {
                                jjd.GetComponent<BoxCollider>().enabled = false;
                            }
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
                    else
                    {
                        QJD[i].transform.DOMove(new Vector3(QJD[i].transform.position.x, i * (-0.5f), QJD[i].transform.position.z), 5f);
                        QJD[i].transform.parent = B_DNA.transform;
                        QJD[i].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
                        Transform[] JJD = jjd[i].GetComponentsInChildren<Transform>();
                        foreach (Transform jjd in JJD)
                        {
                            if (jjd.transform.name == "A_L(Clone)" || jjd.transform.name == "T_L(Clone)" || jjd.transform.name == "C_L(Clone)" || jjd.transform.name == "G_L(Clone)"
                                || jjd.transform.name == "A_R(Clone)" || jjd.transform.name == "T_R(Clone)" || jjd.transform.name == "C_R(Clone)" || jjd.transform.name == "G_R(Clone)")
                            {
                                jjd.GetComponent<BoxCollider>().enabled = false;
                            }
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


                    }
                }
            }
  









}
