using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SongSelectSceneManage : MonoBehaviour
{
    public RectTransform content; // �뷡 ��� �г� (�̵��� ���)
    public GameObject songItemPrefab; // ���� �� ������
    public float moveStep = 150f; // �� �� �̵��� �Ÿ�
    public float smoothTime = 0.2f; // �̵� �ε巯�� ����

    private float targetY; // ��ǥ ��ġ
    private float velocity = 0f; // Lerp ���� �ӵ�

    [System.Serializable]
    public class SongData
    {
        public string title;
        public Sprite albumArt;
        public string filePath;
    }

    public List<SongData> songList = new List<SongData>(); // �� ���

    void Start()
    {
        LoadSongs();
        targetY = content.anchoredPosition.y; // �ʱ� ��ġ ����
    }

    void Update()
    {
        // Up/Down Ű�� �̵�
        if (Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
        if (Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();

        // �ε巯�� �̵� (Lerp ���)
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
        targetY -= moveStep; // ���� �̵�
    }

    public void MoveDown()
    {
        targetY += moveStep; // �Ʒ��� �̵�
    }
}
