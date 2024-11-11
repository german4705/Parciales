using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine 
{
    State curreState;

    Dictionary<EnemyState, State> allsStates = new Dictionary<EnemyState, State>(); //lista d estados

    public void AddState(EnemyState name, State state)
    {
        if (!allsStates.ContainsKey(name))
        {
            allsStates.Add(name, state);
            state.fsm = this;
        }
        else
        {
            allsStates[name] = state;
        }
    }

    public void ChangeState(EnemyState name)
    {
        curreState?.OnExit();// si es nulo no lo llama 
        if (allsStates.ContainsKey(name)) curreState = allsStates[name]; // si la lista contiene ese estado,ahora es el estado actual
        curreState?.OnEnter();
    }

    public void Update() //artificialupdate llamando al estado
    {
        curreState?.OnUpdate();
    }
}

public enum EnemyState
{
   Patrol, PathFinding, Follow , BackToPatrol

}
