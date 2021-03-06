using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_QingJianNew : MonoBehaviour {


    /// <summary>
    /// 氢键所需的变量
    /// </summary>
    #region
   // public GameObject LinePrefab;//连接线的预设体
    float Length;//连接线的长度
    float Jianju;//氢键直接的间距
    GameObject[] line = new GameObject[3];//用来存放所生成的氢键
    float thickness = 0.04f;//控制线的厚度
    #endregion

    /// <summary>
    /// 碱基间的变量
    /// </summary>
    #region
    public GameObject A_jianji;//A碱基
    public GameObject T_jianji;//T碱基

    /////////////碱基的坐标//////////////////
    Vector3  A_Pos;
    Vector3 T_Pos;

    #endregion


    public GameObject A;
    public GameObject T;
    public GameObject A_T;//用来存放整体的
    public GameObject QJ;


    // Use this for initialization
    void Start () {
		
	}
	

    private void OnCollisionEnter(Collision collision)
    {

        string name = collision.collider.name.ToString();  //所发生碰撞的物体

        if (name=="A碱基")
        {
          
            //////////////存放两个碱基的位置，为了计算连线的长度/////////
            A_Pos = A_jianji.transform.position;
            T_Pos = T_jianji.transform.position;


            Length =( Mathf.Abs(A_Pos.x - T_Pos.x)/2f)/A_T.transform.localScale.y;

            CreatQingJian(A_Pos, T_Pos, Length, 3);

        }

        //if (collision.collider.name.ToString()=="T碱基")
        //{
        //    print("T");
        //    //////////////存放两个碱基的位置，为了计算连线的长度/////////
        //    A_Pos = A_jianji.transform.position;
        //    T_Pos = T_jianji.transform.position;


        //    Length = Mathf.Abs(A_Pos.x- T_Pos.x);

        //    CreatQingJian( A_Pos,T_Pos,Length ,3);
        //}

    
        Rigidbody rig = this.GetComponent<Rigidbody>();
        Destroy(rig);

        A.transform.parent = A_T.transform;
        T.transform.parent = A_T.transform;

    }

    /// <summary>
    /// 生成氢键的函数
    /// </summary>
     void CreatQingJian(Vector3 StartPos,Vector3 EndPos,float length,int n)
    {

        Jianju = (gameObject.GetComponent<Renderer>().bounds.size.y) / 5;
       // Material newmaterial = new Material(Shader.Find("Unlit/Color"));
        for (int i = 0; i < n; i++)
        {
            // line[i] = Instantiate(LinePrefab);
            line[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            if (i == 0)
            {
                line[i].transform.position = Vector3.Lerp(StartPos, EndPos, 0.5f);
                line[i].transform.name = "0";
                Destroy(line[i].GetComponent<MeshRenderer>());
            }
            if (i == 1)
            {
                line[i].transform.position = new Vector3(line[0].transform.position.x, line[0].transform.position.y + Jianju, line[0].transform.position.z);
                line[i].transform.name = "1";
            }
            if (i == 2)
            {
                line[i].transform.position = new Vector3(line[0].transform.position.x, line[0].transform.position.y - Jianju , line[0].transform.position.z);
                line[i].transform.name = "2";
            }
           
            line[i].transform.parent = QJ.transform;
            line[i].transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            line[i].transform.localScale = new Vector3(thickness, length, thickness);
            line[i].GetComponent<Renderer>().material.color = Color.red;
            //line[i].transform.localScale = new Vector3(thickness, length, thickness);//原本y方向的比例为length.由于后期出现氢键的错误，就直接用0.637f替代
            //line[i].transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            //newmaterial.SetColor("_Color", Color.red);
            //line[i].GetComponent<MeshRenderer>().material = newmaterial;
            // line[i].transform.parent = QJ.transform;（放这的话，氢键会产生偏移）
        }
    }
}
