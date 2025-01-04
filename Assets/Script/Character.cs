using System.Collections;
using System.Collections.Generic;
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

    
    private void Start()
    {
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
            if (counter < 0) // E�er 0'�n alt�na d��erse 4'e d�n
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

            foreach (var point in checkPoints)
            {
                // Belirtilen noktada bir �ember kontrol� yap
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
                }
                
            }
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
                Debug.LogWarning("Ge�ersiz durum!");
                break;
        }


    }

    public void checkAnim()
    {

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
