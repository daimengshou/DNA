using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------
//此脚本由“RandomJianJi.cs”动态添加，用来设置游离碱基的运动
//------------------------------------------------------------

public class RandomMoveJianJi : MonoBehaviour {

    //Vector3 Velocity01;                      //随机运动
    //Vector3 Velocity02;
    //Vector3 Velocity03;
    //Vector3 Velocity04;
    //Vector3 Velocity05;
    //Vector3 Velocity06;
    //Vector3 Velocity07;

    ///////////用来做随机位置移动的控制////////////
    Vector3 Velocity01 = new Vector3(1.0f, 1.0f, 0.0f);
    Vector3 Velocity02 = new Vector3(0.0f, 2.0f, 1.0f);
    Vector3 Velocity03 = new Vector3(-1.0f, 0.0f, 1.0f);
    Vector3 Velocity04 = new Vector3(1.0f, 2.0f, -1.0f);
    Vector3 Velocity05 = new Vector3(2.0f, -1.0f, 0.0f);
    Vector3 Velocity06 = new Vector3(1.0f, 2.0f, 2.0f);
    Vector3 Velocity07 = new Vector3(-2.0f, 0.0f, 0.0f);
    // Use this for initialization
    void Start () {


 
    }

    // Update is called once per frame
    void Update () {

        RandomlyMove(this.gameObject);
    }

    public void RandomlyMove(GameObject Object)
    {
        float n = Random.Range(1.0f, 14.0f);
        if (1.0f <= n && n <= 2.0f)
        {
            //Object.GetComponent<Rigidbody>().velocity = Velocity01;
            StartCoroutine(Move(this.gameObject,Velocity01));
        }
        else if (2.0f < n && n <= 4.0f)
        {
            //Object.GetComponent<Rigidbody>().velocity = Velocity02;
            StartCoroutine(Move(this.gameObject, Velocity02));
        }
        else if (4.0f < n && n <= 6.0f)
        {
            //Object.GetComponent<Rigidbody>().velocity = Velocity03;
            StartCoroutine(Move(this.gameObject, Velocity03));
        }
        else if (6.0f < n && n <= 8.0f)
        {
            //Object.GetComponent<Rigidbody>().velocity = Velocity04;
            StartCoroutine(Move(this.gameObject, Velocity04));
        }
        else if (8.0f < n && n <= 10.0f)
        {
            //Object.GetComponent<Rigidbody>().velocity = Velocity05;
            StartCoroutine(Move(this.gameObject, Velocity05));
        }
        else if (10.0f < n && n <= 12.0f)
        {
            //Object.GetComponent<Rigidbody>().velocity = Velocity06;
            StartCoroutine(Move(this.gameObject, Velocity06));
        }
        else if (12.0f < n && n <= 14.0f)
        {
            //Object.GetComponent<Rigidbody>().velocity = Velocity07;
            StartCoroutine(Move(this.gameObject, Velocity07));
        }
    }

    IEnumerator Move(GameObject Object, Vector3 Velocity)
    {
        Object.GetComponent<Rigidbody>().velocity = Velocity;

         yield return new WaitForSeconds(15.0f);
        //  yield return null;
        Destroy(Object);
    }
}
