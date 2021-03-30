using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class d : MonoBehaviour {

    private Vector3 centerPos;    //你围绕那个点 就用谁的角度
    private float radius =10;     //物理离 centerPos的距离
  //  private float angle = 0;      //偏移角度  

        /// <summary>
        /// DNA的预设体
        /// </summary>
    public GameObject A_T;
    public GameObject T_A;
    public GameObject C_G;
    public GameObject G_C;

    Transform[] jjd;
    //存放基础点的
    List<Transform> basePoint_L = new List<Transform>();
    public int baseCount = 50;  //两个基础点之间的取点数量   值越大曲线就越平滑  但同时计算量也也越大
    LineRenderer lineRender;

    public GameObject Ring_r;
    public GameObject GD;//模拟环状的透明管道，渲染层次感

    bool isOpen = true;
    public GameObject MenuPanel;

    void Start()
    {
        CreateCubeAngle30();//调用函数生成圆

        this.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));

        jjd = this.GetComponentsInChildren<Transform>();
        //获取左侧链上磷酸的
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
            //if (obj.transform.name == "0" || obj.transform.name == "1" || obj.transform.name == "2")
            //{
            //    print("0222");
            //    obj.transform.localScale = new Vector3(obj.transform.localScale.x, 0.637f, obj.transform.localScale.z);
            //}
        }
    }

    public void CreateCubeAngle30()
    {
        centerPos = transform.position;

      for (int i=0;i<60;i++)
        {
            //先解决你物体的位置的问题
            // x = 原点x + 半径 * 邻边除以斜边的比例,   邻边除以斜边的比例 = cos(弧度) , 弧度 = 角度 *3.14f / 180f;   
            float x = centerPos.x + radius * Mathf.Cos(i*6 * 3.14f / 180f);
            float y = centerPos.y + radius * Mathf.Sin(i * 6 * 3.14f / 180f);
            // 生成一个圆
            //GameObject obj1 = GameObject.Instantiate(A_T);
            GameObject obj1= RandomCreate();
            obj1.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj1.transform.Rotate(new Vector3(0, 0,i* 36f));
            //设置物体的位置Vector3三个参数分别代表x,y,z的坐标数  
            obj1.transform.position = new Vector3(x, centerPos.z, y);
            obj1.transform.parent = this.transform;

        }

        lineRender = gameObject.GetComponent<LineRenderer>();//获取LineRenderer这个画线的组件
        Ring_r.SetActive(true);
        GD.SetActive(true);
    }


	
	// Update is called once per frame
	void Update () {
        InitPoint();
        lineRender.SetPosition(0, lineRender.GetPosition(1));
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

    public void Exit()
    {
        SceneManager.LoadScene("Reknow");
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
    public void Return()
    {
        SceneManager.LoadScene("Shape");
    }
}
