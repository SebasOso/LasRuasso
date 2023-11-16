using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBallState : PlayerBaseState
{
    private readonly int FireBallHash = Animator.StringToHash("FireBall");
    private readonly int LocomotionSpeed = Animator.StringToHash("speed");
    private const float CrossFadeDuration = 0.1f;
    private float duration = 5f;
    public PlayerFireBallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FireBallHash, CrossFadeDuration);
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
            stateMachine.IsFireBall = false;
        }
    }
}
