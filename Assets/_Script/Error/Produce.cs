using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




public class Produce : MonoBehaviour
{
    public GameObject R;
    public GameObject A_T;
    public GameObject C_G;
    public GameObject T_A;
    public GameObject G_C;

    Transform[] jjd; //存放基础点的
    List<Transform> basePoint_L = new List<Transform>();


    public int baseCount = 50;  //两个基础点之间的取点数量   值越大曲线就越平滑  但同时计算量也也越大

    LineRenderer lineRender;
    private int count = 10;
    GameObject[] obj = new GameObject[100];





    // Use this for initialization
    void Start()
    {

        Init();
        //this.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);//为了是其较好的呈现
        jjd = this.GetComponentsInChildren<Transform>();
        ///////获取左侧链上磷酸的
        foreach (Transform obj in jjd)
        {
            if (obj.transform.name == "A_T test(Clone)")
            {
                basePoint_L.Add(obj.transform.Find("A").transform.Find("磷酸"));
            }
            if (obj.transform.name == "T_A test (Clone)")
            {
                basePoint_L.Add(obj.transform.Find("T").transform.Find("磷酸"));
            }
            if (obj.transform.name == "C_G test(Clone)")
            {
                basePoint_L.Add(obj.transform.Find("C").transform.Find("磷酸"));
            }
            if (obj.transform.name == "G_C test(Clone)")
            {
                basePoint_L.Add(obj.transform.Find("G").transform.Find("磷酸"));
            }
        }
        /////////做标架，模拟标架图///
        //for (int i = 0; i < basePoint_L.Count; i++)
        //{
        //    basePoint_L[i].transform.localRotation = Quaternion.Euler(0, -90, 55);
        //}
        lineRender = gameObject.GetComponent<LineRenderer>();//获取LineRenderer这个画线的组件
   //   InitPoint();
        R.SetActive(true);
      //  lineRender.SetPosition(0, lineRender.GetPosition(1));//将LineRenderer中插入点的Position进行处理，使得线从position的位置开始画
     
    }

    void Update()
    {

        ////////////////为了模拟标架图使用的////////////
        /////获取左侧链上磷酸的
        //foreach (Transform obj in jjd)
        //{
        //    if (obj.transform.name == "A_T test(Clone)")
        //    {
        //        basePoint_L.Add(obj.transform.Find("A").transform.Find("磷酸"));
        //    }
        //    if (obj.transform.name == "T_A test (Clone)")
        //    {
        //        basePoint_L.Add(obj.transform.Find("T").transform.Find("磷酸"));
        //    }
        //    if (obj.transform.name == "C_G test(Clone)")
        //    {
        //        basePoint_L.Add(obj.transform.Find("C").transform.Find("磷酸"));
        //    }
        //    if (obj.transform.name == "G_C test(Clone)")
        //    {
        //        basePoint_L.Add(obj.transform.Find("G").transform.Find("磷酸"));
        //    }
        //}


        /////将下面两句放在Update是为了使得LineRenderer画出的线也能够转动////
        InitPoint();
        lineRender.SetPosition(0, lineRender.GetPosition(1));



        //for (int i = 0; i < basePoint_L.Count; i++)
        //    {

        //        Debug.DrawRay(basePoint_L[i].transform.position, transform.TransformDirection(basePoint_L[i].transform.forward) * 1f, Color.blue);
        //        Debug.DrawRay(basePoint_L[i].transform.position, transform.TransformDirection(basePoint_L[i].transform.up) * 1f, Color.green);
        //        Debug.DrawRay(basePoint_L[i].transform.position, transform.TransformDirection(basePoint_L[i].transform.right) * 1f, Color.red);           
        //    }


    }



    void Init()
    {


        //obj[0] = GameObject.Instantiate(A_T);

        for (int i = 0; i < count; i++)
        {
            ////////////////////随机生成和螺旋形状//////////////////
            #region 随机生成和螺旋形状
            ///////////////////控制了双螺旋中的碱基序列
            switch (i + 1)
            { case 3:
                    obj[i + 1] = GameObject.Instantiate(G_C);
                //    obj[i + 1].tag = "JJD";
                    obj[i + 1].transform.Find("G").transform.Find("G_p1").tag = "Candy";
                    break;
                case 4:
                    obj[i + 1] = GameObject.Instantiate(A_T);
               //    obj[i + 1].tag = "JJD";//为了之后将其按顺序存入序列
                    obj[i + 1].transform.Find("A").tag = "A";//为了之后的正确摆放位置，等待连接酶
                   obj[i + 1].transform.Find("A").transform.Find("A_p2").tag = "1";
                    break;
                case 5:
                    obj[i + 1] = GameObject.Instantiate(A_T);
                //    obj[i + 1].tag = "JJD";
                    obj[i + 1].transform.Find("A").tag = "A1";
                    break;
                case 6:
                    obj[i + 1] = GameObject.Instantiate(T_A);
                    //obj[i + 1].tag = "JJD";
                    obj[i + 1].transform.Find("T").tag = "T";
                    break;
                case 7:
                    obj[i + 1] = GameObject.Instantiate(T_A);
                    //obj[i + 1].tag = "JJD";
                    obj[i + 1].transform.Find("T").tag = "T1";
                    obj[i + 1].transform.Find("A").transform.Find("A_p1").tag = "3";
                    break;
                case 8:
                    obj[i + 1] = GameObject.Instantiate(C_G);
                   // obj[i + 1].tag = "JJD";
                    obj[i + 1].transform.Find("G").transform.Find("G_p2").tag = "6";
                    break;
                default:
                    obj[i + 1] = RandomCreate();//其它位点的碱基随意
                  //  obj[i + 1].tag = "JJD";
                    break;
            }
            obj[i + 1].transform.position = new Vector3(0, i * 1.5f, 0);
            obj[i+1].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
            obj[i+1].transform.parent = this.transform;
            #endregion

        }


        this.gameObject.transform.position = new Vector3(5F, 0, 0);

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
        int a = UnityEngine.Random.Range(1, 101);//Range是左开又闭，随机产生[1,100]的数
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


    #region 计算贝塞尔曲线的拟合点
    //初始化算出所有的点的信息
    void InitPoint()
    {
        //获取指定的点的信息
        Vector3[] pointPos = new Vector3[basePoint_L.Count];
        for (int i = 0; i < pointPos.Length; i++)
        {
            pointPos[i] = basePoint_L[i].transform.position;
        }
        GetTrackPoint(pointPos);
    }


    /// <summary>
    /// 根据设定节点 绘制指定的曲线
    /// </summary>
    /// <param name="track">所有指定节点的信息</param>
    public void GetTrackPoint(Vector3[] track)
    {
        Vector3[] vector3s = PathControlPointGenerator(track);
        int SmoothAmount = track.Length * baseCount;
        lineRender.positionCount = SmoothAmount;//节点之间的顶点数
        for (int i = 1; i < SmoothAmount; i++)
        {
            float pm = (float)i / SmoothAmount;
            Vector3 currPt = Interp(vector3s, pm);
            lineRender.SetPosition(i, currPt);//设定渲染线的节点位置
            
                                         
        }
    }

    /// <summary>
    /// 计算所有节点以及控制点坐标
    /// </summary>
    /// <param name="path">所有节点的存储数组</param>
    /// <returns></returns>
    public Vector3[] PathControlPointGenerator(Vector3[] path)
    {
        Vector3[] suppliedPath;
        Vector3[] vector3s;

        suppliedPath = path;
        int offset = 2;
        vector3s = new Vector3[suppliedPath.Length + offset];
        Array.Copy(suppliedPath, 0, vector3s, 1, suppliedPath.Length);
        vector3s[0] = vector3s[1] + (vector3s[1] - vector3s[2]);
        vector3s[vector3s.Length - 1] = vector3s[vector3s.Length - 2] + (vector3s[vector3s.Length - 2] - vector3s[vector3s.Length - 3]);
        if (vector3s[1] == vector3s[vector3s.Length - 2])
        {
            Vector3[] tmpLoopSpline = new Vector3[vector3s.Length];
            Array.Copy(vector3s, tmpLoopSpline, vector3s.Length);
            tmpLoopSpline[0] = tmpLoopSpline[tmpLoopSpline.Length - 3];
            tmpLoopSpline[tmpLoopSpline.Length - 1] = tmpLoopSpline[2];
            vector3s = new Vector3[tmpLoopSpline.Length];
            Array.Copy(tmpLoopSpline, vector3s, tmpLoopSpline.Length);
        }
        return (vector3s);
    }


    /// <summary>
    /// 计算曲线的任意点的位置
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vector3 Interp(Vector3[] pos, float t)
    {
        int length = pos.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * length), length - 1);
        float u = t * (float)length - (float)currPt;
        Vector3 a = pos[currPt];
        Vector3 b = pos[currPt + 1];
        Vector3 c = pos[currPt + 2];
        Vector3 d = pos[currPt + 3];
        return .5f * (
           (-a + 3f * b - 3f * c + d) * (u * u * u)
           + (2f * a - 5f * b + 4f * c - d) * (u * u)
           + (-a + c) * u
           + 2f * b
       );
      
    }
    #endregion

}



