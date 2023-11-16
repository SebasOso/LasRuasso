using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterLaserState : PlayerBaseState
{
    private readonly int WaterLaserHash = Animator.StringToHash("WaterLaser");
    private readonly int LocomotionSpeed = Animator.StringToHash("speed");
    private const float CrossFadeDuration = 0.1f;
    private float duration = 1f;
    public PlayerWaterLaserState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(WaterLaserHash, CrossFadeDuration);
    }

    public override void Exit()
    {

    }

    public override void Tick(float deltaTime)
    {
        duration -= deltaTime;
        if(duration <= 0f)
        {
            ReturnToLocomotion();
            stateMachine.IsWaterLaser = false;
        }
    }
}
