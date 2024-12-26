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
            Debug.Log("ä�� ������ �ε� �Ϸ�!");
        }
        else
        {
            Debug.LogError($"���� '{fileName}'��(��) ã�� �� �����ϴ�.");
        }
    }

    public string GetChartData()
    {
        return chartData;
    }
}
