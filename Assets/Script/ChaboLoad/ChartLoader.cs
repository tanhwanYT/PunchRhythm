using System.Collections.Generic;
using UnityEngine;

public class ChartLoader : MonoBehaviour
{
    public string fileName = "walp"; // Resources ������ �ִ� ���� �̸�
    private string chartData;         // ��ü ä�� ������
    public List<string> chartLines;   // �� ������ ���� ä�� ������

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
            Debug.Log("ä�� ������ �ε� �Ϸ�!");

            // �����͸� �� ������ �и��Ͽ� chartLines�� ����
            chartLines = new List<string>(chartData.Split('\n'));
        }
        else
        {
            Debug.LogError($"���� '{fileName}'��(��) ã�� �� �����ϴ�.");
        }
    }
}
