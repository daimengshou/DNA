using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;//引入命名空间
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Voice : MonoBehaviour {

    /// <summary> /// 短语识别器 /// </summary>  /// 
    private PhraseRecognizer m_PhraseRecognizer;
    /// <summary> /// 关键字 /// </summary>
    public string[] keywords;
    /// <summary> /// 可信度 /// </summary>
    public ConfidenceLevel m_confidenceLevel = ConfidenceLevel.Medium;

    public Canvas can;

    // Use this for initialization
    void Start()
    {
        //创建一个识别器
        m_PhraseRecognizer = new KeywordRecognizer(keywords, m_confidenceLevel);
        //通过注册监听的方法 
        m_PhraseRecognizer.OnPhraseRecognized += M_PhraseRecognizer_OnPhraseRecognized;
        //开启识别器 
        m_PhraseRecognizer.Start();
    }
    /// <summary> /// 当识别到关键字时，会调用这个方法 /// </summary> /// <param name="args"></param> 
    private void M_PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {

        if (args.text == "视频学习")
        {
            SceneManager.LoadScene("Video 1");
        }
        if (args.text == "DNA结构")
        {
            SceneManager.LoadScene("KnowDNA");
        }
        if (args.text == "构建载体的表达")
        {
            SceneManager.LoadScene("KnowClip");
        }
        if (args.text == "DNA复制")
        {
            SceneManager.LoadScene("Copy_Content");
        }

    }
    private void OnDestroy()
    { //用完应该释放，否则会带来额外的开销 
        m_PhraseRecognizer.Dispose();
    }
    // Update is called once per frame
    void Update()
    {

    }

}


