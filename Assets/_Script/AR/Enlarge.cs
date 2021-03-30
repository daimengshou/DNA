using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour {
    Vector2 OldPos1;
    Vector2 OldPos2;
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved ||Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Vector2 NewPos1 = Input.GetTouch(0).position;
                Vector2 NewPos2 = Input.GetTouch(1).position;
                float oldScale = transform.localScale.x;
                if (IsEnlarge(OldPos1, OldPos2, NewPos1, NewPos2))
                {
                    
                    float newScale = oldScale * 1.025f;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                else
                {
                    float newScale = oldScale / 1.025f;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                OldPos1 = NewPos1;
                OldPos2 = NewPos2;
            }
        }
	}


    bool IsEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        float L1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float L2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (L1 < L2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
