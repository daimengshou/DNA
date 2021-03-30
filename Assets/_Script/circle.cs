using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{

    // Use this for initialization
    public GameObject circleModel;
    //旋转改变的角度
    public int changeAngle = 0;
    //旋转一周需要的预制物体个数
    private int count;

    private float angle = 0;
    public float r = 5;
   public GameObject zaiti;

    // Use this for initialization
    void Start()
    {
        count = (int)360 / changeAngle;//旋转一周的预设体个数
        for (int i = 0; i < count; i++)
        {
            Vector3 center =circleModel.transform.position;
            GameObject cube = (GameObject)Instantiate(circleModel);
            float hudu = (angle / 180) * Mathf.PI;//将角度转换成弧度制
            float xx = center.x + r * Mathf.Cos(hudu);
            float yy = center.y + r * Mathf.Sin(hudu);
            cube.transform.position = new Vector3(xx, yy, 0);
            cube.transform.LookAt(center);
            angle += changeAngle;
            cube.transform.parent = zaiti.transform;
            if (i >= 0 && i < 10)
            {
                cube.GetComponent<Renderer>().material.color = new Color32(185, 249, 210, 255);
            }
            if (i >=10 && i < 14)
            {
                cube.GetComponent<Renderer>().material.color = new Color32(244, 186, 237, 255);
            }
            if (i >= 16 && i <20)
            {
                cube.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (i >= 23&& i < 30)
            {
                cube.GetComponent<Renderer>().material.color = new Color32(243, 158, 248, 255);
            }
            if (i >= 33 && i <=36)
            {
                cube.GetComponent<Renderer>().material.color = Color.cyan;
            }
        }

       zaiti.transform.position = new Vector3(10f, 0, 13);
       zaiti.transform.localScale =  Vector3.one;
    }
}
