using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class C_QingJianNew : MonoBehaviour {

    public GameObject G;
    public GameObject C;
    public GameObject C_G;//将对象作为一个整体来存放
    public GameObject QJ;//存放生成的氢键


    /// <summary>
    /// 碱基对之间的变量
    /// </summary>
    #region
    public GameObject C_jianji;//C碱基
    public GameObject G_jianji;//G碱基

    /// ////// 碱基的位置，为了之后算连线的长度/////////////
    Vector3 C_Pos;
    Vector3 G_Pos;
    #endregion


    /// <summary>
    /// 生成氢键所需的变量
    /// </summary>
    #region
    float Length;
    GameObject[] line = new GameObject[3];//存放氢键的数组
    //public  GameObject linePrefab;//用来当做连线的预设体
    float JianJu;//控制氢键之间的间距
    float thickness = 0.04f;//控制所连线的细长程度

    #endregion

    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.collider.name.ToString();
        if (name == "G碱基")
        {
            //////////////确定碱基的位置/////////
            C_Pos = C_jianji.transform.position;
            G_Pos = G_jianji.transform.position;

             Length =( Mathf.Abs(C_Pos.x - G_Pos.x) / 2.0f )/C_G.transform.localScale.y;
            CreateQingJian(C_Pos, G_Pos, Length, 3);

        }

        Rigidbody rig = this.GetComponent<Rigidbody>();
        Destroy(rig);
        C.transform.parent = C_G.transform;
        G.transform.parent = C_G.transform;
    }


    void CreateQingJian(Vector3 StartPos, Vector3 EndPos, float length, int n)
    { 
        JianJu = (gameObject.GetComponent<Renderer>().bounds.size.y) / 5;
        for (int i = 0; i < n; i++)
        {
            //line[i] = Instantiate(linePrefab);
            line[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            if (i == 0)
            {
                line[i].transform.position = Vector3.Lerp(StartPos, EndPos, 0.5f);
                line[i].transform.name = "0";
            }
            if (i == 1)
            {
                line[i].transform.position = new Vector3(line[0].transform.position.x, line[0].transform.position.y + JianJu, line[0].transform.position.z);
                line[i].transform.name = "1";
            }
            if (i == 2)
            {
                line[i].transform.position = new Vector3(line[0].transform.position.x, line[0].transform.position.y - JianJu , line[0].transform.position.z);
                line[i].transform.name = "2";
            }
            line[i].transform.parent = QJ.transform;
            line[i].transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            line[i].transform.localScale = new Vector3(thickness, length, thickness);
            line[i].GetComponent<Renderer>().material.color = Color.red;
            // Material newMat = new Material(Shader.Find("Unlit/Color"));
            // line[i].transform.localScale = new Vector3(thickness, length, thickness);
            // line[i].transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            // newMat.SetColor("_Color", Color.red);
            //line[i].GetComponent<MeshRenderer>().material = newMat;
            //  line[i].transform.parent = QJ.transform;(注：放在这的话，旋转时，会使得氢键产生偏移)

        }
    }
}
