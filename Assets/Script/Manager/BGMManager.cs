using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;  // �̱���

    private EventInstance mainBGM;  // ���� �������
    private EventInstance gameBGM;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // ���� �ٲ� ����
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // ���� BGM ����
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
        if (scene.name == "MainScene") // ���Ӿ� ���� ��
        {
            mainBGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);  // ���� BGM ����
            gameBGM = RuntimeManager.CreateInstance("event:/GodChangSub");
            gameBGM.set3DAttributes(RuntimeUtils.To3DAttributes(Camera.main.transform));
            gameBGM.start();

        }
        else if (scene.name == "StartScene" || scene.name == "SongSelectScene")
        {
            gameBGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);  // ���� BGM ����
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
