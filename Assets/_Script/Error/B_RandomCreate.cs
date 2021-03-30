using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_RandomCreate : MonoBehaviour {

    //////////主要的用来实例化的预设体/////
    public GameObject A_L;
    public GameObject T_L;
    public GameObject C_L;
    public GameObject G_L;
    public GameObject A_R;
    public GameObject T_R;
    public GameObject C_R;
    public GameObject G_R;


    public GameObject Lian1;
    public GameObject Lian2;

    // GameObject obj = new GameObject();

    private int count = 10;
    GameObject[] M_obj = new GameObject[100];
    GameObject[] S_obj = new GameObject[100];

    // Use this for initialization
    void Start () {
        Init();
        Lian1.SetActive(true);
        Lian2.SetActive(true);
        this.transform.position = new Vector3(6.5f, 0, 0);
	}
	
    void Init()
    {

        for (int i = 0; i < count; i++)
        {
            M_obj[i + 1] = MainChain();
            M_obj[i + 1].transform.position = new Vector3(0, i * 2f, 0);
            // M_obj[i + 1].transform.parent = this.transform;
        }


        for (int i = 0; i < count; i++)
        {
            if (M_obj[i + 1].transform.name == "A_L(Clone)")
            {
                S_obj[i + 1] = SecondChain_A();
                if (S_obj[i + 1].transform .name == "T_R(Clone)")
                {
                    GameObject obj = new GameObject("A_T");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }
               if( S_obj[i + 1].transform.name  =="C_R(Clone)")
                {
                    GameObject obj = new GameObject("G_C");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;

                }
                if (S_obj[i + 1].transform.name =="G_R(Clone)") 
                {
                    GameObject obj = new GameObject("C_G");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }           

            }
            if (M_obj[i + 1].transform.name == "T_L(Clone)")
            {
                //S_obj[i + 1] = SecondChain_T();
                //GameObject obj = new GameObject("T_A");
                //S_obj[i + 1].transform.parent = obj.transform;
                //M_obj[i + 1].transform.parent = obj.transform;
                //obj.transform.parent = this.transform;
                S_obj[i + 1] = SecondChain_T();
                if (S_obj[i + 1].transform.name == "A_R(Clone)")
                {
                    GameObject obj = new GameObject("T_A");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }
                if (S_obj[i + 1].transform.name == "C_R(Clone)")
                {
                    GameObject obj = new GameObject("G_C");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;

                }
                if (S_obj[i + 1].transform.name == "G_R(Clone)")
                {
                    GameObject obj = new GameObject("C_G");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }

            }
            if (M_obj[i + 1].transform.name == "C_L(Clone)")
            {
                //S_obj[i + 1] = SecondChain_C();
                //GameObject obj = new GameObject("C_G");
                //S_obj[i + 1].transform.parent = obj.transform;
                //M_obj[i + 1].transform.parent = obj.transform;
                //obj.transform.parent = this.transform;
                S_obj[i + 1] = SecondChain_C();
                if (S_obj[i + 1].transform.name == "T_R(Clone)")
                {
                    GameObject obj = new GameObject("A_T");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }
                if (S_obj[i + 1].transform.name == "A_R(Clone)")
                {
                    GameObject obj = new GameObject("T_A");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;

                }
                if (S_obj[i + 1].transform.name == "G_R(Clone)")
                {
                    GameObject obj = new GameObject("C_G");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }

            }
            if (M_obj[i + 1].transform.name == "G_L(Clone)")
            {
                //S_obj[i + 1] = SecondChain_G();
                //GameObject obj = new GameObject("G_C");
                //S_obj[i + 1].transform.parent = obj.transform;
                //M_obj[i + 1].transform.parent = obj.transform;
                //obj.transform.parent = this.transform;
                S_obj[i + 1] = SecondChain_G();
                if (S_obj[i + 1].transform.name == "T_R(Clone)")
                {           
                    GameObject obj = new GameObject("A_T");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }
                if (S_obj[i + 1].transform.name == "C_R(Clone)")
                {
                    GameObject obj = new GameObject("G_C");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;

                }
                if (S_obj[i + 1].transform.name == "A_R(Clone)")
                {
                    GameObject obj = new GameObject("T_A");
                    S_obj[i + 1].transform.parent = obj.transform;
                    M_obj[i + 1].transform.parent = obj.transform;
                    obj.transform.tag = "JJD";
                    obj.transform.parent = this.transform;
                }

            }

            S_obj[i + 1].transform.position = new Vector3(0, i * 2f, 0);
            //S_obj[i + 1].transform.parent = this.transform;


        }
    }

    
	// Update is called once per frame
	void Update () {

    }

    GameObject MainChain() {
        GameObject Gb;

        int a = Random.Range(1, 101);//Range是左开又闭，随机产生[1,100]的数
        if ((a - 1) % 4 == 0)
        {
            Gb = GameObject.Instantiate(A_L);
            return Gb;
        }
        else if ((a - 2) % 4 == 0)
        {
            Gb = GameObject.Instantiate(C_L);
            return Gb;
        }
        else if ((a - 3) % 4 == 0)
        {
            Gb = GameObject.Instantiate(T_L);
            return Gb;
        }
        else
        {
            Gb = GameObject.Instantiate(G_L);
            return Gb;
        }
    }


    GameObject SecondChain_A()
    {

        GameObject obj1;
        int a = Random.Range(1, 91);//Range是左开又闭，随机产生[1,100]的数
        if ((a - 1) % 3 == 0)
        {
            obj1 = GameObject.Instantiate(T_R);
            return obj1;
        }
        else if ((a - 2) % 3 == 0)
        {
            obj1 = GameObject.Instantiate(C_R);
            return obj1;
        }
        else
        {
            obj1 = GameObject.Instantiate(G_R);
            return obj1;
        }
    }

    GameObject SecondChain_T()
    {

        GameObject Gb;
        int a = Random.Range(1, 91);//Range是左开又闭，随机产生[1,100]的数
        if ((a - 1) % 3 == 0)
        {
            Gb = GameObject.Instantiate(A_R);
            return Gb;
        }
        else if ((a - 2) % 3 == 0)
        {
            Gb = GameObject.Instantiate(C_R);
            return Gb;
        }
        else
        {
            Gb = GameObject.Instantiate(G_R);
            return Gb;
        }
    }
    GameObject SecondChain_C()
    {

        GameObject Gb;
        int a = Random.Range(1, 91);//Range是左开又闭，随机产生[1,100]的数
        if ((a - 1) % 3 == 0)
        {
            Gb = GameObject.Instantiate(T_R);
            return Gb;
        }
        else if ((a - 2) % 3 == 0)
        {
            Gb = GameObject.Instantiate(A_R);
            return Gb;
        }
        else
        {
            Gb = GameObject.Instantiate(G_R);
            return Gb;
        }
    }
    GameObject SecondChain_G()
    {

        GameObject Gb;
        int a = Random.Range(1, 91);//Range是左开又闭，随机产生[1,100]的数
        if ((a - 1) % 3 == 0)
        {
            Gb = GameObject.Instantiate(T_R);
            return Gb;
        }
        else if ((a - 2) % 3 == 0)
        {
            Gb = GameObject.Instantiate(A_R);
            return Gb;
        }
        else
        {
            Gb = GameObject.Instantiate(C_R);
            return Gb;
        }
    }
}
