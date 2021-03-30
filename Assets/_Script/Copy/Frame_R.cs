using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Frame_R : MonoBehaviour
{
    Transform[] jjd;
    public int baseCount = 50;  //两个基础点之间的取点数量   值越大曲线就越平滑  但同时计算量也也越大
    public GameObject DNA_ONE;

    LineRenderer lineRender;
    LineRenderer Other_lineRender;
    List<Transform> basePoint_R = new List<Transform>();
    List<Transform> basePoint_L = new List<Transform>();

    void Start()
    {
        jjd =this.GetComponentsInChildren<Transform>();
        foreach (Transform obj1 in jjd)
        {
            if (obj1.transform.name == "A_T test(Clone)")
            {
                basePoint_R.Add(obj1.transform.Find("T").transform.Find("磷酸"));
            }
            if (obj1.transform.name == "T_A test (Clone)")
            {
                basePoint_R.Add(obj1.transform.Find("A").transform.Find("磷酸"));
            }
            if (obj1.transform.name == "C_G test(Clone)")
            {
                basePoint_R.Add(obj1.transform.Find("G").transform.Find("磷酸"));
            }
            if (obj1.transform.name == "G_C test(Clone)")
            {
                basePoint_R.Add(obj1.transform.Find("C").transform.Find("磷酸"));
            }


            if (obj1.transform.name == "A_T test(Clone)")
            {
                basePoint_L.Add(obj1.transform.Find("A").transform.Find("磷酸"));
            }
            if (obj1.transform.name == "T_A test (Clone)")
            {
                basePoint_L.Add(obj1.transform.Find("T").transform.Find("磷酸"));
            }
            if (obj1.transform.name == "C_G test(Clone)")
            {
                basePoint_L.Add(obj1.transform.Find("C").transform.Find("磷酸"));
            }
            if (obj1.transform.name == "G_C test(Clone)")
            {
                basePoint_L.Add(obj1.transform.Find("G").transform.Find("磷酸"));
            }
        }

        lineRender = gameObject.GetComponent<LineRenderer>();//获取LineRenderer这个画线的组件
        DNA_ONE.GetComponent<LineRenderer>().enabled = true;
        Other_lineRender = DNA_ONE.GetComponent<LineRenderer>();
        Other_lineRender.material.color = Color.cyan;
    }



    void Update()
    {
        InitPoint(basePoint_R,lineRender);
        InitPoint(basePoint_L, Other_lineRender);
        lineRender.SetPosition(0, lineRender.GetPosition(1));
        Other_lineRender.SetPosition(0, Other_lineRender.GetPosition(1));
    }


    #region 计算贝塞尔曲线的拟合点
    //初始化算出所有的点的信息
    void InitPoint(List<Transform> basePoint,LineRenderer lineRenderer )
    {
        //获取指定的点的信息
        Vector3[] pointPos = new Vector3[basePoint.Count];

        for (int i = 0; i < pointPos.Length; i++)
        {
            pointPos[i] = basePoint[i].transform.position;
        }
        GetTrackPoint(pointPos,lineRenderer);
    }

    /// <summary>
    /// 根据设定节点 绘制指定的曲线
    /// </summary>
    /// <param name="track">所有指定节点的信息</param>
    public void GetTrackPoint(Vector3[] track, LineRenderer lineRenderer)
    {
        Vector3[] vector3s = PathControlPointGenerator(track);
        int SmoothAmount = track.Length * baseCount;
        lineRenderer.positionCount = SmoothAmount;//节点之间的顶点数
        for (int i = 1; i < SmoothAmount; i++)
        {
            float pm = (float)i / SmoothAmount;
            Vector3 currPt = Interp(vector3s, pm);
            lineRenderer.SetPosition(i, currPt);//设定渲染线的节点位置
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

