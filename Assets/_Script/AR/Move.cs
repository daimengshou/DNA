using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    RaycastHit hit;
    bool isMove = false;
    private Transform obj;

    void FixedUpdate()
    {
        if (isMove)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if ((Physics.Raycast(ray, out hit)) && (null != hit.collider))
                {
                obj = transform.GetComponent<Transform>();
                Vector3 screenPos = Camera.main.WorldToScreenPoint(obj.position);
              //  Vector3 offSet = obj.transform.position - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
                Vector3 WorldPos = Camera.main.ScreenToWorldPoint(mousePos);
                obj.position = WorldPos;
                 }
        }
    }

 void OnMouseDown()
    {
        isMove = !isMove;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
