using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RAINBOWBUTTON : MonoBehaviour
{
    public Button targetButton; // 버튼 컴포넌트
    public float duration = 2f; // 한 바퀴 도는 시간

    void Start()
    {
        StartCoroutine(ChangeColorLoop());
    }

    IEnumerator ChangeColorLoop()
    {
        Image buttonImage = targetButton.GetComponent<Image>();
        while (true)
        {
            yield return StartCoroutine(LerpColor(buttonImage, Color.red, Color.yellow, duration / 6));
            yield return StartCoroutine(LerpColor(buttonImage, Color.yellow, Color.green, duration / 6));
            yield return StartCoroutine(LerpColor(buttonImage, Color.green, Color.cyan, duration / 6));
            yield return StartCoroutine(LerpColor(buttonImage, Color.cyan, Color.blue, duration / 6));
            yield return StartCoroutine(LerpColor(buttonImage, Color.blue, Color.magenta, duration / 6));
            yield return StartCoroutine(LerpColor(buttonImage, Color.magenta, Color.red, duration / 6));
        }
    }

    IEnumerator LerpColor(Image image, Color from, Color to, float time)
    {
        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(from, to, elapsedTime / time);
            yield return null;
        }
        image.color = to;
    }
}
