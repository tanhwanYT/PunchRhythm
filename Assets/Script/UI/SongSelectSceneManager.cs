using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SongSelectSceneManage : MonoBehaviour
{
    public RectTransform content; // 노래 목록 패널 (이동할 대상)
    public GameObject songItemPrefab; // 개별 곡 프리팹
    public float moveStep = 150f; // 한 번 이동할 거리
    public float smoothTime = 0.2f; // 이동 부드러움 조정

    private float targetY; // 목표 위치
    private float velocity = 0f; // Lerp 보간 속도

    [System.Serializable]
    public class SongData
    {
        public string title;
        public Sprite albumArt;
        public string filePath;
    }

    public List<SongData> songList = new List<SongData>(); // 곡 목록

    void Start()
    {
        LoadSongs();
        targetY = content.anchoredPosition.y; // 초기 위치 저장
    }

    void Update()
    {
        // Up/Down 키로 이동
        if (Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();

        // 부드러운 이동 (Lerp 사용)
        float newY = Mathf.SmoothDamp(content.anchoredPosition.y, targetY, ref velocity, smoothTime);
        content.anchoredPosition = new Vector2(content.anchoredPosition.x, newY);
    }

    void LoadSongs()
    {
        foreach (var song in songList)
        {
            GameObject songItemObj = Instantiate(songItemPrefab, content);
            SongItem songItem = songItemObj.GetComponent<SongItem>();
            songItem.SetSongData(song.title, song.albumArt, song.filePath);
        }
    }

    public void MoveUp()
    {
        targetY -= moveStep; // 위로 이동
    }

    public void MoveDown()
    {
        targetY += moveStep; // 아래로 이동
    }
}
