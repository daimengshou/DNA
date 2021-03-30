using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Connect : MonoBehaviour
{


    /// <summary>
    /// 氢键所需的变量
    /// </summary>
    #region
    //public GameObject LinePrefab;//连接线的预设体
    float Length;//连接线的长度
    float Jianju;//氢键直接的间距,不可直接赋予固定值，会受缩放比例的影响
    GameObject[] line = new GameObject[3];//用来存放所生成的氢键
    float thickness = 0.08f;//控制线的厚度
    #endregion

    /////////////碱基的坐标//////////////////
    Vector3 A_Pos;
    Vector3 T_Pos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "A碱基")
        {

            //////////////存放两个碱基的位置，为了计算连线的长度/////////
            T_Pos = this.transform.position;
            A_Pos = other.transform.position;


            Length = 0.637F ;//长度是会在原比例的基础上以当前比例进行缩放，因此需要放大
                                                              // Length = (gameObject.GetComponent<Renderer>().bounds.size.x)*1.5f;

            CreatQingJian(A_Pos, T_Pos, Length, 3);

        }


    }
    /// <summary>
    /// 生成氢键的函数
    /// </summary>
    void CreatQingJian(Vector3 StartPos, Vector3 EndPos, float length, int n)
    {

        Jianju = (gameObject.GetComponent<Renderer>().bounds.size.y) / 5;

        for (int i = 0; i < n; i++)
        {
            // line[i] = Instantiate(LinePrefab);
            // Material newmaterial = new Material(Shader.Find("Unlit/Color"));
            //// line[i].transform.localScale = new Vector3(thickness, length, thickness);
            // line[i].transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            // newmaterial.SetColor("_Color", Color.red);
            // line[i].GetComponent<MeshRenderer>().material = newmaterial;
            line[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);


            if (i == 0)
            {
                line[i].transform.position = Vector3.Lerp(StartPos, EndPos, 0.5f);
                line[i].transform.name = "0";
                Destroy(line[i].GetComponent<MeshRenderer>());//将中间的这根氢键删除


            }
            if (i == 1)
            {
                line[i].transform.position = new Vector3(line[0].transform.position.x, line[0].transform.position.y + Jianju, line[0].transform.position.z);
                line[i].transform.name = "1";
            }
            if (i == 2)
            {
                line[i].transform.position = new Vector3(line[0].transform.position.x, line[0].transform.position.y - Jianju, line[0].transform.position.z);
                line[i].transform.name = "2";
            }

            //Destroy(line[0]);//不可直接删除，否则后期的旋转无法实现
            line[i].transform.parent = this.transform.parent.transform;
            // line[i].transform.parent = QJ.transform;（放这的话，氢键会产生偏移）
            line[i].transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            line[i].transform.localScale = new Vector3(thickness, length, thickness);
            line[i].GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
