using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notemanager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0;

    [SerializeField] Transform NoteAppear = null;
    [SerializeField] GameObject GoNote = null;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(GoNote != null && currentTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(GoNote, NoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            currentTime -= 60d / bpm;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
        }
    }
}
