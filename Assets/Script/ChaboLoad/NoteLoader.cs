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
            Debug.Log($"Processing line: {line}"); // ���� ó�� ���� ���� ���

            if (line.StartsWith("t")) // ��Ʈ ���������� Ȯ��
            {
                Debug.Log($"Line is a note: {line}");

                string[] parts = line.Split('\t');
                if (parts.Length >= 8) // �ּ��� �ʿ��� �����Ͱ� �ִ��� Ȯ��
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
                else
                {
                    Debug.LogWarning($"Line does not contain enough parts: {line}");
                }
            }
        }

        Debug.Log($"Total notes loaded: {notes.Count}");
    }

}
