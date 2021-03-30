using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Connect : MonoBehaviour {

    GameObject[] JJD;//碱基对
    List<GameObject> jjd = new List<GameObject>();
    // Use this for initialization
    void Start () {
        JJD = GameObject.FindGameObjectsWithTag("JJD").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 模拟连接酶的作用
    /// </summary>
    /// <param name="other"></param>

    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.name);
        for (int i = 0; i < JJD.Length; i++)
        {
            jjd.Add(JJD[i].gameObject);
        }
        if (other.transform.name== "G_C test(Clone)")
        {
            print("OK");
            GameObject G_p1 =JJD[2].transform.Find("G").transform.Find("G_p1").gameObject;
            GameObject A_p2 = JJD[3].transform.Find("A").transform.Find("A_p2").gameObject;
            GameObject GA_line;
            GA_line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            GA_line.GetComponent<CapsuleCollider>().isTrigger = true;
            GA_line.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
            GA_line.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
            GA_line.transform.localRotation = Quaternion.Euler(new Vector3(-80, 0, 85));
            Material newmaterial = new Material(Shader.Find("Unlit/Color"));
            GA_line.GetComponent<MeshRenderer>().material = newmaterial;
            GA_line.transform.name = "LSEZJ_L";
            GA_line.transform.parent = JJD[2].transform.Find("G").transform;

        }
    }
}
