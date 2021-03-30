using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateYouLiJianJi : MonoBehaviour {

    //用来做游离碱基的预设体
    public GameObject A_L;
    public GameObject A_R;
    public GameObject T_L;
    public GameObject T_R;
    public GameObject C_L;
    public GameObject C_R;
    public GameObject G_L;
    public GameObject G_R;



    // public GameObject Obj1;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        RandomCreateYouLiJianJi();




    }

    #region 
    //随机生成碱基及其位置
    public void RandomCreateYouLiJianJi()
    {
        GameObject obj = null;

        float n = UnityEngine. Random.Range(0.0f, 20.0f);//随机在该范围内生成一个数字，控制生成的碱基类型的不同
        int num = UnityEngine.Random.Range(0, 20);
        if (n <= 2.5f)
        {
            obj = GameObject.Instantiate(A_L);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);//缩放其大小为了使其能够在屏幕上和DNA双链呈现的大小相近
            obj.transform.parent = this.transform;//存放在当前的对象下作为子物体
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
           // obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
            //obj.AddComponent<Bouncy>();
        }
        else if (2.5f< n && n <= 5.0f)
        {
            obj = GameObject.Instantiate(A_R);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.parent = this.transform;
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
          //  obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
            //obj.AddComponent<Bouncy>();

        }
        else if (5.0f <n && n <=7.5f)
        {
            obj = GameObject.Instantiate(T_L);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.parent = this.transform;
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
         //   obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
            //obj.AddComponent<Bouncy>();

        }
        else if (7.5f <n && n <=10.0f)
        {
            obj = GameObject.Instantiate(T_R);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.parent = this.transform;
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
            //obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
           // obj.AddComponent<Bouncy>();

        }
       else if (10.0f< n && n <=12.5f)
        {
            obj = GameObject.Instantiate(C_L);
             obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.parent = this.transform;
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
         //   obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
           // obj.AddComponent<Bouncy>();

        }
        else if (12.5f < n && n <= 15.0f)
        {
            obj = GameObject.Instantiate(C_R);
             obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.parent = this.transform;
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
            //obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
           // obj.AddComponent<Bouncy>();

        }
        else if (15.0f < n && n <=17.5f)
        {
            obj = GameObject.Instantiate(G_L);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.parent = this.transform;
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
         //   obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
            //obj.AddComponent<Bouncy>();

        }
        else if (17.5f < n && n <= 20.0f)
        {
            obj = GameObject.Instantiate(G_R);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.parent = this.transform;
            if (num % 2 == 0)
            {
                obj.transform.position = RandomPos_One();
            }
            if (num % 2 != 0)
            {
                obj.transform.position = RandomPos_Two();
            }
            obj.AddComponent<RandomRotateJianJi>();
          //  obj.AddComponent<RandomMoveJianJi>();

            //obj.AddComponent<BoxCollider>();
            //obj.transform.GetComponent<BoxCollider>().isTrigger = true;
            //obj.AddComponent<Bouncy>();

        }

    }

    //控制随机位置生成的函数
     public  Vector3 RandomPos_One()
    {
        Vector3 Postion;
        float a= UnityEngine. Random.Range(-10f, 10f);//随机在该范围内生成一个数字
        float b = UnityEngine.Random.Range(-7f, -3f);//随机在该范围内生成一个数字
        float c = UnityEngine.Random.Range(2f, 3f);//随机在该范围内生成一个数字
        Postion = new Vector3(a, b, c);
        return Postion;

    }
    public Vector3 RandomPos_Two()
    {
        Vector3 Postion;
        float a = UnityEngine.Random.Range(-10f, 10f);//随机在该范围内生成一个数字
        float b= UnityEngine.Random.Range(3f, 7f);//随机在该范围内生成一个数字
        float c = UnityEngine.Random.Range(2f,3f);//随机在该范围内生成一个数字
        Postion = new Vector3(a, b, c);
        return Postion;

    }
    #endregion



}
