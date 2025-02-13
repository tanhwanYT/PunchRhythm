using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongItem : MonoBehaviour
{
    public TextMeshProUGUI songTitle;
    public Image albumArt;
    private string songPath;

    public void SetSongData(string title, Sprite album, string path)
    {
        songTitle.text = title;
        albumArt.sprite = album;
        songPath = path;
    }

    public void OnClickSelectSong()
    {
        Debug.Log("������ ��: " + songTitle.text);
        // ���⿡�� �뷡�� ����ϰų� ���� �����ϴ� �ڵ� �߰� ����
    }
}
