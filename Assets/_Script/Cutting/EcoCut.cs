using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoCut : MonoBehaviour {

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //如果是一根手指触摸屏幕而且是刚开始触摸屏幕
               if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (Input.GetTouch(0).tapCount == 1)
                   {//判断点击的次数
                        Destroy(hit.collider.gameObject);//销毁场景中的模型
                  }
                }
            }
        }
    }
}
