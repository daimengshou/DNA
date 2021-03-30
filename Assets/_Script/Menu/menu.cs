using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//做场景加载时必须引用的


public class menu : MonoBehaviour {

    public void VideoStudy()
    {
        SceneManager.LoadScene("Video 1");//做场景加载时，首先应添加场景。
    }
    public void DNAClip()
    {
        SceneManager.LoadScene("KnowClip");
    }
    public void ErrorShape()
    {
        SceneManager.LoadScene("KnowDNA");
    }
    public void DNACopy()
    {
        SceneManager.LoadScene("Copy_Content");
    }
    public void TestBtn()
    {
        SceneManager.LoadScene("测试");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Next()
    {
        SceneManager.LoadScene("Peidui");
        DynamicGI.UpdateEnvironment();

    }
    public void quit()
        {
        Application.Quit();
        }
    public void Copy_Content()
    {
        SceneManager.LoadScene("Copy");
    }
    public void Discuss()
    {
        SceneManager.LoadScene("DNAShapeDiscuss");
    }
    public void Error()
    {
        SceneManager.LoadScene("Error");
    }
}
