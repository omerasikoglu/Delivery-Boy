using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public event Action<Vector2, float> OnStartTouchAction; //position and start time
    public event Action<Vector2, float> OnEndTouchAction;

    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        Observer();
    }

    private void Observer()
    {
        //touchControls.Touch.PrimaryTouchContact.started += ctx => StartTouch(ctx);
        touchControls.Touch.PrimaryTouchContact.started += StartTouch;
        touchControls.Touch.PrimaryTouchContact.canceled += EndTouch;
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("started" + touchControls.Touch.PrimaryTouchPosition.ReadValue<Vector2>());

        OnStartTouchAction?.Invoke(touchControls.Touch.PrimaryTouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("ended");

        OnEndTouchAction?.Invoke(touchControls.Touch.PrimaryTouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

}
