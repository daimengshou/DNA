using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Iniceshi : MonoBehaviour
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
        Rotation();
    }


    void Init()
    {


        //obj[0] = GameObject.Instantiate(A_T);

        for (int i = 1; i < count;i++)
        {
            ////////////////////随机生成和螺旋形状//////////////////
            #region 随机生成和螺旋形状
            obj[i] = RandomCreate();
            obj[i].transform.position = new Vector3(0, i * 1.5f, 0);
            obj[i].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
            obj[i].transform.parent = this.transform;
            #endregion


        }



        #region
        for (int i = 1; i < obj.Length; i++)
        {

            #region   只存在两类预设体情况下的磷酸二脂键的连接
            //if (obj[i].transform.name == "A_T test(Clone)" && obj[i + 1].transform.name == "A_T test(Clone)")
            //{
            //    print("A_T");
            //    #region 在T一侧产生磷酸二脂键
            //    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
            //    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
            //    GameObject T_line;
            //    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
            //    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5f);
            //    T_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    T_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
            //    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
            //    newmaterial.SetColor("_Color", Color.black);
            //    T_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    T_line.transform.parent = this.transform;
            //    #endregion


            //    #region  在A 一侧产生磷酸二脂键
            //    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;
            //    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
            //    GameObject A_line;
            //    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5F);
            //    A_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
            //    A_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    A_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    A_line.transform.parent = this.transform;
            //    #endregion
            //}

            //else if (obj[i].transform.name == "C_G test(Clone)" && obj[i + 1].transform.name == "C_G test(Clone)")
            //{
            //    print("C_G");
            //    #region 在G一侧产生磷酸二脂键
            //    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;//寻找实例化后的p1
            //    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
            //    GameObject G_line;
            //    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
            //    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
            //    G_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    G_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
            //    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
            //    newmaterial.SetColor("_Color", Color.black);
            //    G_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    G_line.transform.parent = this.transform;
            //    #endregion


            //    #region 在C一侧产生磷酸二脂键
            //    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;//寻找实例化后的p1
            //    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
            //    GameObject C_line;
            //    C_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
            //    C_line.transform.position = Vector3.Lerp(C_p1.transform.position, C_p2.transform.position, 0.5f);
            //    C_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    C_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
            //    newmaterial.SetColor("_Color", Color.black);
            //    C_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    C_line.transform.parent = this.transform;
            //    #endregion
            //}

            //else if (obj[i].transform.name == "A_T test(Clone)" && obj[i + 1].transform.name == "C_G test(Clone)")
            //{
            //    print("A_T");
            //    #region
            //    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
            //    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
            //    GameObject TG_line;
            //    TG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
            //    TG_line.transform.position = Vector3.Lerp(T_p1.transform.position, G_p2.transform.position, 0.5f);
            //    TG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    TG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
            //    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
            //    newmaterial.SetColor("_Color", Color.black);
            //    TG_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    TG_line.transform.parent = this.transform;
            //    #endregion


            //    #region 在C一侧产生磷酸二脂键
            //    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;//寻找实例化后的p1
            //    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
            //    GameObject AC_line;
            //    AC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
            //    AC_line.transform.position = Vector3.Lerp(A_p1.transform.position, C_p2.transform.position, 0.5f);
            //    AC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    AC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
            //    newmaterial.SetColor("_Color", Color.black);
            //    AC_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    AC_line.transform.parent = this.transform;
            //    #endregion
            //}


            //else if (obj[i].transform.name == "C_G test(Clone)" && obj[i + 1].transform.name == "A_T test(Clone)")
            //{
            //    print("C_A");
            //    #region
            //    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;//寻找实例化后的p1
            //    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
            //    GameObject TG_line;
            //    TG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
            //    TG_line.transform.position = Vector3.Lerp(G_p1.transform.position, T_p2.transform.position, 0.5f);
            //    TG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    TG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
            //    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
            //    newmaterial.SetColor("_Color", Color.black);
            //    TG_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    TG_line.transform.parent = this.transform;
            //    #endregion


            //    #region 在C一侧产生磷酸二脂键
            //    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;//寻找实例化后的p1
            //    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
            //    GameObject AC_line;
            //    AC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
            //    AC_line.transform.position = Vector3.Lerp(C_p1.transform.position, A_p2.transform.position, 0.5f);
            //    AC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            //    AC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
            //    newmaterial.SetColor("_Color", Color.black);
            //    AC_line.GetComponent<MeshRenderer>().material = newmaterial;
            //    AC_line.transform.parent = this.transform;
            //    #endregion
            //}
            #endregion

            #region 磷酸二脂键的连接
            #region 以A_T为基础单元
            if (obj[i].transform.name == "A_T test(Clone)")
            {

                if (obj[i + 1].transform.name == "A_T test(Clone)")
                {
                    #region 在T一侧产生磷酸二脂键
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject T_line;
                    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5f);
                    T_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    T_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    T_line.GetComponent<MeshRenderer>().material = newmaterial;
                    T_line.transform.parent = this.transform;
                    #endregion

                    #region  在A 一侧产生磷酸二脂键
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject A_line;
                    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5F);
                    A_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    A_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    A_line.GetComponent<MeshRenderer>().material = newmaterial;
                    A_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "T_A test (Clone)")
                {
                    #region  在T_A一侧
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject TA_line;
                    TA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    TA_line.transform.position = Vector3.Lerp(T_p1.transform.position, A_p2.transform.position, 0.5f);
                    TA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    TA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TA_line.transform.parent = this.transform;
                    #endregion

                    #region  在A_T一侧
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject AT_line;
                    AT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    AT_line.transform.position = Vector3.Lerp(A_p1.transform.position, T_p2.transform.position, 0.5F);
                    AT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    AT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AT_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "C_G test(Clone)")
                {
                    #region  在T_G一侧
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject TG_line;
                    TG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TG_line.transform.position = Vector3.Lerp(T_p1.transform.position, G_p2.transform.position, 0.5f);
                    TG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    TG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TG_line.transform.parent = this.transform;
                    #endregion

                    #region 在A_C一侧
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject AC_line;
                    AC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AC_line.transform.position = Vector3.Lerp(A_p1.transform.position, C_p2.transform.position, 0.5f);
                    AC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    AC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AC_line.transform.parent = this.transform;
                    #endregion
                }
                //if (obj[i+1].transform.name == "G_C test(Clone)")
                else
                {
                    #region  在T_C一侧
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject TC_line;
                    TC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TC_line.transform.position = Vector3.Lerp(T_p1.transform.position, C_p2.transform.position, 0.5f);
                    TC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TC_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    TC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TC_line.transform.parent = this.transform;
                    #endregion

                    #region 在A_G一侧
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject AG_line;
                    AG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AG_line.transform.position = Vector3.Lerp(A_p1.transform.position, G_p2.transform.position, 0.5f);
                    AG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AG_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    AG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AG_line.transform.parent = this.transform;
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
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject G_line;
                    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
                    G_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    G_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    G_line.GetComponent<MeshRenderer>().material = newmaterial;
                    G_line.transform.parent = this.transform;
                    #endregion

                    #region 在C一侧产生磷酸二脂键
                    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject C_line;
                    C_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    C_line.transform.position = Vector3.Lerp(C_p1.transform.position, C_p2.transform.position, 0.5f);
                    C_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    C_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    C_line.GetComponent<MeshRenderer>().material = newmaterial;
                    C_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "G_C test(Clone)")
                {
                    #region 在G_C一侧
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject GC_line;
                    GC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    GC_line.transform.position = Vector3.Lerp(G_p1.transform.position, C_p2.transform.position, 0.5f);
                    GC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GC_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    GC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GC_line.transform.parent = this.transform;
                    #endregion

                    #region 在C_G一侧
                    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject CG_line;
                    CG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    CG_line.transform.position = Vector3.Lerp(C_p1.transform.position, G_p2.transform.position, 0.5f);
                    CG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CG_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    CG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CG_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "A_T test(Clone)")
                {
                    #region 在G_T一侧
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject GT_line;
                    GT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GT_line.transform.position = Vector3.Lerp(G_p1.transform.position, T_p2.transform.position, 0.5f);
                    GT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    GT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GT_line.transform.parent = this.transform;
                    #endregion

                    #region 在C_A一侧
                    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject CA_line;
                    CA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CA_line.transform.position = Vector3.Lerp(C_p1.transform.position, A_p2.transform.position, 0.5f);
                    CA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    CA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CA_line.transform.parent = this.transform;
                    #endregion
                }
                //if (obj[i+1].transform.name == "T_A test (Clone)")
                else
                {
                    #region 在G_A一侧
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject GA_line;
                    GA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GA_line.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
                    GA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    GA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GA_line.transform.parent = this.transform;
                    #endregion

                    #region 在C_T一侧
                    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject CT_line;
                    CT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CT_line.transform.position = Vector3.Lerp(C_p1.transform.position, T_p2.transform.position, 0.5f);
                    CT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    CT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CT_line.transform.parent = this.transform;
                    #endregion
                }
            }
            #endregion

            #region 以T_A为基础单元
            else if (obj[i].transform.name.ToString() == "T_A test (Clone)")
            {
                if (obj[i + 1].transform.name.ToString() == "T_A test (Clone)")
                {

                    #region 在A一侧产生磷酸二脂键
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject A_line;
                    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5f);
                    A_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    A_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    A_line.GetComponent<MeshRenderer>().material = newmaterial;
                    A_line.transform.parent = this.transform;
                    #endregion

                    #region  在T 一侧产生磷酸二脂键
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject T_line;
                    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5F);
                    T_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    T_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    T_line.GetComponent<MeshRenderer>().material = newmaterial;
                    T_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name.ToString() == "A_T test(Clone)")
                {
                    #region  在A_T一侧
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject AT_line;
                    AT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    AT_line.transform.position = Vector3.Lerp(A_p1.transform.position, T_p2.transform.position, 0.5f);
                    AT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    AT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AT_line.transform.parent = this.transform;
                    #endregion

                    #region  在T_A一侧
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject TA_line;
                    TA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    TA_line.transform.position = Vector3.Lerp(T_p1.transform.position, A_p2.transform.position, 0.5F);
                    TA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    TA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TA_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name.ToString() == "C_G test(Clone)")
                {
                    #region  在A_G一侧
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject AG_line;
                    AG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AG_line.transform.position = Vector3.Lerp(A_p1.transform.position, G_p2.transform.position, 0.5f);
                    AG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    AG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AG_line.transform.parent = this.transform;
                    #endregion

                    #region 在T_C一侧
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject TC_line;
                    TC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TC_line.transform.position = Vector3.Lerp(T_p1.transform.position, C_p2.transform.position, 0.5f);
                    TC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    TC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TC_line.transform.parent = this.transform;
                    #endregion
                }
                //if (obj[i+1].transform.name == "G_C test(Clone)")
                else
                {
                    #region  在A_C一侧
                    GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject AC_line;
                    AC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AC_line.transform.position = Vector3.Lerp(A_p1.transform.position, C_p2.transform.position, 0.5f);
                    AC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    AC_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    AC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    AC_line.transform.parent = this.transform;
                    #endregion

                    #region 在T_G一侧
                    GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject TG_line;
                    TG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    TG_line.transform.position = Vector3.Lerp(T_p1.transform.position, G_p2.transform.position, 0.5f);
                    TG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    TG_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    TG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    TG_line.transform.parent = this.transform;
                    #endregion
                }
            }
            #endregion

            #region 以G_C为基础单元
            if (obj[i].transform.name == "G_C test(Clone)")
            { 
                if (obj[i + 1].transform.name == "G_C test(Clone)")
                {
                    #region 在C一侧产生磷酸二脂键
                    GameObject C_p1 = obj[i].transform.Find("C_p1").transform.gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject C_line;
                    C_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    C_line.transform.position = Vector3.Lerp(C_p1.transform.position, C_p2.transform.position, 0.5f);
                    C_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    C_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    C_line.GetComponent<MeshRenderer>().material = newmaterial;
                    C_line.transform.parent = this.transform;
                    #endregion

                    #region 在G一侧产生磷酸二脂键
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject G_line;
                    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
                    G_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    G_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    G_line.GetComponent<MeshRenderer>().material = newmaterial;
                    G_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "C_G test(Clone)")
                {
                    #region 在C_G一侧
                    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G_p2").gameObject;
                    GameObject CG_line;
                    CG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    CG_line.transform.position = Vector3.Lerp(C_p1.transform.position, G_p2.transform.position, 0.5f);
                    CG_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CG_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    CG_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CG_line.transform.parent = this.transform;
                    #endregion

                    #region 在G_C一侧
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C_p2").gameObject;
                    GameObject GC_line;
                    GC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    GC_line.transform.position = Vector3.Lerp(G_p1.transform.position, C_p2.transform.position, 0.5f);
                    GC_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GC_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    newmaterial.SetColor("_Color", Color.black);
                    GC_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GC_line.transform.parent = this.transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "A_T test(Clone)")
                {
                    #region 在C_T一侧
                    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject CT_line;
                    CT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CT_line.transform.position = Vector3.Lerp(C_p1.transform.position, T_p2.transform.position, 0.5f);
                    CT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CT_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    CT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CT_line.transform.parent = this.transform;
                    #endregion

                    #region 在G_A一侧
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject GA_line;
                    GA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GA_line.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
                    GA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    GA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GA_line.transform.parent = this.transform;
                    #endregion
                }
                //if (obj[i+1].transform.name == "T_A test (Clone)")
                else
                {
                    #region 在C_A一侧
                    GameObject C_p1 = obj[i].transform.Find("C_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A_p2").gameObject;
                    GameObject CA_line;
                    CA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CA_line.transform.position = Vector3.Lerp(C_p1.transform.position, A_p2.transform.position, 0.5f);
                    CA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    CA_line.transform.localRotation = Quaternion.Euler(new Vector3(100, -106 + i * 36, -93));
                    Material newmaterial = new Material(Shader.Find("Unlit/Color"));
                    newmaterial.SetColor("_Color", Color.black);
                    CA_line.GetComponent<MeshRenderer>().material = newmaterial;
                    CA_line.transform.parent = this.transform;
                    #endregion

                    #region 在G_T一侧
                    GameObject G_p1 = obj[i].transform.Find("G_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;
                    GameObject GT_line;
                    GT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    GT_line.transform.position = Vector3.Lerp(G_p1.transform.position, T_p2.transform.position, 0.5f);
                    GT_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
                    GT_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, i * 36 - 36, 87));
                    GT_line.GetComponent<MeshRenderer>().material = newmaterial;
                    GT_line.transform.parent = this.transform;
                    #endregion
                }
            }
            #endregion

            #endregion
        }
        #endregion

        this.gameObject.transform.position = new Vector3(-15, 0, 50);

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

    void Rotation()
    {
        //this.transform.localRotation = Quaternion.Euler(0, 0, -90);

      this.transform.Rotate(Vector3.up, 1f);
    }

    public void OnValueChange()
    {
        Transform[] JianJiDui= GetComponentsInChildren<Transform>();

        foreach(Transform JJD in JianJiDui)
        {
            if ( JJD.gameObject.name .ToString()!= "Create")
            {
                Destroy(JJD.gameObject);
            }
            if (JJD.gameObject.name.ToString() == "Create")
            {
                JJD.gameObject.transform.position = Vector3.zero;
              JJD.gameObject.transform.rotation= Quaternion.Euler(0, 0, 0);
            }
        }
    }

    /// <summary>
    /// 用输入框来控制生成的碱基对的个数
    /// </summary>


    public InputField InputText;
    public void EndInput()
    {
        count = int.Parse(InputText.text);
        Init();
        Rotation();

       
    }
}

