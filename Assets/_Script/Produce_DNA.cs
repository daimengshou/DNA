using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//做场景加载时必须引用的



public class Produce_DNA : MonoBehaviour
{

    public GameObject A_T;
    public GameObject C_G;
    public GameObject T_A;
    public GameObject G_C;



    private int count = 20;


    GameObject[] obj = new GameObject[100];



    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Update()
    {
      //  this.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);//为了是其较好的呈现
 



    }


    void Init()
    {


        //obj[0] = GameObject.Instantiate(A_T);

        for (int i = 0; i < count; i++)
        {
            ////////////////////随机生成和螺旋形状//////////////////
            #region 随机生成和螺旋形状
            ///////////////////控制了双螺旋中的碱基序列
            obj[i + 1] = RandomCreate();
    
            obj[i+1].transform.position = new Vector3(0, i *1.5f, 0);
            obj[i+1].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
            obj[i+1].transform.parent = this.transform;
            #endregion

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
        }
        #region
    

        for (int i = 1; i < count; i++)
        {
            #region 磷酸二脂键的连接
            #region 以A_T为基础单元
            
            if (obj[i].transform.name == "A_T test(Clone)")
            {
                if (obj[i+1].transform.name == "A_T test(Clone)")
                {
                    #region 在T一侧产生磷酸二脂键
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject T_p2 = obj[i+1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject T_line;
                    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    T_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5f);
                    T_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    T_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112+(i-1) * 36, -95));
                    //Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    //newmaterial.SetColor("_Color", Color.black);
                    //T_line.GetComponent<MeshRenderer>().material = newmaterial;
                    T_line.GetComponent<Renderer>().material.color=Color.black;
                    T_line.transform.name = "LSEZJ_R";
                    T_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion

                    #region  在A 一侧产生磷酸二脂键
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;
                    GameObject A_p2 = obj[i+1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject A_line;
                    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    A_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5F);
                    A_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    A_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    //A_line.GetComponent<MeshRenderer>().material = newmaterial;
                    A_line.GetComponent<Renderer>().material.color = Color.black;
                    A_line.transform.name = "LSEZJ_L";
                    A_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion
                }
                else if (obj[i+1].transform.name == "T_A test (Clone)")
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
                    AT_line.GetComponent<Renderer>().material.color = Color.black;
                    AT_line.transform.name = "LSEZJ_L";
                    AT_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion
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
                    AC_line.GetComponent<Renderer>().material.color = Color.black;
                    AC_line.transform.name = "LSEZJ_L";
                    AC_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion
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
                    AG_line.GetComponent<Renderer>().material.color = Color.black;
                    AG_line.transform.name = "LSEZJ_L";
                    AG_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion
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
                    C_line.GetComponent<Renderer>().material.color = Color.black;
                    C_line.transform.name = "LSEZJ_L";
                    C_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion
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
                    CG_line.GetComponent<Renderer>().material.color = Color.black;
                    CG_line.transform.name = "LSEZJ_L";
                    CG_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion
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
                    CA_line.GetComponent<Renderer>().material.color = Color.black;
                    CA_line.transform.name = "LSEZJ_L";
                    CA_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion
                }
                //if (obj[i+1].transform.name == "T_A test (Clone)")
                else
                {
                    #region 在G_A一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject A_p2 = obj[i+1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject GA_line;
                    GA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GA_line.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
                    GA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    GA_line.GetComponent<Renderer>().material.color = Color.black;
                    GA_line.transform.name = "LSEZJ_R";
                    GA_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                    #region 在C_T一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject T_p2 = obj[i+1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject CT_line;
                    CT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CT_line.transform.position = Vector3.Lerp(C_p1.transform.position, T_p2.transform.position, 0.5f);
                    CT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    CT_line.GetComponent<Renderer>().material.color = Color.black;
                    CT_line.transform.name = "LSEZJ_L";
                    CT_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion
                }
            }

            #endregion

            #region 以T_A为基础单元
            else if (obj[i].transform.name.ToString() == "T_A test (Clone)")
            {
                if (obj[i+1].transform.name.ToString() == "T_A test (Clone)")
                {

                    #region 在A一侧产生磷酸二脂键
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject A_p2 = obj[i+1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject A_line;
                    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    A_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5f);
                    A_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    A_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    A_line.GetComponent<Renderer>().material.color = Color.black;
                    A_line.transform.name = "LSEZJ_R";
                    A_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region  在T 一侧产生磷酸二脂键
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;
                    GameObject T_p2 = obj[i+1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject T_line;
                    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    T_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5F);
                    T_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    T_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    T_line.GetComponent<Renderer>().material.color = Color.black;
                    T_line.transform.name = "LSEZJ_L";
                    T_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion
                }
                else if (obj[i+1].transform.name.ToString() == "A_T test(Clone)")
                {
                    #region  在A_T一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;
                    GameObject T_p2 = obj[i+1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject AT_line;
                    AT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    AT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AT_line.transform.position = Vector3.Lerp(A_p1.transform.position, T_p2.transform.position, 0.5f);
                    AT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    AT_line.GetComponent<Renderer>().material.color = Color.black;
                    AT_line.transform.name = "LSEZJ_R";
                    AT_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region  在T_A一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;
                    GameObject A_p2 = obj[i+1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject TA_line;
                    TA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    TA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TA_line.transform.position = Vector3.Lerp(T_p1.transform.position, A_p2.transform.position, 0.5F);
                    TA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    TA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TA_line.GetComponent<Renderer>().material.color = Color.black;
                    TA_line.transform.name = "LSEZJ_L";
                    TA_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion
                }
                else if (obj[i+1].transform.name.ToString() == "C_G test(Clone)")
                {
                    #region  在A_G一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i+1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject AG_line;
                    AG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AG_line.transform.position = Vector3.Lerp(A_p1.transform.position, G_p2.transform.position, 0.5f);
                    AG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    AG_line.GetComponent<Renderer>().material.color = Color.black;
                    AG_line.transform.name = "LSEZJ_R";
                    AG_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region 在T_C一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i+1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject TC_line;
                    TC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TC_line.transform.position = Vector3.Lerp(T_p1.transform.position, C_p2.transform.position, 0.5f);
                    TC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    TC_line.GetComponent<Renderer>().material.color = Color.black;
                    TC_line.transform.name = "LSEZJ_L";
                    TC_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion
                }
                //if (obj[i+1].transform.name == "G_C test(Clone)")
                else
                {
                    #region  在A_C一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i+1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject AC_line;
                    AC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AC_line.transform.position = Vector3.Lerp(A_p1.transform.position, C_p2.transform.position, 0.5f);
                    AC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AC_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    AC_line.GetComponent<Renderer>().material.color = Color.black;
                    AC_line.transform.name = "LSEZJ_R";
                    AC_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion

                    #region 在T_G一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i+1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject TG_line;
                    TG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TG_line.transform.position = Vector3.Lerp(T_p1.transform.position, G_p2.transform.position, 0.5f);
                    TG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TG_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    TG_line.GetComponent<Renderer>().material.color = Color.black;
                    TG_line.transform.name = "LSEZJ_L";
                    TG_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion
                }
            }


            #endregion

            #region 以G_C为基础单元
            if (obj[i].transform.name == "G_C test(Clone)")
            {

                if (obj[i+1].transform.name == "G_C test(Clone)")
                {
                    #region 在C一侧产生磷酸二脂键
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").transform.gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i+1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject C_line;
                    C_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    C_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    C_line.transform.position = Vector3.Lerp(C_p1.transform.position, C_p2.transform.position, 0.5f);
                    C_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    C_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    C_line.GetComponent<Renderer>().material.color = Color.black;
                    C_line.transform.name = "LSEZJ_R";
                    C_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G一侧产生磷酸二脂键
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i+1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject G_line;
                    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    G_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
                    G_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    G_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    G_line.GetComponent<Renderer>().material.color = Color.black;
                    G_line.transform.name = "LSEZJ_L";
                    G_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion
                }
                else if (obj[i+1].transform.name == "C_G test(Clone)")
                {
                    #region 在C_G一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i+1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject CG_line;
                    CG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    CG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CG_line.transform.position = Vector3.Lerp(C_p1.transform.position, G_p2.transform.position, 0.5f);
                    CG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    CG_line.GetComponent<Renderer>().material.color = Color.black;
                    CG_line.transform.name = "LSEZJ_R";
                    CG_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G_C一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i+1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject GC_line;
                    GC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    GC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GC_line.transform.position = Vector3.Lerp(G_p1.transform.position, C_p2.transform.position, 0.5f);
                    GC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    GC_line.GetComponent<Renderer>().material.color = Color.black;
                    GC_line.transform.name = "LSEZJ_L";
                    GC_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion
                }
                else if (obj[i+1].transform.name == "A_T test(Clone)")
                {
                    #region 在C_T一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject T_p2 = obj[i+1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject CT_line;
                    CT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CT_line.transform.position = Vector3.Lerp(C_p1.transform.position, T_p2.transform.position, 0.5f);
                    CT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    CT_line.GetComponent<Renderer>().material.color = Color.black;
                    CT_line.transform.name = "LSEZJ_R";
                    CT_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G_A一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject A_p2 = obj[i+1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject GA_line;
                    GA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GA_line.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
                    GA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    GA_line.GetComponent<Renderer>().material.color = Color.black;
                    GA_line.transform.name = "LSEZJ_L";
                    GA_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion
                }
                //if (obj[i+1].transform.name == "T_A test (Clone)")
                else
                {
                    #region 在C_A一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject A_p2 = obj[i+1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject CA_line;
                    CA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CA_line.transform.position = Vector3.Lerp(C_p1.transform.position, A_p2.transform.position, 0.5f);
                    CA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -112 + (i - 1) * 36, -95));
                    CA_line.GetComponent<Renderer>().material.color = Color.black;
                    CA_line.transform.name = "LSEZJ_R";
                    CA_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G_T一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject T_p2 = obj[i+1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject GT_line;
                    GT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GT_line.transform.position = Vector3.Lerp(G_p1.transform.position, T_p2.transform.position, 0.5f);
                    GT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, (i - 2) * 36, 85));
                    GT_line.GetComponent<Renderer>().material.color = Color.black;
                    GT_line.transform.name = "LSEZJ_L";
                    GT_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion

                }
            }
            #endregion

            #endregion
        }
        #endregion

       this.gameObject.transform.position = new Vector3(-20F, -13f, 20F);


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
        int a = Random.Range(1, 101);//Range是左开又闭，随机产生[1,100]的数
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


    public void Next()
    {
        SceneManager.LoadScene("Peidui");
    }
    public void Return()
    {
        SceneManager.LoadScene("KnowDNA");
    }

    public void Reload()
    {
        SceneManager.LoadScene("3D_DNA");
    }
}



