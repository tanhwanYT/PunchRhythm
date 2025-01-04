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

        foreach (var note in noteLoader.notes)
        {
            StartCoroutine(SpawnNoteWithDelay(note));
        }
    }
    
    private IEnumerator SpawnNoteWithDelay(NoteLoader.Note note)
    {
        yield return new WaitForSeconds(note.time); // 노트 시간에 맞게 대기
        noteSpawner.SpawnNote(note.lane, note.time);
    }
}
