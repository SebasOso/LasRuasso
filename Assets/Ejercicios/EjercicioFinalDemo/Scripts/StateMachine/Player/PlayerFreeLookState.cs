using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookSpeedHash = Animator.StringToHash("speed");
    private readonly int FreeLookBlendTree = Animator.StringToHash("LocomotionBT");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FreeLookBlendTree, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        if(stateMachine.IsTornado)
        {
            stateMachine.SwitchState(new PlayerTornadoState(stateMachine));
        }
        if(stateMachine.IsWaterLaser)
        {
            stateMachine.SwitchState(new PlayerWaterLaserState(stateMachine));
        }
    }

    public override void Exit()
    {

    }
}
