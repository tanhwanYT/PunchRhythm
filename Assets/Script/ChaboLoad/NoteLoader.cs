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
    public float bpm = 120f; // 기본 BPM 값 (BPM 데이터가 없을 경우 사용)

    public void LoadChart(string chartData)
    {
        string[] lines = chartData.Split('\n');

        foreach (string line in lines)
        {
            Debug.Log($"Processing line: {line.Trim()}"); // 현재 처리 중인 줄을 출력

            string[] parts = line.Split('\t');

            // BPM 데이터 확인 및 로드
            if (line.StartsWith("BPM") && parts.Length >= 3)
            {
                if (float.TryParse(parts[2], out float parsedBPM))
                {
                    bpm = parsedBPM;
                    Debug.Log($"BPM Loaded: {bpm}");
                }
                continue; // BPM 데이터는 노트 리스트에 추가하지 않음
            }

            // 노트 데이터 확인 및 로드
            if (line.StartsWith("t") && parts.Length >= 8) // 최소한 필요한 데이터가 있는지 확인
            {
                try
                {
                    Note note = new Note
                    {
                        time = float.Parse(parts[4]) / 1000.0f,
                        lane = int.Parse(parts[5]),
                        totalLanes = int.Parse(parts[6]),
                        type = int.Parse(parts[7])
                    };
                    notes.Add(note);

                    Debug.Log($"Note added: time={note.time}, lane={note.lane}, totalLanes={note.totalLanes}, type={note.type}");
                }
                catch (System.Exception ex)
                {
                    Debug.LogError($"Failed to parse line: {line}. Error: {ex.Message}");
                }
            }
            else if (line.StartsWith("t"))
            {
                Debug.LogWarning($"Invalid note format: {line}");
            }
        }

        Debug.Log($"Total notes loaded: {notes.Count}, BPM: {bpm}");
    }
}
