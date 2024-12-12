using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ChartLoader chartLoader;
    public NoteLoader noteLoader;

    private void Start()
    {
        string chartData = chartLoader.GetChartData();

        if (!string.IsNullOrEmpty(chartData))
        {
            noteLoader.LoadChart(chartData);
        }
    }
}
