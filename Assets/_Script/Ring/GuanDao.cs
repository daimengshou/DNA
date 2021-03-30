using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuanDao : MonoBehaviour {

    private Vector3 centerPos;    //你围绕那个点 就用谁的角度
    private float radius = 10;     //物理离 centerPos的距离
    private float angle = 0;      //偏移角度  
    public Material touming;

    // Use this for initialization
    void Start () {
        CreateCubeAngle30();

    }

    public void CreateCubeAngle30()
    {
        centerPos = transform.position;
       // 20度生成一个圆
        for (angle = 0; angle < 360; angle += 6)
        {
            //先解决你物体的位置的问题
            // x = 原点x + 半径 * 邻边除以斜边的比例,   邻边除以斜边的比例 = cos(弧度) , 弧度 = 角度 *3.14f / 180f;   
            float x = centerPos.x + radius * Mathf.Cos(angle * 3.14f / 180f);
            float y = centerPos.y + radius * Mathf.Sin(angle * 3.14f / 180f);
            // 生成一个圆
            GameObject obj1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj1.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            obj1.transform.Rotate(new Vector3(0, 0, 36f));
            //设置物体的位置Vector3三个参数分别代表x,y,z的坐标数  
            obj1.transform.position = new Vector3(x, centerPos.z, y);
            obj1.transform.parent = this.transform;
            obj1.GetComponent<Renderer>().materials.SetValue( touming,0);
        }
    }


        // Update is called once per frame
        void Update () {
		
	}
}
