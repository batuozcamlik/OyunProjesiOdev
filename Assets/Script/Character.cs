using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public enum hand
{
    balta,
    kazma,
    capa,
    kilic
}
public class Character : MonoBehaviour
{
    private CharacterStateMachine stateMachine;

    private int counter = 0;
    public hand currentHand;

    public int damage;

    public int agacHasar;
    public int enemyHasar;
    public int tasHasar;


    public Transform[] checkPoints; 
    public float checkRadius = 1f; 
    public LayerMask targetLayer;

    public Animator anim;
    public GameObject currentHit;
    public TopDownCharacterController charController;
    private void Start()
    {
        anim = GetComponent<Animator>();
        stateMachine = new CharacterStateMachine(this);
        checkState();

     
    }

    private void Update()
    {
        #region Fare Hareketi
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            counter++;
            if (counter > 3) 
            {
                counter = 0;
            }
            Debug.Log("Counter: " + counter);
            checkState();

        }

       
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            counter--;
            if (counter < 0) // Eðer 0'ýn altýna düþerse 4'e dön
            {
                counter = 3;
            }
            Debug.Log("Counter: " + counter);
            checkState();
        }
        #endregion

        if (Input.GetMouseButtonDown(0))
        {
            stateMachine.currentState.solTik();

        }
        if (Input.GetMouseButtonDown(0))
        {
            checkAnim();
            charController.canMove = false;
            foreach (var point in checkPoints)
            {
                // Belirtilen noktada bir çember kontrolü yap
                Collider2D hit = Physics2D.OverlapCircle(point.position, checkRadius, targetLayer);

                if (hit != null)
                {
                    if(hit.gameObject.tag=="Agac")
                    {
                        damage = agacHasar;
                    }
                    else if(hit.gameObject.tag=="Tas")
                    {
                        damage = tasHasar;
                    }
                    else if( hit.gameObject.tag=="Enemy")
                    {
                        damage = enemyHasar;
                    }
                    currentHit = hit.gameObject;
                }
                
            }
        }


    }
    public void hasar()
    {
        charController.canMove = true;
        if(currentHit != null)
        {
            currentHit.gameObject.GetComponent<GetDamage>().getDamage(damage);
        }

    }
    public void checkState()
    {
        switch (counter)
        {
            case 0:
                stateMachine.SetBaltaState();
                currentHand = hand.balta;
                break;
            case 1:
                stateMachine.SetKazmaState();
                currentHand=hand.kazma;
                break;
            case 2:
                stateMachine.SetCapaState();
                currentHand=hand.capa;
                break;
            case 3:
                stateMachine.SetKilicState();
                currentHand=hand.kilic;
                break;
            default:
                Debug.LogWarning("Geçersiz durum!");
                break;
        }


    }

    public void checkAnim()
    {
        switch (currentHand)
        {
            case hand.balta:

                anim.SetTrigger("Balta");
                
                break;
            case hand.kazma:

                anim.SetTrigger("Kazma");
                break;
            case hand.capa:

                anim.SetTrigger("Capa");
                break;
            case hand.kilic:

                anim.SetTrigger("Kilic");
                break;
            default:
                Debug.LogWarning("Geçersiz durum!");
                break;
        }
    }
    void OnDrawGizmos()
    {
        
        if (checkPoints != null)
        {
            Gizmos.color = Color.red;
            foreach (var point in checkPoints)
            {
                Gizmos.DrawWireSphere(point.position, checkRadius);
            }
        }
    }
}
