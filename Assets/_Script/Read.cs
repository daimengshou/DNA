using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//做场景加载时必须引用的
using Crosstales.RTVoice;
using Crosstales.RTVoice.Tool;
using Crosstales.RTVoice.Demo;


public class Read : MonoBehaviour
    {

        public GameObject SpeakText;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Next()
        {
            SceneManager.LoadScene("3D_DNA");
        }

        public void Return()
        {
            SceneManager.LoadScene("Menu");
        }

    public void Play()
    {
        SpeakText.GetComponent<SpeechText>().Speak();
    }
}

