using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab; 
    public Transform[] lanes; 
    public NoteLoader noteLoader;
    public float scrollSpeed = 5f;

    private void Start()
    {
        foreach (var note in noteLoader.notes)
        {
            SpawnNote(note);
        }
    }

    private void SpawnNote(NoteLoader.Note note)
    {
        Transform laneTransform = lanes[note.lane]; 
        GameObject noteObject = Instantiate(notePrefab, laneTransform);
        float spawnY = note.time * scrollSpeed; 
        noteObject.transform.localPosition = new Vector3(0, spawnY, 0.5f);
    }
}
