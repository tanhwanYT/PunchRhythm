using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightNoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0;

    [SerializeField] Transform NoteAppear = null;
    [SerializeField] GameObject GoNote = null;

    RightTimingManager RightTimingManager;

    private void Start()
    {
        RightTimingManager = GetComponent<RightTimingManager>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (GoNote != null && currentTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(GoNote, NoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            RightTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            RightTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
