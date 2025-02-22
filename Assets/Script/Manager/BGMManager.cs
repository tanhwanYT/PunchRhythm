using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;  // 싱글톤

    private EventInstance mainBGM;  // 메인 배경음악


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 메인 BGM 실행
        mainBGM = RuntimeManager.CreateInstance("event:/MainMusic");
        mainBGM.set3DAttributes(RuntimeUtils.To3DAttributes(Camera.main.transform));
        mainBGM.start();
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene") // 게임씬 진입 시
        {
            mainBGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);  // 메인 BGM 종료

        }
        else if (scene.name == "StartScene" || scene.name == "SongSelectScene")
        {
            if (!mainBGM.isValid())
            {
                mainBGM = RuntimeManager.CreateInstance("event:/MainMusic");
                mainBGM.start();
            }
        }
    }

    void OnDestroy()
    {
        mainBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        mainBGM.release();

    }
}
