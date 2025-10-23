using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;
using EBAC.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new GMSteateIntro());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new StateBase());
        stateMachine.RegisterStates(GameStates.PAUSE, new StateBase());
        stateMachine.RegisterStates(GameStates.WIN, new StateBase());
        stateMachine.RegisterStates(GameStates.LOSE, new StateBase());

        stateMachine.Switchstate(GameStates.INTRO);
    }
    
}
