using System.Collections.Generic;
using UnityEngine;

public class NoteLoader : MonoBehaviour
{
    [System.Serializable]
    public class Note
    {
        public float time;
        public int lane;
        public int totalLanes;
        public int type;
    }

    public List<Note> notes = new List<Note>();

    public void LoadChart(string chartData)
    {
        string[] lines = chartData.Split('\n');
        foreach (string line in lines)
        {
            if (line.StartsWith("t")) // 노트 데이터인지 확인
            {
                string[] parts = line.Split('\t');
                Note note = new Note
                {
                    time = float.Parse(parts[4]) / 1000.0f,
                    lane = int.Parse(parts[5]),
                    totalLanes = int.Parse(parts[6]),
                    type = int.Parse(parts[7])
                };
                notes.Add(note);
            }
        }
    }
}
