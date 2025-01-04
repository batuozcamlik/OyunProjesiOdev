using System.Collections;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    public Transform minPosition; // Minimum pozisyon
    public Transform maxPosition; // Maksimum pozisyon
    public float moveSpeed = 5f; // Hareket h�z�
    public float waitTime = 2f; // Bekleme s�resi

    private Vector3 targetPosition;

    void Start()
    {
        // �lk hedef pozisyonu belirle
        SetNewTargetPosition();
        StartCoroutine(MoveToRandomPosition());
    }

    void SetNewTargetPosition()
    {
        // Rastgele bir hedef pozisyon se�
        float randomX = Random.Range(minPosition.position.x, maxPosition.position.x);
        float randomY = Random.Range(minPosition.position.y, maxPosition.position.y);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    IEnumerator MoveToRandomPosition()
    {
        while (true)
        {
            // Hedef pozisyona do�ru hareket et
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Hedefe ula�t�ktan sonra bekle
            yield return new WaitForSeconds(Random.Range(waitTime,waitTime*2));

            // Yeni bir hedef belirle
            SetNewTargetPosition();
        }
    }
}
