using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TBP.StateManagement;

public class GameManager : MonoBehaviour
{
    private StateMachine stateMachine;

    public enum StateSwitch {ToMenu, World, Pause, QuitApproved}

    public StateSwitch stateSwitch = new StateSwitch();

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Init();
        }
        else Destroy(this.gameObject);
    }

    private void Init()
    {
        var init = new _GameInit();
        var menu = new _GameMenu();
        var world = new _GameWorld();
        var pause = new _GamePause();
        var quit = new _GameQuit();

        stateMachine = new StateMachine();

        AddTransition(init, menu, ToMenu());
        AddTransition(menu, world, World());
        AddTransition(menu, quit, QuitApproved());
        AddTransition(world, pause, Pause());
        AddTransition(pause, quit, QuitApproved());
        AddTransition(pause, menu, ToMenu());

        void AddTransition(IState from, IState to, Func<bool> predicate) => stateMachine.AddTransition(from, to, predicate);

        Func<bool>ToMenu() => () => stateSwitch == StateSwitch.ToMenu;
        Func<bool>World() => () => stateSwitch == StateSwitch.World;
        Func<bool>Pause() => () => stateSwitch == StateSwitch.Pause;
        Func<bool>QuitApproved() => () => stateSwitch == StateSwitch.QuitApproved;
    }

    private void Update()
    {
        stateMachine.Tick();
    }
}
