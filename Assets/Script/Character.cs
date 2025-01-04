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
    private void Start()
    {
        stateMachine = new CharacterStateMachine(this);
        checkState();

        //stateMachine.SetIdleState();
    }

    private void Update()
    {
        // Fare tekerleði yukarý hareketi
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            counter++;
            if (counter > 3) // Eðer 4'ü geçerse 0'a dön
            {
                counter = 0;
            }
            Debug.Log("Counter: " + counter);
            checkState();

        }

        // Fare tekerleði aþaðý hareketi
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

        if(Input.GetMouseButtonDown(0))
        {
            stateMachine.currentState.solTik();
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
}
