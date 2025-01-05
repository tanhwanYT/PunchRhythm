using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode centerKey = KeyCode.UpArrow;
    public KeyCode rightKey = KeyCode.RightArrow;

    public Transform leftLane;
    public Transform centerLane;
    public Transform rightLane;

    public float perfectWindow = 0.1f;
    public float greatWindow = 0.2f;
    public float goodWindow = 0.3f;

    private void Update()
    {
        // 키 입력에 따라 해당 레인에서 판정
        if (Input.GetKeyDown(leftKey))
            JudgeLane(leftLane);
        if (Input.GetKeyDown(centerKey))
            JudgeLane(centerLane);
        if (Input.GetKeyDown(rightKey))
            JudgeLane(rightLane);
    }

    private void JudgeLane(Transform lane)
    {
        NoteMover closestNote = FindClosestNoteInLane(lane);
        if (closestNote != null)
        {
            // 레인의 끝 위치 (endPos)
            Transform endPos = lane.GetChild(0);  // 레인의 첫 번째 자식이 endPos로 가정

            // 노트와 끝 지점 간의 거리 계산
            float distance = Mathf.Abs(closestNote.transform.position.y - endPos.position.y);

            // 거리 차이에 따른 판정
            if (distance <= perfectWindow)
                Debug.Log("Perfect!");
            else if (distance <= greatWindow)
                Debug.Log("Great!");
            else if (distance <= goodWindow)
                Debug.Log("Good!");
            else
                Debug.Log("Miss!");

            // 노트 제거
            Destroy(closestNote.gameObject);
        }
    }


    private NoteMover FindClosestNoteInLane(Transform lane)
    {
        NoteMover closestNote = null;
        float closestDistance = float.MaxValue;

        // 레인의 끝 지점 (endPos)까지의 거리를 기준으로 가장 가까운 노트를 찾음
        Transform endPos = lane.GetChild(0);  // 각 레인의 endPos를 자식으로 가정

        foreach (Transform child in lane)
        {
            NoteMover note = child.GetComponent<NoteMover>();
            if (note != null && note.inJudgeZone) // 판정 가능한 상태인지 확인
            {
                // 노트와 endPos의 y 위치 차이로 거리를 계산
                float distance = Mathf.Abs(note.transform.position.y - endPos.position.y);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNote = note;
                }
            }
        }

        return closestNote; // 가장 가까운 노트를 반환
    }
}
