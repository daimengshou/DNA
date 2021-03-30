using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Copy_CreateDNA : MonoBehaviour
{

    public GameObject A_T;
    public GameObject C_G;
    public GameObject T_A;
    public GameObject G_C;
    public GameObject Mei;
    public GameObject DNA_TWO;
    bool isOpen = true;
    public GameObject MenuPanel;
    public GameObject Note;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject LianjiemeiBtn;
    public GameObject XianzhimeiBtn;


    LineRenderer lineRender;
   // List<Transform> basePoint_R = new List<Transform>();
    Transform[] jjd;
    public int baseCount = 50;  //两个基础点之间的取点数量   值越大曲线就越平滑  但同时计算量也也越大

    private int count = 20;


    GameObject[] obj = new GameObject[100];

    bool isOn = true;

    // Use this for initialization
    void Start()
    {

        Init();
        this.gameObject.transform.position = new Vector3(8F, 0, 0);
    }

    void Update()
    {
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//为了是其较好的呈现
        //this.transform.Rotate(Vector3.up, 0.01f);

        ////////控制此脚本只运行一次///////
        if (isOn == true)
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 90.0f);
            isOn = false;
        }

    }


    void Init()
    {


        //obj[0] = GameObject.Instantiate(A_T);

        for (int i = 0; i < count; i++)
        {
            ////////////////////随机生成和螺旋形状//////////////////
            #region 随机生成和螺旋形状
            ///////////////////控制了双螺旋中的碱基序列

            obj[i + 1] = RandomCreate();//其它位点的碱基随意
            switch (i + 1)
            {
                case 1:
                     obj[i + 1].tag = "JJD_ONE";
                    if (obj[i + 1].transform.name == "A_T test(Clone)")
                    {
                        obj[i + 1].transform.Find("A").transform.Find("3'duan").gameObject.SetActive(true);
                        obj[i + 1].transform.Find("T").transform.Find("5'duan").gameObject.SetActive(true);
                    }
                    if (obj[i + 1].transform.name == "T_A test (Clone)")
                    {
                        obj[i + 1].transform.Find("T").transform.Find("3'duan").gameObject.SetActive(true);
                        obj[i + 1].transform.Find("A").transform.Find("5'duan").gameObject.SetActive(true);
                    }
                    if (obj[i + 1].transform.name == "C_G test(Clone)")
                    {
                        obj[i + 1].transform.Find("C").transform.Find("3'duan").gameObject.SetActive(true);
                        obj[i + 1].transform.Find("G").transform.Find("5'duan").gameObject.SetActive(true);
                    }
                    if (obj[i + 1].transform.name == "G_C test(Clone)")
                    {
                        obj[i + 1].transform.Find("G").transform.Find("3'duan").gameObject.SetActive(true);
                        obj[i + 1].transform.Find("C").transform.Find("5'duan").gameObject.SetActive(true);
                    }
                    break;
                case 20:
                   obj[i + 1].tag = "JJD_LAST";
                    if (obj[i + 1].transform.name == "A_T test(Clone)")
                    {
                        GameObject Wuduan = obj[i + 1].transform.Find("A").transform.Find("3'duan").gameObject;
                        Wuduan.transform.Find("3'").transform.name = "5'";
                        Wuduan.transform.Find("3").GetComponent<Text>().text = "5'";
                        Wuduan.transform.name = "5'duan";
                        Wuduan.SetActive(true);

                        GameObject Sanduan = obj[i + 1].transform.Find("T").transform.Find("5'duan").gameObject;
                        Sanduan.transform.Find("5'").transform.name = "3'";
                        Sanduan.transform.Find("5").GetComponent<Text>().text = "3'";
                        Sanduan.transform.name = "3'duan";
                        Sanduan.SetActive(true);
                    }
                    if (obj[i + 1].transform.name == "T_A test (Clone)")
                    {
                        GameObject Wuduan = obj[i + 1].transform.Find("T").transform.Find("3'duan").gameObject;
                        Wuduan.transform.Find("3'").transform.name = "5'";
                        Wuduan.transform.Find("3").GetComponent<Text>().text = "5'";
                        Wuduan.transform.name = "5'duan";
                        Wuduan.SetActive(true);

                        GameObject Sanduan = obj[i + 1].transform.Find("A").transform.Find("5'duan").gameObject;
                        Sanduan.transform.Find("5'").transform.name = "3'";
                        Sanduan.transform.Find("5").GetComponent<Text>().text = "3'";
                        Sanduan.transform.name = "3'duan";
                        Sanduan.SetActive(true);
                    }
                    if (obj[i + 1].transform.name == "C_G test(Clone)")
                    {
                        GameObject Wuduan = obj[i + 1].transform.Find("C").transform.Find("3'duan").gameObject;
                        Wuduan.transform.Find("3'").transform.name = "5'";
                        Wuduan.transform.Find("3").GetComponent<Text>().text = "5'";
                        Wuduan.transform.name = "5'duan";
                        Wuduan.SetActive(true);

                        GameObject Sanduan = obj[i + 1].transform.Find("G").transform.Find("5'duan").gameObject;
                        Sanduan.transform.Find("5'").transform.name = "3'";
                        Sanduan.transform.Find("5").GetComponent<Text>().text = "3'";
                        Sanduan.transform.name = "3'duan";
                        Sanduan.SetActive(true);
                    }
                    if (obj[i + 1].transform.name == "G_C test(Clone)")
                    {
                        GameObject Wuduan = obj[i + 1].transform.Find("G").transform.Find("3'duan").gameObject;
                        Wuduan.transform.Find("3'").transform.name = "5'";
                        Wuduan.transform.Find("3").GetComponent<Text>().text = "5'";
                        Wuduan.transform.name = "5'duan";
                        Wuduan.SetActive(true);

                        GameObject Sanduan = obj[i + 1].transform.Find("C").transform.Find("5'duan").gameObject;
                        Sanduan.transform.Find("5'").transform.name = "3'";
                        Sanduan.transform.Find("5").GetComponent<Text>().text = "3'";
                        Sanduan.transform.name = "3'duan";
                        Sanduan.SetActive(true);
                    }
                    break;
                default:
                    obj[i + 1].tag = "JJD";
                    break;
            }

            obj[i+1].transform.position = new Vector3(0, i * 1.5f, 0);
            obj[i+1].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
            obj[i+1].transform.parent = this.transform;
            #endregion

        }


        #region


        for (int i = 1; i < count; i++)
        {
            #region 磷酸二脂键的连接
            #region 以A_T为基础单元

            if (obj[i].transform.name == "A_T test(Clone)")
            {
                if (obj[i + 1].transform.name == "A_T test(Clone)")
                {
                    #region 在T一侧产生磷酸二脂键
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject T_line;
                    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    T_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5f);
                    T_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    T_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //T_line.GetComponent<MeshRenderer>().material = newmaterial;
                    T_line.GetComponent<Renderer>().material.color = Color.black;
                    T_line.transform.name = "LSEZJ_R";
                    T_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    #region  在A 一侧产生磷酸二脂键
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject A_line;
                    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    A_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5F);
                    A_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    A_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    // A_line.GetComponent<MeshRenderer>().material = newmaterial;
                    A_line.GetComponent<Renderer>().material.color = Color.black;
                    A_line.transform.name = "LSEZJ_L";
                    A_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion


                    GameObject T_Line_New;
                    T_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //T_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    T_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    T_Line_New.transform.name = "LSEZJ_R_New";
                    T_Line_New.transform.position = T_line.transform.position;
                    T_Line_New.transform.localScale = T_line.transform.localScale;
                    T_Line_New.transform.localRotation = T_line.transform.rotation;
                    T_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject A_Line_New;
                    A_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //A_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    A_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    A_Line_New.transform.name = "LSEZJ_L_New";
                    A_Line_New.transform.position = A_line.transform.position;
                    A_Line_New.transform.localScale = A_line.transform.localScale;
                    A_Line_New.transform.localRotation = A_line.transform.rotation;
                    A_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name == "T_A test (Clone)")
                {
                    #region  在T_A一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject TA_line;
                    TA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    TA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TA_line.transform.position = Vector3.Lerp(T_p1.transform.position, A_p2.transform.position, 0.5f);
                    TA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //TA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TA_line.GetComponent<Renderer>().material.color = Color.black;
                    TA_line.transform.name = "LSEZJ_R";
                    TA_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    #region  在A_T一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject AT_line;
                    AT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    AT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AT_line.transform.position = Vector3.Lerp(A_p1.transform.position, T_p2.transform.position, 0.5F);
                    AT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    AT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    //AT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AT_line.GetComponent<Renderer>().material.color = Color.black;
                    AT_line.transform.name = "LSEZJ_L";
                    AT_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion


                    GameObject TA_Line_New;
                    TA_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //TA_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    TA_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    TA_Line_New.transform.name = "LSEZJ_R_New";
                    TA_Line_New.transform.position = TA_line.transform.position;
                    TA_Line_New.transform.localScale = TA_line.transform.localScale;
                    TA_Line_New.transform.localRotation = TA_line.transform.rotation;
                    TA_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject AT_Line_New;
                    AT_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //AT_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    AT_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    AT_Line_New.transform.name = "LSEZJ_L_New";
                    AT_Line_New.transform.position = AT_line.transform.position;
                    AT_Line_New.transform.localScale = AT_line.transform.localScale;
                    AT_Line_New.transform.localRotation = AT_line.transform.rotation;
                    AT_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name == "C_G test(Clone)")
                {
                    #region  在T_G一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject TG_line;
                    TG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TG_line.transform.position = Vector3.Lerp(T_p1.transform.position, G_p2.transform.position, 0.5f);
                    TG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //TG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TG_line.GetComponent<Renderer>().material.color = Color.black;
                    TG_line.transform.name = "LSEZJ_R";
                    TG_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    #region 在A_C一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject AC_line;
                    AC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AC_line.transform.position = Vector3.Lerp(A_p1.transform.position, C_p2.transform.position, 0.5f);
                    AC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //AC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AC_line.GetComponent<Renderer>().material.color = Color.black;
                    AC_line.transform.name = "LSEZJ_L";
                    AC_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion


                    GameObject TG_Line_New;
                    TG_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //TG_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    TG_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    TG_Line_New.transform.name = "LSEZJ_R_New";
                    TG_Line_New.transform.position = TG_line.transform.position;
                    TG_Line_New.transform.localScale = TG_line.transform.localScale;
                    TG_Line_New.transform.localRotation = TG_line.transform.rotation;
                    TG_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject AC_Line_New;
                    AC_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //AC_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    AC_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    AC_Line_New.transform.name = "LSEZJ_L_New";
                    AC_Line_New.transform.position = AC_line.transform.position;
                    AC_Line_New.transform.localScale = AC_line.transform.localScale;
                    AC_Line_New.transform.localRotation = AC_line.transform.rotation;
                    AC_Line_New.transform.parent = obj[i].transform.transform;
                }
                //if (obj[i+1].transform.name == "G_C test(Clone)")
                else
                {
                    #region  在T_C一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject TC_line;
                    TC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TC_line.transform.position = Vector3.Lerp(T_p1.transform.position, C_p2.transform.position, 0.5f);
                    TC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TC_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //TC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TC_line.GetComponent<Renderer>().material.color = Color.black;
                    TC_line.transform.name = "LSEZJ_R";
                    TC_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    #region 在A_G一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject AG_line;
                    AG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AG_line.transform.position = Vector3.Lerp(A_p1.transform.position, G_p2.transform.position, 0.5f);
                    AG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AG_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //AG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AG_line.GetComponent<Renderer>().material.color = Color.black;
                    AG_line.transform.name = "LSEZJ_L";
                    AG_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion


                    GameObject TC_Line_New;
                    TC_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //TC_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    TC_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    TC_Line_New.transform.name = "LSEZJ_R_New";
                    TC_Line_New.transform.position = TC_line.transform.position;
                    TC_Line_New.transform.localScale = TC_line.transform.localScale;
                    TC_Line_New.transform.localRotation = TC_line.transform.rotation;
                    TC_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject AG_Line_New;
                    AG_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //AG_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    AG_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    AG_Line_New.transform.name = "LSEZJ_L_New";
                    AG_Line_New.transform.position = AG_line.transform.position;
                    AG_Line_New.transform.localScale = AG_line.transform.localScale;
                    AG_Line_New.transform.localRotation = AG_line.transform.rotation;
                    AG_Line_New.transform.parent = obj[i].transform.transform;
                }
            }

            #endregion

            #region 以C_G为基础单元
            else if (obj[i].transform.name == "C_G test(Clone)")
            {

                if (obj[i + 1].transform.name == "C_G test(Clone)")
                {
                    #region 在G一侧产生磷酸二脂键
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject G_line;
                    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    G_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
                    G_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    G_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //G_line.GetComponent<MeshRenderer>().material = newmaterial;
                    G_line.GetComponent<Renderer>().material.color = Color.black;
                    G_line.transform.name = "LSEZJ_R";
                    G_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    #region 在C一侧产生磷酸二脂键
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject C_line;
                    C_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    C_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    C_line.transform.position = Vector3.Lerp(C_p1.transform.position, C_p2.transform.position, 0.5f);
                    C_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    C_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //C_line.GetComponent<MeshRenderer>().material = newmaterial;
                    C_line.GetComponent<Renderer>().material.color = Color.black;
                    C_line.transform.name = "LSEZJ_L";
                    C_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    GameObject G_Line_New;
                    G_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //G_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    G_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    G_Line_New.transform.name = "LSEZJ_R_New";
                    G_Line_New.transform.position = G_line.transform.position;
                    G_Line_New.transform.localScale = G_line.transform.localScale;
                    G_Line_New.transform.localRotation = G_line.transform.rotation;
                    G_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject C_Line_New;
                    C_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //C_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    C_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    C_Line_New.transform.name = "LSEZJ_L_New";
                    C_Line_New.transform.position =C_line.transform.position;
                    C_Line_New.transform.localScale = C_line.transform.localScale;
                    C_Line_New.transform.localRotation = C_line.transform.rotation;
                    C_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name == "G_C test(Clone)")
                {
                    #region 在G_C一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject GC_line;
                    GC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    GC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GC_line.transform.position = Vector3.Lerp(G_p1.transform.position, C_p2.transform.position, 0.5f);
                    GC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GC_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //GC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GC_line.GetComponent<Renderer>().material.color = Color.black;
                    GC_line.transform.name = "LSEZJ_R";
                    GC_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    #region 在C_G一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject CG_line;
                    CG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    CG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CG_line.transform.position = Vector3.Lerp(C_p1.transform.position, G_p2.transform.position, 0.5f);
                    CG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CG_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //CG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CG_line.GetComponent<Renderer>().material.color = Color.black;
                    CG_line.transform.name = "LSEZJ_L";
                    CG_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    GameObject GC_Line_New;
                    GC_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //GC_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    GC_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    GC_Line_New.transform.name = "LSEZJ_R_New";
                    GC_Line_New.transform.position = GC_line.transform.position;
                    GC_Line_New.transform.localScale = GC_line.transform.localScale;
                    GC_Line_New.transform.localRotation = GC_line.transform.rotation;
                    GC_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject CG_Line_New;
                    CG_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //CG_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    CG_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    CG_Line_New.transform.name = "LSEZJ_L_New";
                    CG_Line_New.transform.position =CG_line.transform.position;
                    CG_Line_New.transform.localScale =CG_line.transform.localScale;
                    CG_Line_New.transform.localRotation = CG_line.transform.rotation;
                    CG_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name == "A_T test(Clone)")
                {
                    #region 在G_T一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject GT_line;
                    GT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GT_line.transform.position = Vector3.Lerp(G_p1.transform.position, T_p2.transform.position, 0.5f);
                    GT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //GT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GT_line.GetComponent<Renderer>().material.color = Color.black;
                    GT_line.transform.name = "LSEZJ_R";
                    GT_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    #region 在C_A一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject CA_line;
                    CA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CA_line.transform.position = Vector3.Lerp(C_p1.transform.position, A_p2.transform.position, 0.5f);
                    CA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //CA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CA_line.GetComponent<Renderer>().material.color = Color.black;
                    CA_line.transform.name = "LSEZJ_L";
                    CA_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion


                    GameObject GT_Line_New;
                    GT_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //GT_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    GT_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    GT_Line_New.transform.name = "LSEZJ_R_New";
                    GT_Line_New.transform.position = GT_line.transform.position;
                    GT_Line_New.transform.localScale = GT_line.transform.localScale;
                    GT_Line_New.transform.localRotation = GT_line.transform.rotation;
                    GT_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject CA_Line_New;
                    CA_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //CA_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    CA_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    CA_Line_New.transform.name = "LSEZJ_L_New";
                    CA_Line_New.transform.position =CA_line.transform.position;
                    CA_Line_New.transform.localScale = CA_line.transform.localScale;
                    CA_Line_New.transform.localRotation = CA_line.transform.rotation;
                    CA_Line_New.transform.parent = obj[i].transform.transform;
                }
                //if (obj[i+1].transform.name == "T_A test (Clone)")
                else
                {
                    #region 在G_A一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject GA_line;
                    GA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GA_line.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
                    GA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //GA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GA_line.GetComponent<Renderer>().material.color = Color.black;
                    GA_line.transform.name = "LSEZJ_R";
                    GA_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    #region 在C_T一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject CT_line;
                    CT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CT_line.transform.position = Vector3.Lerp(C_p1.transform.position, T_p2.transform.position, 0.5f);
                    CT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //CT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CT_line.GetComponent<Renderer>().material.color = Color.black;
                    CT_line.transform.name = "LSEZJ_L";
                    CT_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    GameObject GA_Line_New;
                    GA_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //GA_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    GA_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    GA_Line_New.transform.name = "LSEZJ_R_New";
                    GA_Line_New.transform.position = GA_line.transform.position;
                    GA_Line_New.transform.localScale = GA_line.transform.localScale;
                    GA_Line_New.transform.localRotation = GA_line.transform.rotation;
                    GA_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject CT_Line_New;
                    CT_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //CT_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    CT_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    CT_Line_New.transform.name = "LSEZJ_L_New";
                    CT_Line_New.transform.position = CT_line.transform.position;
                    CT_Line_New.transform.localScale = CT_line.transform.localScale;
                    CT_Line_New.transform.localRotation = CT_line.transform.rotation;
                    CT_Line_New.transform.parent = obj[i].transform.transform;

                }
            }

            #endregion

            #region 以T_A为基础单元
            else if (obj[i].transform.name.ToString() == "T_A test (Clone)")
            {
                if (obj[i + 1].transform.name.ToString() == "T_A test (Clone)")
                {

                    #region 在A一侧产生磷酸二脂键
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject A_line;
                    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    A_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5f);
                    A_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    A_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //A_line.GetComponent<MeshRenderer>().material = newmaterial;
                    A_line.GetComponent<Renderer>().material.color = Color.black;
                    A_line.transform.name = "LSEZJ_R";
                    A_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region  在T 一侧产生磷酸二脂键
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject T_line;
                    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    T_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5F);
                    T_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    T_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    //T_line.GetComponent<MeshRenderer>().material = newmaterial;
                    T_line.GetComponent<Renderer>().material.color = Color.black;
                    T_line.transform.name = "LSEZJ_L";
                    T_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    GameObject A_Line_New;
                    A_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //A_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    A_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    A_Line_New.transform.name = "LSEZJ_R_New";
                    A_Line_New.transform.position = A_line.transform.position;
                    A_Line_New.transform.localScale = A_line.transform.localScale;
                    A_Line_New.transform.localRotation = A_line.transform.rotation;
                    A_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject T_Line_New;
                    T_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //T_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    T_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    T_Line_New.transform.name = "LSEZJ_L_New";
                    T_Line_New.transform.position = T_line.transform.position;
                    T_Line_New.transform.localScale = T_line.transform.localScale;
                    T_Line_New.transform.localRotation = T_line.transform.rotation;
                    T_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name.ToString() == "A_T test(Clone)")
                {
                    #region  在A_T一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject AT_line;
                    AT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    AT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AT_line.transform.position = Vector3.Lerp(A_p1.transform.position, T_p2.transform.position, 0.5f);
                    AT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //AT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AT_line.GetComponent<Renderer>().material.color = Color.black;
                    AT_line.transform.name = "LSEZJ_R";
                    AT_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region  在T_A一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject TA_line;
                    TA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    TA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TA_line.transform.position = Vector3.Lerp(T_p1.transform.position, A_p2.transform.position, 0.5F);
                    TA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    TA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    //TA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TA_line.GetComponent<Renderer>().material.color = Color.black;
                    TA_line.transform.name = "LSEZJ_L";
                    TA_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    GameObject AT_Line_New;
                    AT_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //AT_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    AT_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    AT_Line_New.transform.name = "LSEZJ_R_New";
                    AT_Line_New.transform.position = AT_line.transform.position;
                    AT_Line_New.transform.localScale = AT_line.transform.localScale;
                    AT_Line_New.transform.localRotation = AT_line.transform.rotation;
                    AT_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject TA_Line_New;
                    TA_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //TA_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    TA_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    TA_Line_New.transform.name = "LSEZJ_L_New";
                    TA_Line_New.transform.position = TA_line.transform.position;
                    TA_Line_New.transform.localScale = TA_line.transform.localScale;
                    TA_Line_New.transform.localRotation = TA_line.transform.rotation;
                    TA_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name.ToString() == "C_G test(Clone)")
                {
                    #region  在A_G一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject AG_line;
                    AG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AG_line.transform.position = Vector3.Lerp(A_p1.transform.position, G_p2.transform.position, 0.5f);
                    AG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //AG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AG_line.GetComponent<Renderer>().material.color = Color.black;
                    AG_line.transform.name = "LSEZJ_R";
                    AG_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region 在T_C一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject TC_line;
                    TC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TC_line.transform.position = Vector3.Lerp(T_p1.transform.position, C_p2.transform.position, 0.5f);
                    TC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //TC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TC_line.GetComponent<Renderer>().material.color = Color.black;
                    TC_line.transform.name = "LSEZJ_L";
                    TC_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    GameObject AG_Line_New;
                    AG_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //AG_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    AG_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    AG_Line_New.transform.name = "LSEZJ_R_New";
                    AG_Line_New.transform.position = AG_line.transform.position;
                    AG_Line_New.transform.localScale = AG_line.transform.localScale;
                    AG_Line_New.transform.localRotation = AG_line.transform.rotation;
                    AG_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject TC_Line_New;
                    TC_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //TC_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    TC_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    TC_Line_New.transform.name = "LSEZJ_L_New";
                    TC_Line_New.transform.position = TC_line.transform.position;
                    TC_Line_New.transform.localScale = TC_line.transform.localScale;
                    TC_Line_New.transform.localRotation = TC_line.transform.rotation;
                    TC_Line_New.transform.parent = obj[i].transform.transform;
                }
                //if (obj[i+1].transform.name == "G_C test(Clone)")
                else
                {
                    #region  在A_C一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject AC_line;
                    AC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AC_line.transform.position = Vector3.Lerp(A_p1.transform.position, C_p2.transform.position, 0.5f);
                    AC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AC_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //AC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AC_line.GetComponent<Renderer>().material.color = Color.black;
                    AC_line.transform.name = "LSEZJ_R";
                    AC_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region 在T_G一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject TG_line;
                    TG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TG_line.transform.position = Vector3.Lerp(T_p1.transform.position, G_p2.transform.position, 0.5f);
                    TG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TG_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //TG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TG_line.GetComponent<Renderer>().material.color = Color.black;
                    TG_line.transform.name = "LSEZJ_L";
                    TG_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    GameObject AC_Line_New;
                    AC_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //AC_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    AC_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    AC_Line_New.transform.name = "LSEZJ_R_New";
                    AC_Line_New.transform.position = AC_line.transform.position;
                    AC_Line_New.transform.localScale = AC_line.transform.localScale;
                    AC_Line_New.transform.localRotation = AC_line.transform.rotation;
                    AC_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject TG_Line_New;
                    TG_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //TG_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    TG_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    TG_Line_New.transform.name = "LSEZJ_L_New";
                    TG_Line_New.transform.position = TG_line.transform.position;
                    TG_Line_New.transform.localScale = TG_line.transform.localScale;
                    TG_Line_New.transform.localRotation = TG_line.transform.rotation;
                    TG_Line_New.transform.parent = obj[i].transform.transform;
                }
            }


            #endregion

            #region 以G_C为基础单元
            if (obj[i].transform.name == "G_C test(Clone)")
            {

                if (obj[i + 1].transform.name == "G_C test(Clone)")
                {
                    #region 在C一侧产生磷酸二脂键
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").transform.gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject C_line;
                    C_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    C_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    C_line.transform.position = Vector3.Lerp(C_p1.transform.position, C_p2.transform.position, 0.5f);
                    C_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    C_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //C_line.GetComponent<MeshRenderer>().material = newmaterial;
                    C_line.GetComponent<Renderer>().material.color = Color.black;
                    C_line.transform.name = "LSEZJ_R";
                    C_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G一侧产生磷酸二脂键
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject G_line;
                    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    G_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
                    G_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    G_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //G_line.GetComponent<MeshRenderer>().material = newmaterial;
                    G_line.GetComponent<Renderer>().material.color = Color.black;
                    G_line.transform.name = "LSEZJ_L";
                    G_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    GameObject C_Line_New;
                    C_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //C_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    C_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    C_Line_New.transform.name = "LSEZJ_R_New";
                    C_Line_New.transform.position =C_line.transform.position;
                    C_Line_New.transform.localScale = C_line.transform.localScale;
                    C_Line_New.transform.localRotation = C_line.transform.rotation;
                    C_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject G_Line_New;
                    G_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //G_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    G_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    G_Line_New.transform.name = "LSEZJ_L_New";
                    G_Line_New.transform.position = G_line.transform.position;
                    G_Line_New.transform.localScale = G_line.transform.localScale;
                    G_Line_New.transform.localRotation =G_line.transform.rotation;
                    G_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name == "C_G test(Clone)")
                {
                    #region 在C_G一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject CG_line;
                    CG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    CG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CG_line.transform.position = Vector3.Lerp(C_p1.transform.position, G_p2.transform.position, 0.5f);
                    CG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //CG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CG_line.GetComponent<Renderer>().material.color = Color.black;
                    CG_line.transform.name = "LSEZJ_R";
                    CG_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G_C一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject GC_line;
                    GC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    GC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GC_line.transform.position = Vector3.Lerp(G_p1.transform.position, C_p2.transform.position, 0.5f);
                    GC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //newmaterial.SetColor("_Color", Color.black);
                    //GC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GC_line.GetComponent<Renderer>().material.color = Color.black;
                    GC_line.transform.name = "LSEZJ_L";
                    GC_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    GameObject CG_Line_New;
                    CG_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //CG_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    CG_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    CG_Line_New.transform.name = "LSEZJ_R_New";
                    CG_Line_New.transform.position = CG_line.transform.position;
                    CG_Line_New.transform.localScale = CG_line.transform.localScale;
                    CG_Line_New.transform.localRotation = CG_line.transform.rotation;
                    CG_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject GC_Line_New;
                    GC_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //GC_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    GC_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    GC_Line_New.transform.name = "LSEZJ_L_New";
                    GC_Line_New.transform.position = GC_line.transform.position;
                    GC_Line_New.transform.localScale = GC_line.transform.localScale;
                    GC_Line_New.transform.localRotation = GC_line.transform.rotation;
                    GC_Line_New.transform.parent = obj[i].transform.transform;
                }
                else if (obj[i + 1].transform.name == "A_T test(Clone)")
                {
                    #region 在C_T一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject CT_line;
                    CT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CT_line.transform.position = Vector3.Lerp(C_p1.transform.position, T_p2.transform.position, 0.5f);
                    CT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //CT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CT_line.GetComponent<Renderer>().material.color = Color.black;
                    CT_line.transform.name = "LSEZJ_R";
                    CT_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G_A一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject GA_line;
                    GA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GA_line.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
                    GA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //GA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GA_line.GetComponent<Renderer>().material.color = Color.black;
                    GA_line.transform.name = "LSEZJ_L";
                    GA_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    GameObject CT_Line_New;
                    CT_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //CT_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    CT_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    CT_Line_New.transform.name = "LSEZJ_R_New";
                    CT_Line_New.transform.position = CT_line.transform.position;
                    CT_Line_New.transform.localScale = CT_line.transform.localScale;
                    CT_Line_New.transform.localRotation = CT_line.transform.rotation;
                    CT_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject GA_Line_New;
                    GA_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //GA_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    GA_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    GA_Line_New.transform.name = "LSEZJ_L_New";
                    GA_Line_New.transform.position = GA_line.transform.position;
                    GA_Line_New.transform.localScale = GA_line.transform.localScale;
                    GA_Line_New.transform.localRotation = GA_line.transform.rotation;
                    GA_Line_New.transform.parent = obj[i].transform.transform;
                }
                //if (obj[i+1].transform.name == "T_A test (Clone)")
                else
                {
                    #region 在C_A一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject CA_line;
                    CA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CA_line.transform.position = Vector3.Lerp(C_p1.transform.position, A_p2.transform.position, 0.5f);
                    CA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //CA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CA_line.GetComponent<Renderer>().material.color = Color.black;
                    CA_line.transform.name = "LSEZJ_R";
                    CA_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G_T一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject GT_line;
                    GT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GT_line.transform.position = Vector3.Lerp(G_p1.transform.position, T_p2.transform.position, 0.5f);
                    GT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    //GT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GT_line.GetComponent<Renderer>().material.color = Color.black;
                    GT_line.transform.name = "LSEZJ_L";
                    GT_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    GameObject CA_Line_New;
                    CA_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //CA_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    CA_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    CA_Line_New.transform.name = "LSEZJ_R_New";
                    CA_Line_New.transform.position = CA_line.transform.position;
                    CA_Line_New.transform.localScale = CA_line.transform.localScale;
                    CA_Line_New.transform.localRotation = CA_line.transform.rotation;
                    CA_Line_New.transform.parent = obj[i].transform.transform;

                    GameObject GT_Line_New;
                    GT_Line_New = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    //newmaterial.SetColor("_Color", Color.black);
                    //GT_Line_New.GetComponent<MeshRenderer>().material = newmaterial;
                    GT_Line_New.GetComponent<Renderer>().material.color = Color.black;
                    GT_Line_New.transform.name = "LSEZJ_L_New";
                    GT_Line_New.transform.position =GT_line.transform.position;
                    GT_Line_New.transform.localScale = GT_line.transform.localScale;
                    GT_Line_New.transform.localRotation = GT_line.transform.rotation;
                    GT_Line_New.transform.parent = obj[i].transform.transform;
                }
            }
            #endregion

            #endregion
        }
        #endregion



    
        }



    /// <summary>
    /// /随机生成
    /// </summary>
    /// <returns></returns>
    GameObject RandomCreate()
    {
        #region 用两类来分
        //  GameObject Gb;//实例化的物体
        //int a = Random.Range(0, 100);
        //  if (a%2!=0)
        //  {
        //      Gb = GameObject.Instantiate(A_T);
        //      return Gb;
        //  }
        //  else
        //  {
        //      Gb = GameObject.Instantiate(C_G);
        //      return Gb;
        //  }
        #endregion

        GameObject Gb;
        #region  用等差数列的思想，将随机生成的数分为四类
        int a =UnityEngine.Random.Range(1, 101);//Range是左开又闭，随机产生[1,100]的数
        if ((a - 1) % 4 == 0)
        {
            Gb = GameObject.Instantiate(A_T);
            return Gb;
        }
        else if ((a - 2) % 4 == 0)
        {
            Gb = GameObject.Instantiate(C_G);
            return Gb;
        }
        else if ((a - 3) % 4 == 0)
        {
            Gb = GameObject.Instantiate(T_A);
            return Gb;
        }
        else
        {
            Gb = GameObject.Instantiate(G_C);
            return Gb;
        }
        #endregion
    }

    public void Exit()
    {
        SceneManager.LoadScene("Copy_problem");
    }
    public void Reload()
    {
        SceneManager.LoadScene("Copy");
    }
    public void Return()
    {
        SceneManager.LoadScene("Copy_Content");
    }

    public void CreateMei()
    {
        Mei.SetActive(true);
        Note.SetActive(false);
        Note1.SetActive(true);
        Note2.SetActive(false);
    }

    public void Connect()
    {
        DNA_TWO.GetComponent<ShowLSEZJ>().enabled = true;
        Note.SetActive(false);
        Note1.SetActive(false );
        Note2.SetActive(true );
        XianzhimeiBtn.GetComponent<Button>().enabled = false;
        LianjiemeiBtn.GetComponent<Button>().enabled = false;
    }

    public void OpenMenu()
    {
        if (isOpen == false)
        {
            MenuPanel.transform.DOScale(Vector3.one, 0.3f);
        }
        if (isOpen == true)
        {
            MenuPanel.transform.DOScale(new Vector3(1, 0, 1), 0.3f);
        }
        isOpen = !isOpen;
    }
}



