using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotateJianJi : MonoBehaviour {

    //Vector3 RotateAngles01;                    //随机旋转
    //Vector3 RotateAngles02;
    //Vector3 RotateAngles03;
    //Vector3 RotateAngles04;
    //Vector3 RotateAngles05;


     ///////////用来做随机旋转的旋转角度控制////////////
    Vector3 RotateAngles01 = new Vector3(0.50f, 0.0f, 0.0f);
    Vector3 RotateAngles02 = new Vector3(0.50f, 1.0f, 0.0f);
   // Vector3 RotateAngles03 = new Vector3(0.0f, 0.0f, 15.0f);
    Vector3 RotateAngles04 = new Vector3(0.50f, 0.0f, 0.0f);
    Vector3 RotateAngles05 = new Vector3(0.50f, 10.0f, 0.0f);

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        RandomlyRotate(this.gameObject);
    }

    public void RandomlyRotate(GameObject Object)
    {
        float n = Random.Range(1.0f,12.0f);

        if (1.0f <= n && n <= 3.0f)
        {
            StartCoroutine(RotateJianJi(this.gameObject,RotateAngles01));          
        }
        else if (3.0f < n && n <= 6.0f)
        {
            StartCoroutine(RotateJianJi(this.gameObject,RotateAngles02));
        }
        else if (6.0f < n && n <= 9.0f)
        {
            StartCoroutine(RotateJianJi(this.gameObject, RotateAngles05));
   
        }
        else if (9.0f < n && n <= 12.0f)
        {
            StartCoroutine(RotateJianJi(this.gameObject, RotateAngles04));
        }
        //else if (12.0f < n && n <= 15.0f)
        //{
        //    StartCoroutine(RotateJianJi(this.gameObject, RotateAngles03));
        //}
    }

    IEnumerator  RotateJianJi(GameObject Object, Vector3 RotateAngles)
    {
        Object.transform.Rotate(RotateAngles, Space.Self);
        yield return new WaitForSeconds(30.0f);//做的时间延迟

       // Destroy(Object);
        // yield return null;
    }
}
