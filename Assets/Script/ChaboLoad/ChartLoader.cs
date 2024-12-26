using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartLoader : MonoBehaviour
{
    public string fileName = "test2"; 
    private string chartData;

    private void Awake()
    {
        LoadChartFromFile();
    }

    private void LoadChartFromFile()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        if (textAsset != null)
        {
            chartData = textAsset.text;
            Debug.Log("채보 데이터 로드 완료!");
        }
        else
        {
            Debug.LogError($"파일 '{fileName}'을(를) 찾을 수 없습니다.");
        }
    }

    public string GetChartData()
    {
        return chartData;
    }
}
