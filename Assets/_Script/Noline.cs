using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Noline : MonoBehaviour
{

    public GameObject A_T;
    public GameObject C_G;
    public GameObject T_A;
    public GameObject G_C;
    private int count = 20;    


    GameObject[] obj = new GameObject[100];


    

    // Use this for initialization
    void Start()
    {
        Init();


    }

    void Update()
    {
       Rotation();
    }


    void Init()
    {


        //obj[0] = GameObject.Instantiate(A_T);

        for (int i = 1; i < count;i++)
        {
            ////////////////////随机生成和螺旋形状//////////////////
            #region 随机生成和螺旋形状
            obj[i] = RandomCreate();
            obj[i].transform.position = new Vector3(0, i * 1.5f, 0);
            obj[i].transform.localRotation = Quaternion.Euler(0, i * 36, 0);
            obj[i].transform.parent = this.transform;
            #endregion


        }


        this.gameObject.transform.position = new Vector3(2, -15,80);

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
        int a = Random.Range(1, 101);//Range是左开又闭，随机产生[1,100]的数
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

    void Rotation()
    {
        //this.transform.localRotation = Quaternion.Euler(0, 0, -90);

      this.transform.Rotate(Vector3.up, 1f);
    }

    public void OnValueChange()
    {
        Transform[] JianJiDui= GetComponentsInChildren<Transform>();

        foreach(Transform JJD in JianJiDui)
        {
            if ( JJD.gameObject.name .ToString()!= "Create")
            {
                Destroy(JJD.gameObject);
            }
            if (JJD.gameObject.name.ToString() == "Create")
            {
                JJD.gameObject.transform.position = Vector3.zero;
              JJD.gameObject.transform.rotation= Quaternion.Euler(0, 0, 0);
            }
        }
    }

    /// <summary>
    /// 用输入框来控制生成的碱基对的个数
    /// </summary>


    public InputField InputText;
    public void EndInput()
    {
        count = int.Parse(InputText.text);
        Init();
       Rotation();

       
    }
}

