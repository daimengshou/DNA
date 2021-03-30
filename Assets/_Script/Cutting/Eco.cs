using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eco : MonoBehaviour {

    public GameObject A_T;
    public GameObject T_A;
    public GameObject C_G;
    public GameObject G_C;
    GameObject[] obj=new GameObject[7];
    int count = 6;

	// Use this for initialization
	void Start () {
        CreateChain();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void CreateChain() {
        for (int i = 0; i < 6; i++)
        {
            switch (i + 1)
            {
                case 1:
                    obj[i + 1] = GameObject.Instantiate(G_C);
                    break;
                case 2:
                    obj[i + 1] = GameObject.Instantiate(A_T);
                    break;
                case 3:
                    obj[i + 1] = GameObject.Instantiate(A_T);
                    break;
                case 4:
                    obj[i + 1] = GameObject.Instantiate(T_A);
                    break;
                case 5:
                    obj[i + 1] = GameObject.Instantiate(T_A);
                    obj[i + 1].tag = "1";
                    break;
                default:
                    obj[i + 1] = GameObject.Instantiate(C_G);
                    break;
            }
            obj[i + 1].transform.position = new Vector3(0, i * 1.5f, 0);
            obj[i + 1].transform.parent = this.transform;
        }


        for (int i = 1; i < count; i++)
        {
            #region 磷酸二脂键的连接
            #region 以A_T为基础单元

            if (obj[i].transform.name == "A_T(Clone)")
            {
                if (obj[i + 1].transform.name == "A_T(Clone)")
                {
                    #region 在T一侧产生磷酸二脂键
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;//寻找实例化后的p1
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject T_line;
                    T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    T_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5f);
                    T_line.transform.localScale = new Vector3(0.1f,0.3f, 0.1f);
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
                    A_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    A_line.GetComponent<Renderer>().material.color = Color.black;
                    A_line.transform.name = "LSEZJ_L";
                    A_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "T_A(Clone)")
                {
                    #region  在T_A一侧
                    GameObject T_p1 = obj[i].transform.Find("T").transform.Find("T_p1").gameObject;
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject TA_line;
                    TA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    TA_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    TA_line.transform.position = Vector3.Lerp(T_p1.transform.position, A_p2.transform.position, 0.5f);
                    TA_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
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
                    AT_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    AT_line.GetComponent<Renderer>().material.color = Color.black;
                    AT_line.transform.name = "LSEZJ_L";
                    AT_line.transform.parent = obj[i].transform.Find("A").transform;
                    #endregion
                }
            }

            #endregion


            #region 以T_A为基础单元
            else if (obj[i].transform.name.ToString() == "T_A(Clone)")
            {
                if (obj[i + 1].transform.name.ToString() == "T_A(Clone)")
                {

                    #region 在A一侧产生磷酸二脂键
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject A_p2 = obj[i + 1].transform.Find("A").transform.Find("A_p2").gameObject;
                    GameObject A_line;
                    A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    A_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5f);
                    A_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
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
                    T_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    T_line.GetComponent<Renderer>().material.color = Color.black;
                    T_line.transform.name = "LSEZJ_L";
                    T_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion
                }

                else if (obj[i + 1].transform.name.ToString() =="C_G(Clone)")
                {
                    #region  在A_G一侧
                    GameObject A_p1 = obj[i].transform.Find("A").transform.Find("A_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject AG_line;
                    AG_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    AG_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    AG_line.transform.position = Vector3.Lerp(A_p1.transform.position, G_p2.transform.position, 0.5f);
                    AG_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
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
                    TC_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    TC_line.GetComponent<Renderer>().material.color = Color.black;
                    TC_line.transform.name = "LSEZJ_L";
                    TC_line.transform.parent = obj[i].transform.Find("T").transform;
                    #endregion
                }

            }


            #endregion

            #region 以G_C为基础单元
            if (obj[i].transform.name == "G_C(Clone)")
            {

                 if (obj[i + 1].transform.name == "A_T(Clone)")
                {
                    #region 在C_T一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject T_p2 = obj[i + 1].transform.Find("T").transform.Find("T_p2").gameObject;
                    GameObject CT_line;
                    CT_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    CT_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    CT_line.transform.position = Vector3.Lerp(C_p1.transform.position, T_p2.transform.position, 0.5f);
                    CT_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
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
                    GA_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    GA_line.GetComponent<Renderer>().material.color = Color.black;
                    GA_line.transform.name = "LSEZJ_L";
                    GA_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion
                }

            }
            #endregion

            #endregion
        }


        this.transform.position = new Vector3(-1, -5f, 10f);
        //this.transform.localScale = new Vector3(2, 2, 2);
        this.gameObject.AddComponent<QJscale>();

    }

    public void Next()
    {
        SceneManager.LoadScene("Shape");
    }
    public void Reload()
    {
        SceneManager.LoadScene("Enzyme");
    }
    public void Retrun()
    {
        SceneManager.LoadScene("KnowClip");
    }
}
