using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Rigidbody2D rb; 
    public Vector2 movement;

    public Animator anim;
    public GameObject trigger;

    public bool canMove = true;

    private void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {
       
        if(canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Vector2.zero;
        }
      

        if(movement != Vector2.zero)
        {
            anim.SetFloat("X", movement.x);
            anim.SetFloat("Y", movement.y);
            flipCheck();
            anim.SetBool("isWalk", true);
            checkTriggerPos();
        }
        else
        {
            anim.SetBool("isWalk", false);

        }





        movement = movement.normalized;
    }

    public void checkTriggerPos()
    {
        if (movement == new Vector2(0, 1))
        {
            trigger.transform.localPosition = new Vector2(0, 0.5f);
        }
        else if (movement == new Vector2(0, -1))
        {
            Debug.Log("Alt");
            trigger.transform.localPosition = new Vector2(0, -0.5f);
        }
        else if (movement == new Vector2(1, 0))
        {
            Debug.Log("Sað");
            trigger.transform.localPosition = new Vector2(0.5f, 0);
        }
        else if (movement == new Vector2(-1, 0))
        {
            Debug.Log("Sol");
            trigger.transform.localPosition = new Vector2(-0.5f, 0);

        }
    }
    public void flipCheck()
    {
        if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void FixedUpdate()
    {
        
        rb.velocity = movement * moveSpeed;
    }
}
