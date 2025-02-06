using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODMusicPlayer : MonoBehaviour
{
    private EventInstance musicEvent;

    void Start()
    {
        // FMOD �̺�Ʈ ����
        musicEvent = RuntimeManager.CreateInstance("event:/Xomu - Walpurgis Night [ ezmp3.cc ]");

        // �̺�Ʈ�� ��ȿ���� Ȯ��
        if (musicEvent.isValid())
        {
            Debug.Log("FMOD �̺�Ʈ ���� ����");
            musicEvent.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            musicEvent.start();
        }
        else
        {
            Debug.LogError("FMOD �̺�Ʈ ���� ����! ��θ� Ȯ���ϼ���.");
        }
    }

    void OnDestroy()
    {
        musicEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEvent.release();
    }
}
