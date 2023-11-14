using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] 
    public bool IsTornado {get;  set;}
    [field: SerializeField]
    public InputReader InputReader {get; private set;}
    [field: SerializeField]
    public Animator Animator {get; private set;}

    private void Awake() 
    {
        SwitchState(new PlayerFreeLookState(this));    
    }

}
