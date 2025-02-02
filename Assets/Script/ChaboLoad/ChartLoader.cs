using System.Collections.Generic;
using UnityEngine;

public class ChartLoader : MonoBehaviour
{
    public string fileName = "walp"; // Resources 폴더에 있는 파일 이름
    private string chartData;         // 전체 채보 데이터
    public List<string> chartLines;   // 줄 단위로 나눈 채보 데이터

    private void Start()
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

            // 데이터를 줄 단위로 분리하여 chartLines에 저장
            chartLines = new List<string>(chartData.Split('\n'));
        }
        else
        {
            Debug.LogError($"파일 '{fileName}'을(를) 찾을 수 없습니다.");
        }
    }
}
