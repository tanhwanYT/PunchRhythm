using Unity.VisualScripting;
using UnityEngine;

public class JudgeManager : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode centerKey = KeyCode.UpArrow;
    public KeyCode rightKey = KeyCode.RightArrow;

    public Transform leftLane;
    public Transform centerLane;
    public Transform rightLane;

    public GameObject hitEffectPrefab;
    public float perfectWindow = 1.0f;
    public float greatWindow = 2.0f;
    public float goodWindow = 3.0f;

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
            Debug.Log("EndPos position: " + endPos.position);
            Debug.Log("clossesNote position: " + closestNote.transform.position);

            // 노트와 끝 지점 간의 거리 계산
            float distance = Vector3.Distance(closestNote.transform.position, endPos.position);


            if(distance >= perfectWindow)
            {
                Debug.Log("Perfect! = " + distance);
                SpawnHitEffect(endPos.position, Color.yellow);
            }
            else if (distance >= greatWindow)
            {
                Debug.Log("Great! = " + distance);
                SpawnHitEffect(endPos.position, Color.green);
            }
            else if (distance >= goodWindow)
            {
                Debug.Log("Ok! = " + distance);
                SpawnHitEffect(endPos.position, Color.blue);
            }
            else
            {
                Debug.Log("Bad! = " + distance);
                SpawnHitEffect(endPos.position, Color.gray);
            }

            // 노트 제거
            Destroy(closestNote.gameObject);
        }
        else
        {
            Debug.Log("뭔가이상!");
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
            if (note != null) // 판정 가능한 상태인지 확인
            {
                // 노트와 endPos의 y 위치 차이로 거리를 계산
                float distance = Vector3.Distance(note.transform.position, endPos.position);
                Debug.Log("Distance at Key Press: " + distance);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNote = note;
                }
            }
        }
        return closestNote; // 가장 가까운 노트를 반환
    }

    private void SpawnHitEffect(Vector3 position, Color color)
    {
        if (hitEffectPrefab != null)
        {
            GameObject effect = Instantiate(hitEffectPrefab, position, Quaternion.identity);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            
            if (ps != null)
            {
                var main = ps.main;
                main.startColor = color; // 이펙트 색상 변경
            }

            Destroy(effect, 1.0f); // 1초 후 이펙트 제거
        }
        else
        {
            Debug.LogWarning("HitEffectPrefab is not assigned!");
        }
    }

}
