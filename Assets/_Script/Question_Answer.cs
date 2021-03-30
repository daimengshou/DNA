using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//做场景加载时必须引用的

public class Question_Answer : MonoBehaviour {

    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Answer1()
    {
        A1.SetActive(true);
        A2.SetActive(false);
        A3.SetActive(false);
        A4.SetActive(false);
    }
    public void Answer2()
    {
        A1.SetActive(false);
        A2.SetActive(true);
        A3.SetActive(false);
        A4.SetActive(false);
    }
    public void Answer3()
    {
        A1.SetActive(false);
        A2.SetActive(false);
        A3.SetActive(true);
        A4.SetActive(false);
    }
    public void Answer4()
    {
        A1.SetActive(false);
        A2.SetActive(false);
        A3.SetActive(false);
        A4.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene("Error_problem");
    }
    public void Next()
    {
        SceneManager.LoadScene("Menu");
    }
    public void mainScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextBtn()
    {
        SceneManager.LoadScene("Enzyme");
    }
    public void ReturnMeiBtn()
    {
        SceneManager.LoadScene("DrawCircle");
    }
}
