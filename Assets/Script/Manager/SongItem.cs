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
        Debug.Log("선택한 곡: " + songTitle.text);
        // 여기에서 노래를 재생하거나 씬을 변경하는 코드 추가 가능
    }
}
