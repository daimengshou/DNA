using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Btn : MonoBehaviour {
    public GameObject Create;
    GameObject[] JJD;//碱基对

   public GameObject DNAPart;
    List<GameObject> jjd = new List<GameObject>();

    public GameObject MenuPanel;//简介的画布
    bool isOpen =true ;

    public GameObject Note;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;
    public GameObject XianzhimeiBtn;
    public GameObject MudijiyinBtn;
    public GameObject LianjiemeiBtn;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void XianZhiMei()
    {
        DNAPart.AddComponent<MovePosition>();
        JJD = GameObject.FindGameObjectsWithTag("JJD").OrderBy(g => g.transform.GetSiblingIndex()).ToArray();
        for (int i = 0; i < JJD.Length; i++)
            {
                jjd.Add(JJD[i].gameObject);
            }
        Destroy(jjd[2].transform.Find("G").transform.Find("LSEZJ_L").gameObject);
        Destroy(jjd[6].transform.Find("A").transform.Find("LSEZJ_R").gameObject);
        for (int i = 3; i < 7; i++)
        {
            Transform[] QJ = jjd[i].GetComponentsInChildren<Transform>();
            foreach (Transform qj in QJ)
            {
                if (qj.transform.name == "0" || qj.transform.name == "1" || qj.transform.name == "2")
                {
                    Destroy(qj.transform.gameObject);   //使氢键断裂

                }
            }
            }

        for (int i = 2; i <10; i++)
        {

            if (i > 6)
            {
                jjd[i].transform.localPosition = new Vector3(0, (i + 6) * 1.5f, 0);
            }
            if (i >= 3 && i < 7)
            {

                if (jjd[i].transform.name == "A_T test(Clone)")
                {

                    jjd[i].transform.Find("A").localPosition = new Vector3(jjd[i].transform.Find("A").localPosition.x, 0.248f + 9f, jjd[i].transform.Find("A").localPosition.z);//此处用了修正，不足处

                }
                if (jjd[i].transform.name == "T_A test (Clone)")
                {

                    jjd[i].transform.Find("T").localPosition = new Vector3(jjd[i].transform.Find("T").localPosition.x, 0.248f + 9f, jjd[i].transform.Find("T").localPosition.z);

                }
            }
        }
        Note.SetActive(false);
        Note1.SetActive(false);
        Note2.SetActive(true);
        Note3.SetActive(false);
        Note4.SetActive(false);
        XianzhimeiBtn.GetComponent<Button>().enabled = false;
        MudijiyinBtn.GetComponent<Button>().enabled = true;
    }

    public void CreateDNAPart()
    {
        DNAPart.SetActive(true);
        Note.SetActive(false);
        Note1.SetActive(false);
        Note2.SetActive(false);
        Note3.SetActive(true);
        Note4.SetActive(false);
        // DNAPart.AddComponent<Move>();
        MudijiyinBtn.GetComponent<Button>().enabled = false;
        LianjiemeiBtn.GetComponent<Button>().enabled = true;
    }

    public void Connect()
    {
        CreateLsezj_L("Candy", "Candy1");
        CreateLsezj_L("2", "1");
        CreateLsezj_R("3", "4");
        CreateLsezj_R("5", "6");
        Note.SetActive(false);
        Note1.SetActive(false);
        Note2.SetActive(false);
        Note3.SetActive(false);
        Note4.SetActive(true);
        LianjiemeiBtn.GetComponent<Button>().enabled = false;

    }

    /// <summary>
    /// 左侧链的连接酶使用后使其产生磷酸二脂键
    /// </summary>
    /// <param name="b"></param>
    /// <param name="c"></param>
    void CreateLsezj_L(string b, string c)
    {
        GameObject G_p1 = GameObject.FindWithTag(b).transform.gameObject;//寻找实例化后的p1
        GameObject A_p2 = GameObject.FindWithTag(c).transform.gameObject;
        GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        a.GetComponent<Renderer>().material.color = Color.red;
        a.transform.name = "LSEZJ_L";
        a.transform.parent = G_p1.transform.parent.transform;
        a.transform.localRotation = Quaternion.Euler(-80, -36, 85);
        a.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
        a.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
    }

    /// <summary>
    ///右侧链的连接酶使用后使其产生磷酸二脂键
    /// </summary>
    /// <param name="b"></param>
    /// <param name="c"></param>
    void CreateLsezj_R(string b, string c)
    {
        GameObject G_p1 = GameObject.FindWithTag(b).transform.gameObject;//寻找实例化后的p1
        GameObject A_p2 = GameObject.FindWithTag(c).transform.gameObject;
        GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        a.GetComponent<Renderer>().material.color = Color.red;
        a.transform.name = "LSEZJ_R";
        a.transform.parent = G_p1.transform.parent.transform;
        a.transform.localRotation = Quaternion.Euler(-80, -68, -95);
        a.transform.position = Vector3.Lerp(G_p1.transform.position, A_p2.transform.position, 0.5f);
        a.transform.localScale = new Vector3(0.1f, 1.2f, 0.1f);
    }

    public void NextBtn()
    {
        SceneManager.LoadScene("DrawCircle");
    }

    public void ReturnBtn()
    {
        SceneManager.LoadScene("Enzyme");
    }

    public void ZhiLiBtn()
    {
        Create.SetActive(true);
        Note.SetActive(false);
        Note1.SetActive(true);
        Note2.SetActive(false);
        Note3.SetActive(false);
        Note4.SetActive(false);
        XianzhimeiBtn.GetComponent<Button>().enabled = true;
    }

    public void OpenMenu()
    {
        if (isOpen == false)
        {
            MenuPanel.transform.DOScale(Vector3.one, 0.3f);
        }
        if (isOpen == true)
        {
            MenuPanel.transform.DOScale(new Vector3(1, 0, 1), 0.3f);
        }
        isOpen = !isOpen;
    }
    public void Reload()
    {
        SceneManager.LoadScene("Shape");
    }
}

