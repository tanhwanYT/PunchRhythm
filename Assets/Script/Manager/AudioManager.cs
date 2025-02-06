using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODMusicPlayer : MonoBehaviour
{
    private EventInstance musicEvent;

    void Start()
    {
        // FMOD 이벤트 생성
        musicEvent = RuntimeManager.CreateInstance("event:/Xomu - Walpurgis Night [ ezmp3.cc ]");

        // 이벤트가 유효한지 확인
        if (musicEvent.isValid())
        {
            Debug.Log("FMOD 이벤트 생성 성공");
            musicEvent.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            musicEvent.start();
        }
        else
        {
            Debug.LogError("FMOD 이벤트 생성 실패! 경로를 확인하세요.");
        }
    }

    void OnDestroy()
    {
        musicEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEvent.release();
    }
}
