using BulletUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    PauseState pauseState;
    GameplayState gameplayState;
    IState currentState;


    void Start()
    {
        pauseState = new PauseState();
        gameplayState = new GameplayState();
        gameplayState.EnterState();
        currentState = gameplayState;
    }

    public void SwitchState()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponScript>().AddAmmo();

        if (currentState == gameplayState)
        {
            gameplayState.ExitState();
            pauseState.EnterState();
            currentState = pauseState;
        }
        else if(currentState == pauseState)
        {
            pauseState.ExitState();
            gameplayState.EnterState();
            currentState = gameplayState;
        }
    }
}
