using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class A_Move : MonoBehaviour {

    Ray ray;
    RaycastHit hit;


    Vector3 Pos;



    public Text A_Img;
    public Text B_Img;
    public GameObject A_Fushi;
    public GameObject B_Fushi;


    public GameObject A_DNA;
    public GameObject ReLoad;
    public GameObject Exit;

    List<GameObject> QJD = new List<GameObject>();//存储二维纠错后的碱基对

    public GameObject panel;

    public GameObject Arrow;
    public GameObject Text;

    int j;//记录鼠标右键的点击次数
    int i = 0;
    public GameObject Error;

    List<GameObject> jjd = new List<GameObject>();

    // Use this for initialization
    void Start () {
        GameObject[] JIANJI = GameObject.FindGameObjectsWithTag("JJD").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
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
                     if (hit.collider.transform.parent.transform.name == "A_T" || hit.collider.transform.parent.transform.name == "T_A" || hit.collider.transform.parent.transform.name == "C_G" || hit.collider.transform.parent.transform.name == "G_C" )
                    {
                      j += 1;
                    }

                        if (j == 11)
                        {
                            A_DNA.GetComponent<Rotation>().enabled = true;
                            A_Img.transform.gameObject.SetActive(true);
                            B_Img.transform.gameObject.SetActive(false);
                            A_Fushi.transform.gameObject.SetActive(true);
                            B_Fushi.transform.gameObject.SetActive(false);
                            ReLoad.SetActive(true);
                            Exit.SetActive(true);
                            panel.SetActive(true);
                            Destroy(Arrow.gameObject);
                            Destroy(Text.gameObject);
  
                       }

                        QJD.Add(hit.collider.transform.parent.transform.gameObject);
                        hit.collider.gameObject.transform.parent.transform.position = new Vector3(5, 0, 0);
                        for (; i < QJD.Count; i++)
                        {
                          if (i != 10)
                        {

                            if (i == 0)
                            {
                                QJD[i].transform.position = new Vector3(5, 0, -1);
                            }
                            if (i != 0 && i * 34 < 90)
                            {
                                QJD[i].transform.position = new Vector3(5 - (Mathf.Sin((i * 34) * Mathf.Deg2Rad)), i * (-0.9f), -(Mathf.Cos((i * 34) * Mathf.Deg2Rad)));
                            }
                            if (i != 0 && i * 34 > 90 && i * 34 < 180)
                            {
                                QJD[i].transform.position = new Vector3(5 - (Mathf.Cos((i * 34 - 90) * Mathf.Deg2Rad)), i * (-0.9f), (Mathf.Sin((i * 34 - 90) * Mathf.Deg2Rad)));
                            }
                            if (i != 0 && i * 34 > 180 && i * 34 < 270)
                            {
                                QJD[i].transform.position = new Vector3(5 + (Mathf.Sin((i * 34 - 180) * Mathf.Deg2Rad)), i * (-0.9f), (Mathf.Cos((i * 34 - 180) * Mathf.Deg2Rad)));
                            }
                            if (i != 0 && i * 34 > 270 && i * 34 < 360)
                            {
                                QJD[i].transform.position = new Vector3(5 + (Mathf.Cos((i * 34 - 270) * Mathf.Deg2Rad)), i * (-0.9f), -(Mathf.Sin((i * 34 - 270) * Mathf.Deg2Rad)));
                            }
                            QJD[i].transform.parent = A_DNA.transform;
                            QJD[i].transform.localRotation = Quaternion.Euler(0, i * 34, 0);
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
                        if (i != 0 && i * 34 > 270 && i * 34 < 360)
                        {
                            QJD[i].transform.position = new Vector3(5 + (Mathf.Cos((i * 34 - 270) * Mathf.Deg2Rad)), i * (-0.9f), -(Mathf.Sin((i * 34 - 270) * Mathf.Deg2Rad)));
                        }
                        QJD[i].transform.parent = A_DNA.transform;
                        QJD[i].transform.localRotation = Quaternion.Euler(0, i * 34, 0);
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

