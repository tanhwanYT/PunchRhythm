using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public RectTransform buttonTransform; // UI 버튼의 RectTransform
    public float scaleFactor = 1.2f; // 최대 크기 배율
    public float speed = 1f; // 크기 변화 속도

    private Vector3 originalScale;
    public void SceneChange()
    {
        SceneManager.LoadScene("SongSelectScene");
    }

    void Start()
    {
        originalScale = buttonTransform.localScale;
        StartCoroutine(ScaleButtonLoop());
    }

    IEnumerator ScaleButtonLoop()
    {
        while (true)
        {
            // 커지기
            yield return StartCoroutine(ScaleTo(originalScale * scaleFactor, speed));
            // 작아지기
            yield return StartCoroutine(ScaleTo(originalScale, speed));
        }
    }

    IEnumerator ScaleTo(Vector3 targetScale, float duration)
    {
        Vector3 startScale = buttonTransform.localScale;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            buttonTransform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            yield return null;
        }

        buttonTransform.localScale = targetScale;
    }
}
