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
        // Ű �Է¿� ���� �ش� ���ο��� ����
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
            // ������ �� ��ġ (endPos)
            Transform endPos = lane.GetChild(0);  // ������ ù ��° �ڽ��� endPos�� ����

            // ��Ʈ�� �� ���� ���� �Ÿ� ���
            float distance = Mathf.Abs(closestNote.transform.position.y - endPos.position.y);

            // �Ÿ� ���̿� ���� ����
            if (distance <= perfectWindow)
                Debug.Log("Perfect!");
            else if (distance <= greatWindow)
                Debug.Log("Great!");
            else if (distance <= goodWindow)
                Debug.Log("Good!");
            else
                Debug.Log("Miss!");

            // ��Ʈ ����
            Destroy(closestNote.gameObject);
        }
    }


    private NoteMover FindClosestNoteInLane(Transform lane)
    {
        NoteMover closestNote = null;
        float closestDistance = float.MaxValue;

        // ������ �� ���� (endPos)������ �Ÿ��� �������� ���� ����� ��Ʈ�� ã��
        Transform endPos = lane.GetChild(0);  // �� ������ endPos�� �ڽ����� ����

        foreach (Transform child in lane)
        {
            NoteMover note = child.GetComponent<NoteMover>();
            if (note != null && note.inJudgeZone) // ���� ������ �������� Ȯ��
            {
                // ��Ʈ�� endPos�� y ��ġ ���̷� �Ÿ��� ���
                float distance = Mathf.Abs(note.transform.position.y - endPos.position.y);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNote = note;
                }
            }
        }

        return closestNote; // ���� ����� ��Ʈ�� ��ȯ
    }
}
