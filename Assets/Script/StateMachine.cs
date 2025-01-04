using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class State
{
    public Character currentChar;
    public abstract void solTik();
    public abstract void sagTik();

    
   
}

public abstract class StateMachine
{
    public State currentState;

    public virtual void ChangeState(State newState) // Virtual olarak tanýmlandý
    {
        currentState = newState;
    }
}

public class BaltaState : State
{
    public override void solTik()
    {
        Debug.Log("AgacKes");
        if(base.currentChar == null)
        {
            Debug.Log("Char yok !");
            return;
        }
        base.currentChar.damage = 10;
    }

    public override void sagTik()
    {
        Debug.Log("AgacKes2");
    }
}

public class CapaState : State
{
    public override void solTik()
    {
        Debug.Log("Ek");
        if (base.currentChar == null)
        {
            Debug.Log("Char yok !");
            return;
        }
        base.currentChar.damage = 5;
    }

    public override void sagTik()
    {
        Debug.Log("Ek2");
    }
}

public class KazmaState : State
{
    public override void solTik()
    {
        Debug.Log("Kazma");
        if (base.currentChar == null)
        {
            Debug.Log("Char yok !");
            return;
        }
        base.currentChar.damage = 15;
    }

    public override void sagTik()
    {
        Debug.Log("Kazma2");
    }
}

public class KilicState : State
{
    public override void solTik()
    {
        Debug.Log("Kilic");
        if (base.currentChar == null)
        {
            Debug.Log("Char yok !");
            return;
        }
        base.currentChar.damage = 50;
    }

    public override void sagTik()
    {
        Debug.Log("Kilic2");
    }
}
