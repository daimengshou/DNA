using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class Clip : MonoBehaviour
{
    /// <summary>
    /// 为了存放解旋后的DNA双链；
    /// </summary>
    public GameObject DNA_ONE;
    public GameObject DNA_TWO;
    public GameObject DNA_ONE_NEW;//为了之后的旋转展示，因此转换了父对象
    public GameObject First;
    public GameObject Late;
    public GameObject Pianduan;


    /// ////////////预设体
    GameObject A_T;
   GameObject T_A;
   GameObject C_G;
   GameObject G_C;



    //用来做游离碱基的预设体
    public GameObject A_L;
    public GameObject A_R;
    public GameObject T_L;
    public GameObject T_R;
    public GameObject C_L;
    public GameObject C_R;
    public GameObject G_L;
    public GameObject G_R;

    public GameObject Prefab_empty;

//用在控制解旋只能从头或尾开始
    bool IsOn = false;

    //用来控制复制另外两条单链的变量
    GameObject LJJ_L;
    GameObject LJJ_R;
    GameObject NewJianJiDui_L;
    GameObject NewJianJiDui_R;
    GameObject New_L;
    GameObject New_R;
    Vector3 Pos_L;
    Vector3 Pos_R;
    Quaternion Rotation_R;
    bool isStart = true;

    List<GameObject> jjd = new List<GameObject>();
    List<GameObject> jjd_l = new List<GameObject>();

    LineRenderer lineRender;
    LineRenderer lineRender_L;

    GameObject LSEZJ_L;
    GameObject LSEZJ_R;
    GameObject LSEZJ_L_OLD;
    GameObject LSEZJ_R_OLD;

    /// <summary>
    /// ////没有延迟效果下所需变量
    /// </summary>
    //GameObject LSEZJ_l;
    //GameObject LSEZJ_r;
    //GameObject LSEZJ_l_old;
    //GameObject LSEZJ_r_old;

    public GameObject YLJJ;


    ////////////用来存放新成链的氢键和磷酸二脂键////////////
    GameObject QJ_L;
    GameObject LSEZJ_R_NEW;
    GameObject LSEZJ_L_NEW;

    public GameObject LianjiemeiBtn;

    // Use this for initialization
    void Start()
    {
        lineRender =DNA_ONE. gameObject.GetComponent<LineRenderer>();
        lineRender_L = DNA_TWO.gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == true)
        {
            Transform[] JJD = DNA_ONE.GetComponentsInChildren<Transform>();
            foreach (Transform JianJiDui in JJD)
            {
                if (JianJiDui.transform.tag == "JJD")
                {
                    jjd.Add(JianJiDui.transform.gameObject);

                }
            }
            isStart= false;

        }
       
    }

    private void OnTriggerEnter(Collider other)
    {


        // print("碰到了");
        /////////////使DNA双链解旋，氢键断裂//////////////////////
        /////////////为了控制其从所模拟的DNA片段的头尾开始解旋///////////////////////////
        DNA_ONE.GetComponent<Rotation>().enabled = false;
        Transform[] QJ = other.GetComponentsInChildren<Transform>();
        
         if ((other.gameObject.transform.tag == "JJD_ONE" || other.gameObject.transform.tag == "JJD_LAST"))
        {
           other.GetComponent<BoxCollider>().enabled = false;

            IsOn = true;


            #region 解旋且复制完成
            if (other.gameObject.transform.tag == "JJD_LAST")
            {
                DNA_ONE_NEW.AddComponent<Rotation_DNATWO>();
                DNA_TWO.AddComponent<Rotation_DNATWO>();
                Destroy(YLJJ.gameObject);
                Destroy(this.gameObject);
            }
            #endregion

            if (other.gameObject.transform.tag == "JJD_ONE")
            {
                First.SetActive(true);
                Late.SetActive(true);
                foreach (Transform qj in QJ)
                {

                    if (qj.transform.name == "QJ_R")
                    {
                        //Destroy(qj.transform.gameObject);   //使氢键断裂
                     StartCoroutine(MoveJianJiUp(qj.gameObject));
                        //StartCoroutine(MoveJianJiDown(qj.gameObject));
                        qj.gameObject.SetActive(false);
                    }
                    if (qj.transform.name == "QJ_L")
                    {
                        //Destroy(qj.transform.gameObject);   //使氢键断裂
                        StartCoroutine(MoveJianJiDown(qj.gameObject));
                       // StartCoroutine(MoveJianJiUp(qj.gameObject));
               
                        qj.gameObject.SetActive(false);
                    }
                    if (qj.transform.name == "LSEZJ_R_New")
                    {
                        StartCoroutine(MoveJianJiDown(qj.gameObject));
                       // StartCoroutine(MoveJianJiUp(qj.gameObject));
                    }
                    if (qj.transform.name == "LSEZJ_L_New")
                    {
                       StartCoroutine(MoveJianJiUp(qj.gameObject));
                        //StartCoroutine(MoveJianJiDown(qj.gameObject));
                    }
                    if (qj.transform.name == "A_T test(Clone)")
                    {
                        LJJ_L = qj.transform.Find("A").transform.gameObject;
                        A_T = GameObject.Instantiate(Prefab_empty);
                        A_T.transform.name = "A_T";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = A_T.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = A_T.transform;
                        A_T.transform.parent = DNA_TWO.transform;
                        //LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("T").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent = A_T.transform;
                        jjd_l.Add(A_T.gameObject);
                        New_L.SetActive(false);
                        New_R.SetActive(false);

                        if (qj.transform.tag == "JJD_ONE")
                        {
                            A_T.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            A_T.transform.tag = "JJD_LAST_L";
                        }

                    }
                    if (qj.transform.name == "T_A test (Clone)")
                    {


                        LJJ_L = qj.transform.Find("T").transform.gameObject;
                        T_A = GameObject.Instantiate(Prefab_empty);
                        T_A.transform.name = "T_A";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = T_A.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = T_A.transform;
                        T_A.transform.parent = DNA_TWO.transform;
                        // LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("A").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent = T_A.transform;
                        jjd_l.Add(T_A.gameObject);
                        New_L.SetActive(false);
                        New_R.SetActive(false);

                        if (qj.transform.tag == "JJD_ONE")
                        {
                            T_A.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            T_A.transform.tag = "JJD_LAST_L";
                        }
                    }
                    if (qj.transform.name == "C_G test(Clone)")
                    {


                        LJJ_L = qj.transform.Find("C").transform.gameObject;
                        C_G = GameObject.Instantiate(Prefab_empty);
                        C_G.transform.name = "C_G";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = C_G.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = C_G.transform;
                        C_G.transform.parent = DNA_TWO.transform;
                        //LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("G").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent = C_G.transform;
                        jjd_l.Add(C_G.gameObject);
                        New_L.SetActive(false);
                        New_R.SetActive(false);

                        if (qj.transform.tag == "JJD_ONE")
                        {
                            C_G.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            C_G.transform.tag = "JJD_LAST_L";
                        }

                    }
                    if (qj.transform.name == "G_C test(Clone)")
                    {


                        LJJ_L = qj.transform.Find("G").transform.gameObject;
                        G_C = GameObject.Instantiate(Prefab_empty);
                        G_C.transform.name = "G_C";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = G_C.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = G_C.transform;
                        G_C.transform.parent = DNA_TWO.transform;
                        //  LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("C").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent = G_C.transform;
                        jjd_l.Add(G_C.gameObject);
                        New_L.SetActive(false);
                        New_R.SetActive(false);

                        if (qj.transform.tag == "JJD_ONE")
                        {
                            G_C.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            G_C.transform.tag = "JJD_LAST_L";
                        }
                    }

                }
            }
            if (other.gameObject.transform.tag == "JJD_LAST")
            {
                LianjiemeiBtn.GetComponent<Button>().enabled = true;
                foreach (Transform qj in QJ)
                {

                    if (qj.transform.name == "QJ_R")
                    {
                        //Destroy(qj.transform.gameObject);   //使氢键断裂
                         StartCoroutine(MoveJianJiUp(qj.gameObject));
                        //StartCoroutine(MoveJianJiDown(qj.gameObject));
                    }
                    if (qj.transform.name == "QJ_L")
                    {
                        //Destroy(qj.transform.gameObject);   //使氢键断裂
                        StartCoroutine(MoveJianJiDown(qj.gameObject));        
                        //StartCoroutine(MoveJianJiUp(qj.gameObject));
                    }

                    if (qj.transform.name == "A_T test(Clone)")
                    {


                        LJJ_L = qj.transform.Find("A").transform.gameObject;
                        A_T = GameObject.Instantiate(Prefab_empty);
                        A_T.transform.name = "A_T";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = A_T.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = A_T.transform;
                        A_T.transform.parent = DNA_TWO.transform;
                        //LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);

                        LJJ_R = qj.transform.Find("T").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        New_R.transform.parent = A_T.transform;
                        jjd_l.Add(A_T.gameObject);
                        if (qj.transform.tag == "JJD_ONE")
                        {
                            A_T.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            A_T.transform.tag = "JJD_LAST_L";
                        }

                    }
                    if (qj.transform.name == "T_A test (Clone)")
                    {


                        LJJ_L = qj.transform.Find("T").transform.gameObject;
                        T_A = GameObject.Instantiate(Prefab_empty);
                        T_A.transform.name = "T_A";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = T_A.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = T_A.transform;
                        T_A.transform.parent = DNA_TWO.transform;
                        // LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);

                        LJJ_R = qj.transform.Find("A").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        New_R.transform.parent = T_A.transform;
                        jjd_l.Add(T_A.gameObject);
                        if (qj.transform.tag == "JJD_ONE")
                        {
                            T_A.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            T_A.transform.tag = "JJD_LAST_L";
                        }
                    }
                    if (qj.transform.name == "C_G test(Clone)")
                    {


                        LJJ_L = qj.transform.Find("C").transform.gameObject;
                        C_G = GameObject.Instantiate(Prefab_empty);
                        C_G.transform.name = "C_G";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = C_G.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = C_G.transform;
                        C_G.transform.parent = DNA_TWO.transform;
                        //LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);

                        LJJ_R = qj.transform.Find("G").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        New_R.transform.parent = C_G.transform;
                        jjd_l.Add(C_G.gameObject);
                        if (qj.transform.tag == "JJD_ONE")
                        {
                            C_G.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            C_G.transform.tag = "JJD_LAST_L";
                        }

                    }
                    if (qj.transform.name == "G_C test(Clone)")
                    {


                        LJJ_L = qj.transform.Find("G").transform.gameObject;
                        G_C = GameObject.Instantiate(Prefab_empty);
                        G_C.transform.name = "G_C";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = G_C.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = G_C.transform;
                        G_C.transform.parent = DNA_TWO.transform;
                        //  LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);

                        LJJ_R = qj.transform.Find("C").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        New_R.transform.parent = G_C.transform;
                        jjd_l.Add(G_C.gameObject);
                        if (qj.transform.tag == "JJD_ONE")
                        {
                            G_C.transform.tag = "JJD_ONE_L";
                        }
                        if (qj.transform.tag == "JJD_LAST")
                        {
                            G_C.transform.tag = "JJD_LAST_L";
                        }
                    }

                }
            }
            if (other.gameObject.transform.tag == "JJD_LAST")
            {
                Pianduan.SetActive(false);
                First.SetActive(false);
                Late.SetActive(false);

                if (jjd[jjd.Count - 3].transform.name == "A_T test(Clone)")
                {
                    jjd[jjd.Count - 3].transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 4].transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                    jjd_l[jjd_l.Count - 4].transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(false );

                }
            if (jjd[jjd.Count - 3].transform.name == "T_A test (Clone)")
            {
                jjd[jjd.Count - 3].transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 4].transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                    jjd_l[jjd_l.Count - 4].transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
            }
            if (jjd[jjd.Count - 3].transform.name == "C_G test(Clone)")
            {
                jjd[jjd.Count - 3].transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 4].transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                    jjd_l[jjd_l.Count - 4].transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(false );
            }
            if (jjd[jjd.Count - 3].transform.name == "G_C test(Clone)")
            {
                jjd[jjd.Count - 3].transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 4].transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                    jjd_l[jjd_l.Count - 4].transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
            }


                if (jjd[jjd.Count - 2].transform.name == "A_T test(Clone)")
                {
                    jjd[jjd.Count - 2].transform.Find("A").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("T").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true  );
                    jjd[jjd.Count - 2].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 2].transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 2].transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count - 3].transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 3].transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }
                if (jjd[jjd.Count - 2].transform.name == "T_A test (Clone)")
                {
                    jjd[jjd.Count - 2].transform.Find("T").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("A").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true  );
                    jjd[jjd.Count - 2].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 2].transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 2].transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count - 3].transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 3].transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }
                if (jjd[jjd.Count - 2].transform.name == "C_G test(Clone)")
                {
                    jjd[jjd.Count - 2].transform.Find("C").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("G").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true );
                    jjd[jjd.Count - 2].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 2].transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 2].transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count - 3].transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 3].transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }
                if (jjd[jjd.Count - 2].transform.name == "G_C test(Clone)")
                {
                    jjd[jjd.Count - 2].transform.Find("G").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("C").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                    jjd[jjd.Count - 2].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 3].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 2].transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 2].transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count - 3].transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 3].transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }


                if (jjd[jjd.Count - 1].transform.name == "A_T test(Clone)")
                {
                    jjd[jjd.Count - 1].transform.Find("A").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("T").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 1].transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count -2].transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 2].transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }
                if (jjd[jjd.Count - 1].transform.name == "T_A test (Clone)")
                {
                    jjd[jjd.Count - 1].transform.Find("T").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("A").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 1].transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count - 2].transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 2].transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }
                if (jjd[jjd.Count - 1].transform.name == "C_G test(Clone)")
                {
                    jjd[jjd.Count - 1].transform.Find("C").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("G").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 1].transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count - 2].transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 2].transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }
                if (jjd[jjd.Count - 1].transform.name == "G_C test(Clone)")
                {
                    jjd[jjd.Count - 1].transform.Find("G").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("C").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("QJ_R").gameObject.SetActive(true);
                    jjd_l[jjd_l.Count - 2].transform.Find("QJ_L").gameObject.SetActive(true);
                    jjd[jjd.Count - 1].transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                    jjd[jjd.Count - 1].transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    jjd_l[jjd_l.Count - 2].transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                    jjd_l[jjd_l.Count - 2].transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                }
            }

            #region 随着解旋位置的移动，实时绘制磷酸二脂键
            if (other.gameObject.transform.tag == "JJD_ONE")
            {

                if (other.transform.name == "A_T test(Clone)")
                {

                    
                     Vector3 startPos_R= other.transform.Find("T").transform.Find("T_p1").transform.position;
                    Vector3 endPos_R;
                    GameObject other_l = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                    Vector3 startPos_L = other_l.transform.Find("A").transform.Find("A_p1").transform.position;
                    Vector3 endPos_L;
                    LSEZJ_L = other_l.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R = other.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L.SetActive(false);
                    LSEZJ_R.SetActive(false);
                    //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_l= other_l.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l.SetActive(false);
                    //LSEZJ_r.SetActive(false);

                    for (int i = 0; i < 1; i++)
                    {
                    if (jjd[i].transform.name == "A_T test(Clone)")
                    {
                       endPos_R=jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                       Vector3 controlPos_R=  CalcControlPos(startPos_R, endPos_R, 0.05f);
                       GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                        Vector3 controlPos_L= CalcControlPos(startPos_L, endPos_L, 0.05f);
                        GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);

                        }
                    if (jjd[i].transform.name == "T_A test (Clone)")
                    {
                        endPos_R=jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                         GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "C_G test(Clone)")
                    {
                        endPos_R= jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                         GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "G_C test(Clone)")
                    {
                        endPos_R=jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                         endPos_L = jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                         Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                         GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    }


                }
                if (other.transform.name == "T_A test (Clone)")
                {

                    Vector3 startPos_R = other.transform.Find("A").transform.Find("A_p1").transform.position;
                    Vector3 endPos_R;
                    GameObject other_l = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                    Vector3 startPos_L = other_l.transform.Find("T").transform.Find("T_p1").transform.position;
                    Vector3 endPos_L;
                    LSEZJ_L = other_l.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R = other.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L.SetActive(false);
                    LSEZJ_R.SetActive(false);
                    //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_l = other_l.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l.SetActive(false);
                    //LSEZJ_r.SetActive(false);

                    for (int i = 0; i < 1; i++)
                    {
                        if (jjd[i].transform.name == "A_T test(Clone)")
                        {
                            endPos_R = jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                            endPos_L = jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (jjd[i].transform.name == "T_A test (Clone)")
                        {
                            endPos_R = jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                            endPos_L = jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (jjd[i].transform.name == "C_G test(Clone)")
                        {
                            endPos_R = jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                            endPos_L = jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (jjd[i].transform.name == "G_C test(Clone)")
                        {
                            endPos_R = jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                            endPos_L = jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    }
                }
                if (other.transform.name == "C_G test(Clone)")
                {

                    Vector3 startPos_R = other.transform.Find("G").transform.Find("G_p1").transform.position;
                    Vector3 endPos_R;
                    GameObject other_l = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                    Vector3 startPos_L = other_l.transform.Find("C").transform.Find("C_p1").transform.position;
                    Vector3 endPos_L;
                    LSEZJ_L = other_l.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R = other.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L.SetActive(false);
                    LSEZJ_R.SetActive(false);
                    //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_l = other_l.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l.SetActive(false);
                    //LSEZJ_r.SetActive(false);

                    for (int i=0;i<1;i++)
                    { 
                    if (jjd[i].transform.name == "A_T test(Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                        GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "T_A test (Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                        GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "C_G test(Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                         GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "G_C test(Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                         GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    }
                }
                if (other.transform.name == "G_C test(Clone)")
                {

                    Vector3 startPos_R = other.transform.Find("C").transform.Find("C_p1").transform.position;
                    Vector3 endPos_R;
                    GameObject other_l = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                    Vector3 startPos_L = other_l.transform.Find("G").transform.Find("G_p1").transform.position;
                    Vector3 endPos_L;
                    LSEZJ_L = other_l.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R = other.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L.SetActive(false);
                    LSEZJ_R.SetActive(false);
                    //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_l = other_l.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l.SetActive(false);
                    //LSEZJ_r.SetActive(false);

                    for (int i=0;i<1;i++)
                    { 
                    if (jjd[i].transform.name == "A_T test(Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                        GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "T_A test (Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("A").transform.Find("A_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                       endPos_L = jjd[i].transform.Find("T").transform.Find("T_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                        GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "C_G test(Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                        GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    if (jjd[i].transform.name == "G_C test(Clone)")
                    {
                        endPos_R = jjd[i].transform.Find("C").transform.Find("C_p2").transform.position;
                        Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                        GetBeizerList(startPos_R, controlPos_R, endPos_R, 50,lineRender);

                        endPos_L = jjd[i].transform.Find("G").transform.Find("G_p2").transform.position;
                        Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                         GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    }
                }
            }

            if (other.gameObject.transform.tag == "JJD_LAST")
            {
                DNA_ONE.GetComponent<LineRenderer>().enabled = false;
                DNA_TWO.GetComponent<LineRenderer>().enabled = false;
                DNA_ONE_NEW.GetComponent<Frame_R>().enabled=true;
                DNA_TWO.GetComponent<Frame_L>().enabled = true;
                 GameObject other_R = jjd[jjd.Count - 1].gameObject;
                GameObject other_l = jjd_l[jjd.Count].gameObject;
                if (other_R.transform.name == "A_T test(Clone)")
                {
                    LSEZJ_R = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L = other_l.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R.SetActive(true);
                    LSEZJ_L.SetActive(true);
                    //LSEZJ_l_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_r_old = other_l.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l_old.SetActive(true);
                    //LSEZJ_r_old.SetActive(true);
                  
                }
                if (other_R.transform.name == "T_A test (Clone)")
                {
                    LSEZJ_R = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L = other_l.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R.SetActive(true);
                    LSEZJ_L.SetActive(true);
                    //LSEZJ_l_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_r_old = other_l.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l_old.SetActive(true);
                    //LSEZJ_r_old.SetActive(true);
                }
                if (other_R.transform.name == "C_G test(Clone)")
                {
                    LSEZJ_R = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L = other_l.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R.SetActive(true);
                    LSEZJ_L.SetActive(true);
                    //LSEZJ_l_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_r_old = other_l.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l_old.SetActive(true);
                    //LSEZJ_r_old.SetActive(true);
                }
                if (other_R.transform.name == "G_C test(Clone)")
                {
                    LSEZJ_R = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                    LSEZJ_L = other_l.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                    LSEZJ_R.SetActive(true);
                    LSEZJ_L.SetActive(true);
                    //LSEZJ_l_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                    //LSEZJ_r_old = other_l.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                    //LSEZJ_l_old.SetActive(true);
                    //LSEZJ_r_old.SetActive(true);
                }

                Transform[] JianJiDui = DNA_ONE.GetComponentsInChildren<Transform>();
                foreach (Transform jianjidui in JianJiDui)
                {
                    if (jianjidui.transform.tag == "JJD_ONE" || jianjidui.transform.tag == "JJD_LAST" || jianjidui.transform.tag == "JJD")
                    {
                        jianjidui.transform.parent = DNA_ONE_NEW.transform;

                    }
                }
            }
            #endregion
        }
        if (IsOn == true)
        {
            if (other.gameObject.transform.tag == "JJD")
            {
               other.GetComponent<BoxCollider>().enabled = false;


                //  Transform[] Other_QJ = other.GetComponentsInChildren<Transform>();
                foreach (Transform qj in QJ)
                {

                    if (qj.transform.name == "QJ_R")
                    {
                        //Destroy(qj.transform.gameObject);   //使氢键断裂
                        StartCoroutine(MoveJianJiUp(qj.gameObject));
                        //StartCoroutine(MoveJianJiDown(qj.gameObject));
                        qj.gameObject.SetActive(false);
                    }
                    if (qj.transform.name == "QJ_L")
                    {
                        //Destroy(qj.transform.gameObject);   //使氢键断裂
                        StartCoroutine(MoveJianJiDown(qj.gameObject));
                        //StartCoroutine(MoveJianJiUp(qj.gameObject));
                        qj.gameObject.SetActive(false);

                    }
                    if (qj.transform.name == "LSEZJ_R_New")
                    {
                     StartCoroutine(MoveJianJiDown(qj.gameObject));
                       // StartCoroutine(MoveJianJiUp(qj.gameObject));
                    }
                    if (qj.transform.name == "LSEZJ_L_New")
                    {
                        StartCoroutine(MoveJianJiUp(qj.gameObject));
                        //StartCoroutine(MoveJianJiDown(qj.gameObject));
                    }


                    if (qj.transform.name == "A_T test(Clone)")
                    {


                        LJJ_L = qj.transform.Find("A").transform.gameObject;
                        A_T = GameObject.Instantiate(Prefab_empty);
                        A_T.transform.name = "A_T";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = A_T.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = A_T.transform;
                        A_T.transform.parent = DNA_TWO.transform;
                        //  LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("T").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent = A_T.transform;
                        jjd_l.Add(A_T.gameObject);
                        A_T.transform.tag = "JJD_L";
                        New_L.SetActive(false);
                        New_R.SetActive(false);
                    }
                    if (qj.transform.name == "T_A test (Clone)")
                    {


                        LJJ_L = qj.transform.Find("T").transform.gameObject;
                       T_A = GameObject.Instantiate(Prefab_empty);
                        T_A.transform.name = "T_A";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = T_A.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = T_A.transform;
                        T_A.transform.parent = DNA_TWO.transform;
                        //LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("A").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent =T_A.transform;
                        jjd_l.Add(T_A.gameObject);
                        T_A.transform.tag = "JJD_L";
                        New_L.SetActive(false);
                        New_R.SetActive(false);
                    }
                    if (qj.transform.name == "C_G test(Clone)")
                    {

                        LJJ_L = qj.transform.Find("C").transform.gameObject;
                        C_G = GameObject.Instantiate(Prefab_empty);
                        C_G.transform.name = "C_G";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = C_G.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = C_G.transform;
                        C_G.transform.parent = DNA_TWO.transform;
                        //  LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("G").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent = C_G.transform;
                        jjd_l.Add(C_G.gameObject);
                        C_G.transform.tag = "JJD_L";
                        New_L.SetActive(false);
                        New_R.SetActive(false);
                    }
                    if (qj.transform.name == "G_C test(Clone)")
                    {


                        LJJ_L = qj.transform.Find("G").transform.gameObject;
                        G_C = GameObject.Instantiate(Prefab_empty);
                        G_C.transform.name = "G_C";
                        Pos_L = LJJ_L.transform.position;
                        StartCoroutine(MoveJianJiDown(LJJ_L));
                        LJJ_L.transform.parent = G_C.transform;
                        QJ_L = qj.transform.Find("QJ_L").transform.gameObject;
                        QJ_L.transform.parent = G_C.transform;
                        G_C.transform.parent = DNA_TWO.transform;
                        // LJJ_L.transform.parent = DNA_TWO.transform;
                        New_L = CreateDNAPart_L(qj, Pos_L);
                        LSEZJ_L_NEW = qj.transform.Find("LSEZJ_L_New").transform.gameObject;
                        LSEZJ_L_NEW.transform.parent = New_L.transform;

                        LJJ_R = qj.transform.Find("C").transform.gameObject;
                        Pos_R = LJJ_R.transform.position;
                        StartCoroutine(MoveJianJiUp(LJJ_R));
                        Rotation_R = LJJ_R.transform.rotation;
                        New_R = CreateDNAPart_R(qj, Pos_R, Rotation_R);
                        LSEZJ_R_NEW = qj.transform.Find("LSEZJ_R_New").transform.gameObject;
                        LSEZJ_R_NEW.transform.parent = New_R.transform;
                        New_R.transform.parent = G_C.transform;
                        jjd_l.Add(G_C.gameObject);
                        G_C.transform.tag = "JJD_L";
                        New_L.SetActive(false);
                        New_R.SetActive(false);

                    }


                    // DNA_TWO.transform.position = new Vector3(0, -0.5f, 0);
                }

                #region 碱基对移动后，实时绘制用来表示磷酸二脂键的曲线
                if (jjd.IndexOf(other.transform.gameObject) < jjd.Count-1)
                { 
                    if (other.transform.name == "A_T test(Clone)")
                    {


                        Vector3 startPos_R = other.transform.Find("T").transform.Find("T_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject)+1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("A").transform.Find("A_p1").transform.position;
                        Vector3 endPos_L;


                            if (other_R.transform.name == "A_T test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                                endPos_L =other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                                Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                                GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);

                            }
                            if (other_R.transform.name == "T_A test (Clone)")
                            {
                                endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                                endPos_L = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                                Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                                GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                            }
                            if (other_R.transform.name == "C_G test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                            if (other_R.transform.name == "G_C test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                       
                    }
                    if (other.transform.name == "T_A test (Clone)")
                    {

                        Vector3 startPos_R = other.transform.Find("A").transform.Find("A_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;

                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("T").transform.Find("T_p1").transform.position;
                        Vector3 endPos_L;


                        if (other_R.transform.name == "A_T test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                            {
                                endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        
                    }
                    if (other.transform.name == "C_G test(Clone)")
                    {

                        Vector3 startPos_R = other.transform.Find("G").transform.Find("G_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;

                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("C").transform.Find("C_p1").transform.position;
                        Vector3 endPos_L;


                            if (other_R.transform.name == "A_T test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                            if (other_R.transform.name == "T_A test (Clone)")
                            {
                                endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                            if (other_R.transform.name == "C_G test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                            if (other_R.transform.name == "G_C test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        
                    }
                    if (other.transform.name == "G_C test(Clone)")
                    {

                        Vector3 startPos_R = other.transform.Find("C").transform.Find("C_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;

                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("G").transform.Find("G_p1").transform.position;
                        Vector3 endPos_L;


                            if (other_R.transform.name == "A_T test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                            if (other_R.transform.name == "T_A test (Clone)")
                            {
                                endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                            if (other_R.transform.name == "C_G test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                            if (other_R.transform.name == "G_C test(Clone)")
                            {
                                endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                                Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                                GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        }
                }

                if (jjd.IndexOf(other.transform.gameObject) == jjd.Count - 1)
                {
                    if (other.transform.name == "A_T test(Clone)")
                    {


                        Vector3 startPos_R = other.transform.Find("T").transform.Find("T_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R =GameObject.FindGameObjectWithTag("JJD_LAST");
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("A").transform.Find("A_p1").transform.position;
                        Vector3 endPos_L;

                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);

                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }

                    }
                    if (other.transform.name == "T_A test (Clone)")
                    {

                        Vector3 startPos_R = other.transform.Find("A").transform.Find("A_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_LAST");

                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("T").transform.Find("T_p1").transform.position;
                        Vector3 endPos_L;


                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }

                    }
                    if (other.transform.name == "C_G test(Clone)")
                    {

                        Vector3 startPos_R = other.transform.Find("G").transform.Find("G_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_LAST");

                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("C").transform.Find("C_p1").transform.position;
                        Vector3 endPos_L;


                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L =other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }

                    }
                    if (other.transform.name == "G_C test(Clone)")
                    {

                        Vector3 startPos_R = other.transform.Find("C").transform.Find("C_p1").transform.position;
                        Vector3 endPos_R;
                        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_LAST");

                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        Vector3 startPos_L = other_l.transform.Find("G").transform.Find("G_p1").transform.position;
                        Vector3 endPos_L;


                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            endPos_R = other_R.transform.Find("A").transform.Find("A_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("T").transform.Find("T_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            endPos_R = other_R.transform.Find("C").transform.Find("C_p2").transform.position;
                            Vector3 controlPos_R = CalcControlPos(startPos_R, endPos_R, 0.05f);
                            GetBeizerList(startPos_R, controlPos_R, endPos_R, 50, lineRender);

                            endPos_L = other_R.transform.Find("G").transform.Find("G_p2").transform.position;
                            Vector3 controlPos_L = CalcControlPos(startPos_L, endPos_L, 0.05f);
                            GetBeizerList(startPos_L, controlPos_L, endPos_L, 50, lineRender_L);
                        }
                    }
                }
                #endregion

                #region 新DNA链的氢键和磷酸二脂键显示
                //if (jjd.IndexOf(other.transform.gameObject) == 0)
                //{
                //    if (other.transform.name == "A_T test(Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R =GameObject.FindGameObjectWithTag("JJD_ONE");
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);

                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //           LSEZJ_R_OLD=  other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //           LSEZJ_R_OLD.SetActive(true);
                //           GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //           LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //           LSEZJ_L_OLD.SetActive(true);
                //           //LSEZJ_l_old=JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //           // LSEZJ_r_old=other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //           // LSEZJ_l_old.SetActive(true);
                //           // LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);

                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }

                //    }
                //    if (other.transform.name == "T_A test (Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_ONE");
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);
                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }

                //    }
                //    if (other.transform.name == "C_G test(Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_ONE");
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);

                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }

                //    }
                //    if (other.transform.name == "G_C test(Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_ONE");
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);

                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);

                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //    }
                //}
                //if (0<jjd.IndexOf(other.transform.gameObject)&& jjd.IndexOf(other.transform.gameObject)<=jjd.Count-1)
                //{
                //    if (other.transform.name == "A_T test(Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject)-1].gameObject;
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);

                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }

                //    }
                //    if (other.transform.name == "T_A test (Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);

                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }

                //    }
                //    if (other.transform.name == "C_G test(Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);

                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);

                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }

                //    }
                //    if (other.transform.name == "G_C test(Clone)")
                //    {
                //        LSEZJ_R = other.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                //        LSEZJ_L = other_l.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                //        LSEZJ_L.SetActive(false);
                //        LSEZJ_R.SetActive(false);
                //        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                //        //LSEZJ_l = other_l.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //        //LSEZJ_l.SetActive(false);
                //        //LSEZJ_r.SetActive(false);

                //        if (other_R.transform.name == "A_T test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "T_A test (Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "C_G test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //        if (other_R.transform.name == "G_C test(Clone)")
                //        {
                //            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                //            LSEZJ_R_OLD.SetActive(true);
                //            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                //            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                //            LSEZJ_L_OLD.SetActive(true);
                //            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                //            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                //            //LSEZJ_l_old.SetActive(true);
                //            //LSEZJ_r_old.SetActive(true);
                //        }
                //    }
                //}
                #endregion
                #region 新DNA链的氢键和磷酸二脂键显示
                if (jjd.IndexOf(other.transform.gameObject) == 0)
                {
                    if (other.transform.name == "A_T test(Clone)")
                    {
                        LSEZJ_R = other.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_ONE");
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);
                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                    }
                    if (other.transform.name == "T_A test (Clone)")
                    {
                        LSEZJ_R = other.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_ONE");
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);                  
                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                    }
                    if (other.transform.name == "C_G test(Clone)")
                    {
                        LSEZJ_R = other.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_ONE");
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);                  
                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                    }
                    if (other.transform.name == "G_C test(Clone)")
                    {
                        LSEZJ_R = other.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = GameObject.FindGameObjectWithTag("JJD_ONE");
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);
                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);                       
                        }
                    }
                }
                if (0 < jjd.IndexOf(other.transform.gameObject) && jjd.IndexOf(other.transform.gameObject) <= jjd.Count - 1)
                {
                    if (other.transform.name == "A_T test(Clone)")
                    {
                        LSEZJ_R = other.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);
                        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                        //LSEZJ_l = other_l.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                        //LSEZJ_l.SetActive(false);
                        //LSEZJ_r.SetActive(false);

                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }

                    }
                    if (other.transform.name == "T_A test (Clone)")
                    {
                        LSEZJ_R = other.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);
                        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                        //LSEZJ_l = other_l.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                        //LSEZJ_l.SetActive(false);
                        //LSEZJ_r.SetActive(false);

                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }

                    }
                    if (other.transform.name == "C_G test(Clone)")
                    {
                        LSEZJ_R = other.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);
                        //LSEZJ_r = other.transform.Find("LSEZJ_L_New").transform.gameObject;
                        //LSEZJ_l = other_l.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                        //LSEZJ_l.SetActive(false);
                        //LSEZJ_r.SetActive(false);

                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);

                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                            //LSEZJ_l_old = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").transform.gameObject;
                            //LSEZJ_r_old = other_R.transform.Find("LSEZJ_L_New").transform.gameObject;
                            //LSEZJ_l_old.SetActive(true);
                            //LSEZJ_r_old.SetActive(true);
                        }

                    }
                    if (other.transform.name == "G_C test(Clone)")
                    {
                        LSEZJ_R = other.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                        GameObject other_l = jjd_l[jjd.IndexOf(other.transform.gameObject) + 1].gameObject;
                        LSEZJ_L = other_l.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                        GameObject other_R = jjd[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                        LSEZJ_L.SetActive(false);
                        LSEZJ_R.SetActive(false);
                        if (other_R.transform.name == "A_T test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("T").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "T_A test (Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("A").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "C_G test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("G").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);
                        }
                        if (other_R.transform.name == "G_C test(Clone)")
                        {
                            LSEZJ_R_OLD = other_R.transform.Find("C").transform.Find("LSEZJ_R").transform.gameObject;
                            LSEZJ_R_OLD.SetActive(true);
                            GameObject JJD_ONE_L = jjd_l[jjd.IndexOf(other.transform.gameObject)].gameObject;
                            LSEZJ_L_OLD = JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_L").transform.gameObject;
                            LSEZJ_L_OLD.SetActive(true);    
                        }
                    }
                }
                if (jjd.IndexOf(other.transform.gameObject) == 1)
                {
                    GameObject JJD_ONE_L = GameObject.FindGameObjectWithTag("JJD_ONE_L");
                    GameObject JJD_ONE = GameObject.FindGameObjectWithTag("JJD_ONE");
                    if (JJD_ONE.transform.name == "A_T test(Clone)")
                    {
                        JJD_ONE.transform.Find("QJ_R").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("A").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("QJ_L").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("T").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                        JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                        JJD_ONE.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                        JJD_ONE_L.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE_L.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    }
                    if (JJD_ONE.transform.name == "T_A test (Clone)")
                    {
                        JJD_ONE.transform.Find("QJ_R").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("T").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("QJ_L").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("A").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                        JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                        JJD_ONE.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                        JJD_ONE_L.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE_L.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    }
                    if (JJD_ONE.transform.name == "C_G test(Clone)")
                    {
                        JJD_ONE.transform.Find("QJ_R").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("C").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("QJ_L").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("G").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                        JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                        JJD_ONE.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                        JJD_ONE_L.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE_L.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    }
                    if (JJD_ONE.transform.name == "G_C test(Clone)")
                    {
                        JJD_ONE.transform.Find("QJ_R").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("G").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("QJ_L").gameObject.SetActive(true);
                        JJD_ONE_L.transform.Find("C").gameObject.SetActive(true);
                        JJD_ONE.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                        JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                        JJD_ONE.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                        JJD_ONE_L.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                        JJD_ONE_L.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    }
                }
                if (1 < jjd.IndexOf(other.transform.gameObject) && jjd.IndexOf(other.transform.gameObject) <= jjd.Count - 1)
                {
                    if (jjd.IndexOf(other.transform.gameObject) == 2)
                    {
                        GameObject Other_One = jjd[jjd.IndexOf(other.transform.gameObject) - 2].gameObject;
                        //GameObject Other_Two = jjd_l[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;

                        GameObject JJD_ONE = GameObject.FindGameObjectWithTag("JJD_ONE");

                        if (Other_One.transform.name == "A_T test(Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("A").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("T").gameObject.SetActive(true);
                            Other_One.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);

                            if (JJD_ONE.transform.name == "A_T test(Clone)")
                            {
                                JJD_ONE.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "T_A test (Clone)")
                            {
                                JJD_ONE.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "C_G test(Clone)")
                            {
                                JJD_ONE.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "G_C test(Clone)")
                            {
                                JJD_ONE.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                        if (Other_One.transform.name == "T_A test (Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("T").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("A").gameObject.SetActive(true);
                            Other_One.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);

                            if (JJD_ONE.transform.name == "A_T test(Clone)")
                            {
                                JJD_ONE.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "T_A test (Clone)")
                            {
                                JJD_ONE.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "C_G test(Clone)")
                            {
                                JJD_ONE.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "G_C test(Clone)")
                            {
                                JJD_ONE.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                        if (Other_One.transform.name == "C_G test(Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("C").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("G").gameObject.SetActive(true);
                            Other_One.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);

                            if (JJD_ONE.transform.name == "A_T test(Clone)")
                            {
                                JJD_ONE.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "T_A test (Clone)")
                            {
                                JJD_ONE.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "C_G test(Clone)")
                            {
                                JJD_ONE.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "G_C test(Clone)")
                            {
                                JJD_ONE.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                        if (Other_One.transform.name == "G_C test(Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("G").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("C").gameObject.SetActive(true);
                            Other_One.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);

                            if (JJD_ONE.transform.name == "A_T test(Clone)")
                            {
                                JJD_ONE.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "T_A test (Clone)")
                            {
                                JJD_ONE.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "C_G test(Clone)")
                            {
                                JJD_ONE.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (JJD_ONE.transform.name == "G_C test(Clone)")
                            {
                                JJD_ONE.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //JJD_ONE_L.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                    }
                    if (jjd.IndexOf(other.transform.gameObject) > 2)
                    {
                        GameObject Other_One = jjd[jjd.IndexOf(other.transform.gameObject) - 2].gameObject;
                        //GameObject Other_Two = jjd_l[jjd.IndexOf(other.transform.gameObject) - 1].gameObject;
                        GameObject Other_One_Old = jjd[jjd.IndexOf(other.transform.gameObject) - 3].gameObject;
                        //GameObject Other_Two_Old = jjd_l[jjd.IndexOf(other.transform.gameObject) - 2].gameObject;

                        if (Other_One.transform.name == "A_T test(Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("A").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("T").gameObject.SetActive(true);
                            Other_One.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);

                            if (Other_One_Old.transform.name == "A_T test(Clone)")
                            {
                                Other_One_Old.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "T_A test (Clone)")
                            {
                                Other_One_Old.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "C_G test(Clone)")
                            {
                                Other_One_Old.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                               //Other_Two_Old.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "G_C test(Clone)")
                            {
                                Other_One_Old.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                               //Other_Two_Old.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                        if (Other_One.transform.name == "T_A test (Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("T").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("A").gameObject.SetActive(true);
                            Other_One.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);

                            if (Other_One_Old.transform.name == "A_T test(Clone)")
                            {
                                Other_One_Old.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "T_A test (Clone)")
                            {
                                Other_One_Old.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "C_G test(Clone)")
                            {
                                Other_One_Old.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "G_C test(Clone)")
                            {
                                Other_One_Old.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                        if (Other_One.transform.name == "C_G test(Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("C").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("G").gameObject.SetActive(true);
                            Other_One.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);

                            if (Other_One_Old.transform.name == "A_T test(Clone)")
                            {
                                Other_One_Old.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "T_A test (Clone)")
                            {
                                Other_One_Old.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "C_G test(Clone)")
                            {
                                Other_One_Old.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "G_C test(Clone)")
                            {
                                Other_One_Old.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                        if (Other_One.transform.name == "G_C test(Clone)")
                        {
                            Other_One.transform.Find("QJ_R").gameObject.SetActive(true);
                            Other_One.transform.Find("G").gameObject.SetActive(true);
                            //Other_Two.transform.Find("QJ_L").gameObject.SetActive(true);
                            //Other_Two.transform.Find("C").gameObject.SetActive(true);
                            Other_One.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(false);
                            //Other_Two.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(false);
                            Other_One.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                            Other_One.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                            //Other_Two.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                            //Other_Two.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);


                            if (Other_One_Old.transform.name == "A_T test(Clone)")
                            {
                                Other_One_Old.transform.Find("A").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                               //Other_Two_Old.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "T_A test (Clone)")
                            {
                                Other_One_Old.transform.Find("T").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "C_G test(Clone)")
                            {
                                Other_One_Old.transform.Find("C").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                            if (Other_One_Old.transform.name == "G_C test(Clone)")
                            {
                                Other_One_Old.transform.Find("G").transform.Find("LSEZJ_L_New").gameObject.SetActive(true);
                                //Other_Two_Old.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                            }
                        }
                    }
                }

                #endregion

            }


        }

        #region 冈崎片段,效果不理想
        if (jjd.IndexOf(other.transform.gameObject) == jjd.Count - 1)
        {
            for (int i = jjd.Count - 1; i > 8; i--)
            {
                StartCoroutine(CopyDNA(jjd_l[i - 1].gameObject, i));
            }
        }

        if (other.transform.tag=="JJD_LAST")
        {
            for (int i = 8; i > 0; i--)
            {
                ShowCopyDNA(jjd_l[i - 1].gameObject,i);
            }

        }
        #endregion
        /////////做的过程中的思路，最终不用的版本////////////
        #region
        //if (IsOn == true)
        //{
        //    //   this.gameObject.GetComponent<Clip1>().enabled=true;
        //    if (other.gameObject.transform.tag == "JJD")
        //    {
        //        Transform[] Other_QJ = other.GetComponentsInChildren<Transform>();
        //        foreach (Transform other_qj in Other_QJ)
        //        {

        //            print(other_qj.transform.name);
        //            if (other_qj.transform.name == "QJ")
        //            {
        //                Destroy(other_qj.transform.gameObject);   //使氢键断裂
        //            }
        //            if (other_qj.transform.name == "A_T test(Clone)")
        //            {
        //                other_qj.transform.Find("A").transform.parent = DNA_TWO.transform;
        //            }
        //            if (other_qj.transform.name == "T_A test (Clone)")
        //            {
        //                other_qj.transform.Find("T").transform.parent = DNA_TWO.transform;
        //            }
        //            if (other_qj.transform.name == "C_G test(Clone)")
        //            {
        //                other_qj.transform.Find("C").transform.parent = DNA_TWO.transform;
        //            }
        //            if (other_qj.transform.name == "G_C test(Clone)")
        //            {
        //                other_qj.transform.Find("G").transform.parent = DNA_TWO.transform;
        //            }
        //        DNA_TWO.transform.position = new Vector3(0, -0.5f, 0);
        //          }

        //    }
        //}


        // Transform[] QJ = DNA_ONE.GetComponentsInChildren<Transform>();
        //foreach (Transform qj in QJ)
        //{
        //    if (qj.transform.name == "QJ")
        //    {
        //        Destroy(qj.transform.gameObject);   //使氢键断裂
        //    }

        //    if (qj.transform.name == "A_T test(Clone)")
        //    {
        //        qj.transform.Find("A").transform.parent = DNA_TWO.transform;
        //    }
        //    if (qj.transform.name == "T_A test (Clone)")
        //    {
        //        qj.transform.Find("T").transform.parent = DNA_TWO.transform;
        //    }
        //    if (qj.transform.name == "C_G test(Clone)")
        //    {
        //        qj.transform.Find("C").transform.parent = DNA_TWO.transform;
        //    }
        //    if (qj.transform.name == "G_C test(Clone)")
        //    {
        //        qj.transform.Find("G").transform.parent = DNA_TWO.transform;
        //    }

        //}
        //DNA_TWO.transform.position = new Vector3(0, -0.5f, 0);

        #endregion


    }



    IEnumerator CopyDNA(GameObject a, int i)
    {
        yield return new WaitForSeconds(0f);
        ShowCopyDNA(a, i);
        Pianduan.SetActive(true);
    }


    public void ShowCopyDNA(GameObject a,int i)
    {
           if(i==8||i==17||i==1) {
            switch (a.transform.name)
            {
                case "A_T":
                    a.transform.Find("QJ_L").gameObject.SetActive(true);
                    a.transform.Find("T").gameObject.SetActive(true);
                    a.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                    a.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    a.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                    a.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(false );
                    break;
                case "T_A":
                    a.transform.Find("QJ_L").gameObject.SetActive(true);
                    a.transform.Find("A").gameObject.SetActive(true);
                    a.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                    a.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    a.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                  a.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(false );
                    break;
                case "C_G":
                    a.transform.Find("QJ_L").gameObject.SetActive(true);
                    a.transform.Find("G").gameObject.SetActive(true);
                    a.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                    a.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    a.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                    a.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(false );
                    break;
                default:
                    a.transform.Find("QJ_L").gameObject.SetActive(true);
                    a.transform.Find("C").gameObject.SetActive(true);
                    a.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                    a.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                    a.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.AddComponent<Red_Color>();
                    a.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(false );
                    break;
            }
        }
        else { 
        switch (a.transform.name)
        {
            case "A_T":
                a.transform.Find("QJ_L").gameObject.SetActive(true);
                a.transform.Find("T").gameObject.SetActive(true);
                a.transform.Find("T").gameObject.AddComponent<HighlightableObject>();
                a.transform.Find("T").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                a.transform.Find("T").transform.Find("LSEZJ_R_New").gameObject.SetActive(true );
                break;
            case "T_A":
                a.transform.Find("QJ_L").gameObject.SetActive(true);
                a.transform.Find("A").gameObject.SetActive(true);
                a.transform.Find("A").gameObject.AddComponent<HighlightableObject>();
                a.transform.Find("A").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                a.transform.Find("A").transform.Find("LSEZJ_R_New").gameObject.SetActive(true);
                break;
            case "C_G":
                a.transform.Find("QJ_L").gameObject.SetActive(true);
                a.transform.Find("G").gameObject.SetActive(true);
                a.transform.Find("G").gameObject.AddComponent<HighlightableObject>();
                a.transform.Find("G").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                a.transform.Find("G").transform.Find("LSEZJ_R_New").gameObject.SetActive(true );
                break;
            default:
                a.transform.Find("QJ_L").gameObject.SetActive(true);
                a.transform.Find("C").gameObject.SetActive(true);
                a.transform.Find("C").gameObject.AddComponent<HighlightableObject>();
                a.transform.Find("C").gameObject.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
                a.transform.Find("C").transform.Find("LSEZJ_R_New").gameObject.SetActive(true );
                break;
        }
        }
    }

    #region 生成左侧链，形成新的DNA双链
    public GameObject CreateDNAPart_L(Transform Obj,Vector3 Pos_L)
    {
        if (Obj.transform.name == "A_T test(Clone)")
        {
            NewJianJiDui_L= GameObject.Instantiate(A_L);
            NewJianJiDui_L.transform.position = Pos_L;
            NewJianJiDui_L.transform.localRotation = Obj.transform.rotation;
            NewJianJiDui_L.transform.localScale= new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_L.transform.name = "A";
            NewJianJiDui_L.transform.parent = Obj.transform;
        }
        if (Obj.transform.name == "T_A test (Clone)")
        {
            NewJianJiDui_L= GameObject.Instantiate(T_L);
            NewJianJiDui_L.transform.position = Pos_L;
            NewJianJiDui_L.transform.localRotation = Obj.transform.rotation;
            NewJianJiDui_L.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_L.transform.name = "T";
            NewJianJiDui_L.transform.parent = Obj.transform;
        }
        if (Obj.transform.name == "C_G test(Clone)")
        {
            NewJianJiDui_L = GameObject.Instantiate(C_L);
            NewJianJiDui_L.transform.position = Pos_L;
            NewJianJiDui_L.transform.localRotation = Obj.transform.rotation;
            NewJianJiDui_L.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_L.transform.name = "C";
            NewJianJiDui_L.transform.parent = Obj.transform;
        }
        if (Obj.transform.name == "G_C test(Clone)")
        {
            NewJianJiDui_L = GameObject.Instantiate(G_L);
            NewJianJiDui_L.transform.position = Pos_L;
            NewJianJiDui_L.transform.localRotation = Obj.transform.rotation;
            NewJianJiDui_L.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_L.transform.name = "G";
            NewJianJiDui_L.transform.parent = Obj.transform;
        }
        StartCoroutine(MoveJianJiUp(NewJianJiDui_L));
        NewJianJiDui_L.AddComponent<HighlightableObject>();
        NewJianJiDui_L.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
        return NewJianJiDui_L;
            }
    #endregion

    #region 生成右侧链，形成新的DNA双链
    public GameObject CreateDNAPart_R(Transform Obj, Vector3 Pos_R,Quaternion Rotation_R)
    {
        if (Obj.transform.name == "A_T test(Clone)")
        {


            NewJianJiDui_R = GameObject.Instantiate(T_R);
            NewJianJiDui_R.transform.position = Pos_R;
            NewJianJiDui_R.transform.localRotation = Rotation_R;
            NewJianJiDui_R.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_R.transform.name = "T";
        }
        if (Obj.transform.name == "T_A test (Clone)")
        {
            NewJianJiDui_R = GameObject.Instantiate(A_R);
            NewJianJiDui_R.transform.position = Pos_R;
            NewJianJiDui_R.transform.localRotation = Rotation_R;
            NewJianJiDui_R.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_R.transform.name = "A";
        }
        if (Obj.transform.name == "C_G test(Clone)")
        {
            NewJianJiDui_R = GameObject.Instantiate(G_R);
            NewJianJiDui_R.transform.position = Pos_R;
            NewJianJiDui_R.transform.localRotation = Rotation_R;
            NewJianJiDui_R.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_R.transform.name = "G";
        }
        if (Obj.transform.name == "G_C test(Clone)")
        {
            NewJianJiDui_R = GameObject.Instantiate(C_R);
            NewJianJiDui_R.transform.position = Pos_R;
            NewJianJiDui_R.transform.localRotation = Rotation_R;
             NewJianJiDui_R.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            NewJianJiDui_R.transform.name = "C";
        }
        StartCoroutine(MoveJianJiDown(NewJianJiDui_R));
        NewJianJiDui_R.AddComponent<HighlightableObject>();
        NewJianJiDui_R.GetComponent<HighlightableObject>().ConstantOn(Color.cyan);
        return NewJianJiDui_R;

    }
    #endregion

    #region 使得解旋后的DNA单链移动
    IEnumerator MoveJianJiDown(GameObject Object)
    {
        Object.transform.Translate(new Vector3(0.0f, -2f, 0.0f), Space.World);
        yield return new WaitForSeconds(3.0f);
    }

    IEnumerator MoveJianJiUp(GameObject Object)
    {
        Object.transform.Translate(new Vector3(0.0f,4f, 0.0f), Space.World);
        yield return new WaitForSeconds(3.0f);
    }

    #endregion


    #region 绘制曲线
    /// <summary>
    /// 获取存储贝塞尔曲线点的数组
    /// </summary>
    /// <param name="startPoint"></param>起始点
    /// <param name="controlPoint"></param>控制点
    /// <param name="endPoint"></param>目标点
    /// <param name="segmentNum"></param>采样点的数量
    /// <returns></returns>存储贝塞尔曲线点的数组
    public void  GetBeizerList(Vector3 startPoint, Vector3 controlPoint, Vector3 endPoint, int segmentNum,LineRenderer lineRender)
    {
  
        for (int i = 1; i <= segmentNum; i++)
        {
            float t = i / (float)segmentNum;
            Vector3 pixel = CalculateCubicBezierPoint(t, startPoint,controlPoint, endPoint);
            lineRender.positionCount = i;
            lineRender.SetPosition(i-1, pixel);
        }


    }

    /// <summary>
    /// 根据T值，计算贝塞尔曲线上面相对应的点
    /// </summary>
    /// <param name="t"></param>T值
    /// <param name="p0"></param>起始点
    /// <param name="p1"></param>控制点
    /// <param name="p2"></param>目标点
    /// <returns></returns>根据T值计算出来的贝赛尔曲线点
    private static Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
        
    }

/// <summary>
/// 获取控制点.
/// </summary>
/// <param name="startPos">起点.</param>
/// <param name="endPos">终点.</param>
/// <param name="offset">偏移量.</param>
private Vector3 CalcControlPos(Vector3 startPos, Vector3 endPos, float offset)
{
    //方向(由起始点指向终点)
    Vector3 dir = endPos - startPos;
    //取另外一个方向. 这里取向上.
    Vector3 otherDir = Vector3.up;

    //求平面法线.  注意otherDir与dir不能调换位置,平面的法线是有方向的,(调换位置会导致法线方向相反)
    //ps: 左手坐标系使用左手定则 右手坐标系使用右手定则 (具体什么是左右手坐标系这里不细说请Google)
    //unity中世界坐标使用的是左手坐标系,所以法线的方向应该用左手定则判断.
    Vector3 planeNormal = Vector3.Cross(otherDir, dir);

    //再求startPos与endPos的垂线. 其实就是再求一次叉乘.
    Vector3 vertical = Vector3.Cross(dir, planeNormal).normalized;
    //中点.
    Vector3 centerPos = (startPos + endPos) / 2f;
    //控制点.
    Vector3 controlPos = centerPos + vertical * offset;

    return controlPos;
}
    #endregion

}


