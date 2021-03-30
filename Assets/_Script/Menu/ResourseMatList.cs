using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResourseMatList : MonoBehaviour
{
    public ResourseData[] ResourseDataList;//资源数组
    public GameObject ResourseButtonPrefab;//即将生成的按钮的预设体
    private bool isOpen = false;//判断画布是否打开
    public Transform ResourseContainer;//用来存放将要实例化物体按钮的容器
    public Transform ShowBtn;//用来控制UI 的按钮
    List<GameObject> Btn=new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        Ini();//调用初始化函数
        foreach (ResourseData data in ResourseDataList)
        {
            GameObject ResourseButton = Instantiate(ResourseButtonPrefab);//将按钮实例化
            ResourseButton.transform.parent = ResourseContainer;//将所实例化的按钮放置容器下
            RectTransform rect = ResourseButton.GetComponent<RectTransform>();//获取按钮的大小
            rect.localPosition = Vector3.zero;
            rect.localRotation = Quaternion.Euler(Vector3.zero);
            rect.localScale = Vector3.one;          
            ResourseButton.GetComponent<Button>().onClick.AddListener(delegate () { OnResourseButtonClicked(ResourseButton); });
            Btn.Add(ResourseButton);
        }

        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                Btn[i].transform.Find("Text").GetComponent<Text>().text = "AR模式下";
            }
            else
            {
                Btn[i].transform.Find("Text").GetComponent<Text>().text = "VR模式下";
            }
        }
    }



    /// <summary>
    /// 初始化函数
    /// </summary>
    private void Ini()
    {
        ResourseContainer.localScale = new Vector3(0, 0.2f, 1);//初始化下的UI容器为关闭的状态
    }





    //按钮点击响应的处理函数
    private void OnResourseButtonClicked(GameObject button)
    {

        foreach (Transform child in ResourseContainer)
        {
            if (button.transform == child)
            {
                if (button.transform.Find("Text").GetComponent<Text>().text == "AR模式下")
                {
                    SceneManager.LoadScene("PeiDui");
                }
                if (button.transform.Find("Text").GetComponent<Text>().text == "VR模式下")
                {
                    SceneManager.LoadScene("Error");
                }
            }

        }
    }

    /// <summary>
    /// 用来控制列表是否打开
    /// </summary>
    public void ShowMatList()
    {
        if (isOpen)
        {
            ResourseContainer.DOScale(new Vector3(0, 0.2f, 1), 0.3f);
        }
        else
        {
            ResourseContainer.DOScale(new  Vector3(0.8f,0.2f,1), 0.3f);
            int count =ResourseContainer.childCount;
            for (int i = 0; i < count; i++)
            {
                ResourseContainer.GetChild(i).localScale = Vector3.zero;
                ResourseContainer.GetChild(i).DOScale(Vector3.one, 0.3f).SetDelay(i * 0.3f + 0.3f);

            }
        }
        isOpen = !isOpen;
    }
}



