using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public NoteLoader noteLoader;
    public TextAsset chartDataFile;
    public NoteSpawner noteSpawner;

    private void Start()
    {
        if (chartDataFile != null)
        {
            Debug.Log("Chart data file found.");
            string chartData = chartDataFile.text;
            noteLoader.LoadChart(chartData);
        }
        else
        {
            Debug.LogError("Chart data file is not assigned!");
        }

        noteSpawner.InitializeSpawner(noteLoader.notes, noteLoader.bpm);
    }
    
}
