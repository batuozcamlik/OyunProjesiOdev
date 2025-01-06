using System.Collections;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    public Transform minPosition; 
    public Transform maxPosition;
    public float moveSpeed = 5f; 
    public float waitTime = 2f; 

    private Vector3 targetPosition;

    public Animator anim;

    void Start()
    {
        anim=GetComponent<Animator>();
        
        SetNewTargetPosition();
        StartCoroutine(MoveToRandomPosition());
    }

    void SetNewTargetPosition()
    {
       
        float randomX = Random.Range(minPosition.position.x, maxPosition.position.x);
        float randomY = Random.Range(minPosition.position.y, maxPosition.position.y);
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
    }

    IEnumerator MoveToRandomPosition()
    {
        while (true)
        {
            
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                anim.SetBool("move", true);

                if (targetPosition.x > transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (targetPosition.x < transform.position.x)
                {   
                    GetComponent<SpriteRenderer>().flipX = false;
                }

                
                yield return null;
            }


            
            anim.SetBool("move", false);
            yield return new WaitForSeconds(Random.Range(waitTime,waitTime*2));

            
            SetNewTargetPosition();
        }
    }
}
