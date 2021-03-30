using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmaI : MonoBehaviour {
    public GameObject C_G;
    public GameObject G_C;
    GameObject[] obj = new GameObject[7];
    int count = 6;

    // Use this for initialization
    void Start () {
        CreateChain();

    }
	
	// Update is called once per frame
	void Update () {

    }

    void CreateChain()
    {
        for (int i = 0; i < 6; i++)
        {
            switch (i + 1)
            {
                case 1:
                    obj[i + 1] = GameObject.Instantiate(C_G);
                    break;
                case 2:
                    obj[i + 1] = GameObject.Instantiate(C_G);
                    break;
                case 3:
                    obj[i + 1] = GameObject.Instantiate(C_G);
                    obj[i + 1].tag = "2";
                    break;
                case 4:
                    obj[i + 1] = GameObject.Instantiate(G_C);
                    break;
                case 5:
                    obj[i + 1] = GameObject.Instantiate(G_C);
                    break;
                default:
                    obj[i + 1] = GameObject.Instantiate(G_C);
                    break;
            }
            obj[i + 1].transform.position = new Vector3(0, i * 1.5f, 0);
            obj[i + 1].transform.parent = this.transform;
        }


        for (int i = 1; i < count; i++)
        {
            #region 磷酸二脂键的连接
                        #region 以C_G为基础单元
            if (obj[i].transform.name == "C_G(Clone)")
            {

                if (obj[i + 1].transform.name == "C_G(Clone)")
                {
                    #region 在G一侧产生磷酸二脂键
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject G_line;
                    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    G_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
                    G_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
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
                    C_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    C_line.GetComponent<Renderer>().material.color = Color.black;
                    C_line.transform.name = "LSEZJ_L";
                    C_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion
                }
                else if (obj[i + 1].transform.name == "G_C(Clone)")
                {
                    #region 在G_C一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;//寻找实例化后的p1
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject GC_line;
                    GC_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                    GC_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    GC_line.transform.position = Vector3.Lerp(G_p1.transform.position, C_p2.transform.position, 0.5f);
                    GC_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
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
                    CG_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    CG_line.GetComponent<Renderer>().material.color = Color.black;
                    CG_line.transform.name = "LSEZJ_L";
                    CG_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion
                }
            }

            #endregion

            #region 以G_C为基础单元
            if (obj[i].transform.name == "G_C(Clone)")
            {

                if (obj[i + 1].transform.name == "G_C(Clone)")
                {
                    #region 在C一侧
                    GameObject C_p1 = obj[i].transform.Find("C").transform.Find("C_p1").gameObject;
                    GameObject C_p2 = obj[i + 1].transform.Find("C").transform.Find("C_p2").gameObject;
                    GameObject C_line;
                    C_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    C_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    C_line.transform.position = Vector3.Lerp(C_p1.transform.position, C_p2.transform.position, 0.5f);
                    C_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    C_line.GetComponent<Renderer>().material.color = Color.black;
                    C_line.transform.name = "LSEZJ_R";
                    C_line.transform.parent = obj[i].transform.Find("C").transform;
                    #endregion

                    #region 在G一侧
                    GameObject G_p1 = obj[i].transform.Find("G").transform.Find("G_p1").gameObject;
                    GameObject G_p2 = obj[i + 1].transform.Find("G").transform.Find("G_p2").gameObject;
                    GameObject G_line;
                    G_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    G_line.GetComponent<CapsuleCollider>().isTrigger = true;
                    G_line.transform.position = Vector3.Lerp(G_p1.transform.position, G_p2.transform.position, 0.5f);
                    G_line.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
                    G_line.GetComponent<Renderer>().material.color = Color.black;
                    G_line.transform.name = "LSEZJ_L";
                    G_line.transform.parent = obj[i].transform.Find("G").transform;
                    #endregion
                }

            }
            #endregion

            #endregion
        }


        this.transform.position = new Vector3(6f, -5f, 10);
      //  this.transform.localScale = new Vector3(2, 2, 2);
        this.gameObject.AddComponent<QJscale>();

    }
}
