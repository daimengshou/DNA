/*===============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VideoPlayer))]//自动的给对象添加必要的组件
public class VideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Button m_PlayButton;//开始的按钮
    public RectTransform m_ProgressBar;//进度条

    #region MONOBEHAVIOUR_METHODS

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();//获取对象身上的组件
        videoPlayer.errorReceived += HandleVideoError;
        videoPlayer.started += HandleStartedEvent;
        videoPlayer.prepareCompleted += HandlePrepareCompleted;
        videoPlayer.seekCompleted += HandleSeekCompleted;
        videoPlayer.loopPointReached += HandleLoopPointReached;

        LogClipInfo();
    }

    void Update()
    {

        if (videoPlayer.isPlaying)
        {
            ShowPlayButton(false);//判断开始、暂停与否

            if (videoPlayer.frameCount < float.MaxValue)//在未完全播放完的状态下
            {
                float frame = (float)videoPlayer.frame;
                float count = (float)videoPlayer.frameCount;

                float progressPercentage = 0;

                if (count > 0)
                    progressPercentage = (frame / count) * 100.0f;

                if (m_ProgressBar != null)
                    m_ProgressBar.sizeDelta = new Vector2((float)progressPercentage, m_ProgressBar.sizeDelta.y);
            }

        }
        else
        {
            ShowPlayButton(true);
        }
    }

    /// <summary>
    /// /判断是否为暂停的状态
    /// </summary>
    /// <param name="pause"></param>
    void OnApplicationPause(bool pause)
    {
        Debug.Log("OnApplicationPause(" + pause + ") called.");
        if (pause)
            Pause();
    }

    #endregion // MONOBEHAVIOUR_METHODS


    #region PUBLIC_METHODS

    public void Play()
    {
        Debug.Log("Play Video");
        PauseAudio(false);
        videoPlayer.Play();
        ShowPlayButton(false);
    }

    public void Pause()
    {
        if (videoPlayer)
        {
            Debug.Log("Pause Video");
            PauseAudio(true);
            videoPlayer.Pause();//将组件的暂停状态唤起
            ShowPlayButton(true);
        }
    }

    public void Left()
    {
        SceneManager.LoadScene("menu");
    }

    #endregion // PUBLIC_METHODS


    #region PRIVATE_METHODS

    private void PauseAudio(bool pause)
    {
        for (ushort trackNumber = 0; trackNumber < videoPlayer.audioTrackCount; ++trackNumber)
        {
            if (pause)
                videoPlayer.GetTargetAudioSource(trackNumber).Pause();
            else
                videoPlayer.GetTargetAudioSource(trackNumber).UnPause();
        }
    }

    private void ShowPlayButton(bool enable)
    {
        m_PlayButton.enabled = enable;
        m_PlayButton.GetComponent<Image>().enabled = enable;
    }

    private void LogClipInfo()
    {
        if (videoPlayer.clip != null)
        {
            string stats =
                "\nName: " + videoPlayer.clip.name +
                "\nAudioTracks: " + videoPlayer.clip.audioTrackCount +
                "\nFrames: " + videoPlayer.clip.frameCount +
                "\nFPS: " + videoPlayer.clip.frameRate +
                "\nHeight: " + videoPlayer.clip.height +
                "\nWidth: " + videoPlayer.clip.width +
                "\nLength: " + videoPlayer.clip.length +
                "\nPath: " + videoPlayer.clip.originalPath;

            Debug.Log(stats);
        }
    }

    #endregion // PRIVATE_METHODS


    #region DELEGATES

    void HandleVideoError(VideoPlayer video, string errorMsg)
    {
        Debug.LogError("Error: " + video.clip.name + "\nError Message: " + errorMsg);
    }

    void HandleStartedEvent(VideoPlayer video)
    {
        Debug.Log("Started: " + video.clip.name);
    }

    void HandlePrepareCompleted(VideoPlayer video)
    {
        Debug.Log("Prepare Completed: " + video.clip.name);
    }

    void HandleSeekCompleted(VideoPlayer video)
    {
        Debug.Log("Seek Completed: " + video.clip.name);
    }

    void HandleLoopPointReached(VideoPlayer video)
    {
        Debug.Log("Loop Point Reached: " + video.clip.name);

        ShowPlayButton(true);
    }

    #endregion //DELEGATES

}
