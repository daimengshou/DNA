using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ini : MonoBehaviour
{

    public GameObject A_T;
    public GameObject C_G;
    public int count;
    GameObject[] obj=new GameObject[20];
   


    // Use this for initialization
    void Start()
    {
        Init();
   
    }



      void Init()
       {


        //obj[0] = GameObject.Instantiate(A_T);

        for (int i =1; i < count; i++)
        {
            ////////////////////随机生成和螺旋形状//////////////////
            #region 随机生成和螺旋形状
            obj[i] = RandomCreate();
          
            obj[i].transform.position = new Vector3(0,  i , 0);
            obj[i].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
            obj[i].transform.parent = this.transform;
            #endregion

        }

        foreach (GameObject Obj in obj)//遍历数组中的元素
        {
            for (int i =1; i < count; i++)
            {
                #region 在T一侧产生磷酸二脂键
                GameObject T_p1 = obj[i].transform.Find("T_p1").gameObject;//寻找实例化后的p1
            GameObject T_p2 = obj[i + 1].transform.Find("T_p2").gameObject;         
                GameObject T_line;
                T_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);//用圆柱体来做线
                T_line.transform.position = Vector3.Lerp(T_p1.transform.position, T_p2.transform.position, 0.5f);
                T_line.transform.localScale = new Vector3(0.1f, 1, 0.1f);
                T_line.transform.localRotation =Quaternion.Euler (new Vector3(80,86+i*36,87));
            Material newmaterial = new Material(Shader.Find("Unlit/Color"));
            newmaterial.SetColor("_Color", Color.black);
                T_line.GetComponent<MeshRenderer>().material = newmaterial;
                T_line.transform.parent = this.transform;
                #endregion


                #region  在A 一侧产生磷酸二脂键
                GameObject A_p1 = obj[i].transform.Find("A_p1").gameObject;
                GameObject A_p2 = obj[i+1].transform.Find("A_p2").gameObject;
                GameObject A_line;
                A_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                A_line.transform.position = Vector3.Lerp(A_p1.transform.position, A_p2.transform.position, 0.5F);
               A_line.transform.localRotation = Quaternion.Euler(new Vector3(80, -56 + i * 36, 87));
                A_line.transform.localScale = new Vector3(0.1f, 1, 0.1f);
                A_line.GetComponent<MeshRenderer>().material = newmaterial;
                A_line.transform.parent = this.transform;
                #endregion


            }
        }

    }

    /// <summary>
    /// /随机生成
    /// </summary>
    /// <returns></returns>
    GameObject RandomCreate()
    {
       // print("随机");
        GameObject Gb;//实例化的物体
      int a = Random.Range(0, 100);
        if (a%2!=0)
        {
            Gb = GameObject.Instantiate(A_T);
            return Gb;
        }
        else
        {
            Gb = GameObject.Instantiate(C_G);
            return Gb;
        }
    }

}