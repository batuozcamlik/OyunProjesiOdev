using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStateMachine : StateMachine
{
    private Character character;
    public void SetBaltaState() => ChangeState(new BaltaState());
    public void SetCapaState() => ChangeState(new CapaState());
    public void SetKazmaState() => ChangeState(new KazmaState());
    public void SetKilicState() => ChangeState(new KilicState());


    public CharacterStateMachine(Character charInstance)
    {
        character = charInstance;
        if (character == null)
        {
            Debug.Log("BOÞ");
        }
       
    }

    public override void ChangeState(State newState)
    {
        base.ChangeState(newState);
        if (character == null)
        {
            Debug.Log("BOÞ");
        }
        currentState.currentChar = character; // Yeni duruma Character nesnesini ata
    }
}