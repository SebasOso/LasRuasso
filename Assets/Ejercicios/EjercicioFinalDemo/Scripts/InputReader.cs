using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public event Action Tornado;
    public bool IsCasting{get; set;}
    private Controls controls;
    private void Start() 
    {
        if(controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);

            controls.Player.Enable();
        }
    }
    private void Update() 
    {
            
    }
    private void OnDestroy() 
    {
        controls.Player.Disable();
    }
    public void Disable()
    {
        controls.Player.Disable();
    }
    public void OnTornado(InputAction.CallbackContext context)
    {
        if(IsCasting){return;}
        if(context.performed)
        {
            Tornado.Invoke();
            IsCasting = true;
        }
    }
}
