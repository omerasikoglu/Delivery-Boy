using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    public event Action<Vector2, float> OnTouchActionStarted; //position and start time
    public event Action<Vector2, float> OnTouchActionPerformed;
    public event Action<Vector2, float> OnTouchActionEnded;

    public event Action<Vector2, float> OnSwerveStarted;

    private TouchControlMap touchControls;

    private void Awake()
    {
        touchControls = new TouchControlMap();
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
        touchControls.Touch.Touch.started += StartTouch;
        touchControls.Touch.Touch.performed += PerformTouch; //önceki pozisyonu, bi önceki tap'ta
        touchControls.Touch.Touch.canceled += CancelTouch;

        touchControls.Touch.Swerve.started += StartSwerve;

    }


    private void StartTouch(InputAction.CallbackContext context)
    {
        if (float.IsPositiveInfinity(touchControls.Touch.Touch.ReadValue<Vector2>().x)) return;
        if (float.IsNegativeInfinity(touchControls.Touch.Touch.ReadValue<Vector2>().x)) return;

        //Debug.Log("started" + touchControls.Touch.PrimaryTouchPosition.ReadValue<Vector2>());

        OnTouchActionStarted?.Invoke(touchControls.Touch.Touch.ReadValue<Vector2>(), (float)context.startTime);
    }
    private void PerformTouch(InputAction.CallbackContext context)
    {
        if (float.IsPositiveInfinity(touchControls.Touch.Touch.ReadValue<Vector2>().x)) return;
        if (float.IsNegativeInfinity(touchControls.Touch.Touch.ReadValue<Vector2>().x)) return;

        //Debug.Log("performed" + touchControls.Touch.PrimaryTouchPosition.ReadValue<Vector2>());
        OnTouchActionPerformed?.Invoke(touchControls.Touch.Touch.ReadValue<Vector2>(), (float)context.startTime);
    }
    private void CancelTouch(InputAction.CallbackContext context)
    {
        if (float.IsPositiveInfinity(touchControls.Touch.Touch.ReadValue<Vector2>().x)) return;
        if (float.IsNegativeInfinity(touchControls.Touch.Touch.ReadValue<Vector2>().x)) return;

        //Debug.Log("ended" + touchControls.Touch.PrimaryTouchPosition.ReadValue<Vector2>());

        OnTouchActionEnded?.Invoke(touchControls.Touch.Touch.ReadValue<Vector2>(), (float)context.startTime);
    }
    private void StartSwerve(InputAction.CallbackContext context)
    {
        //Debug.Log("swerved" + touchControls.Touch.Swerve.ReadValue<Vector2>());
        OnSwerveStarted?.Invoke(touchControls.Touch.Swerve.ReadValue<Vector2>(), (float)context.startTime);
    }


}

