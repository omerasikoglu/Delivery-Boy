using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    public event Action<Vector2> OnTouchActionStarted; //position
    public event Action<Vector2> OnTouchActionPerformed;
    public event Action<Vector2> OnTouchActionEnded;

    public event Action<Vector2> OnSwervePerformed; //swerve amount

    private TouchControlMap touchControlMap;

    private void Awake()
    {
        touchControlMap = new TouchControlMap();
    }

    private void OnEnable() => touchControlMap.Enable();
    private void OnDisable() => touchControlMap.Disable();
    private void Start()
    {
        Observer();
    }

    private void Observer()
    {
        //touchControlMap.Touch.PrimaryTouchContact.started += ctx => StartTouch(ctx);
        touchControlMap.Touch.Touch.started += StartTouch;
        touchControlMap.Touch.Touch.performed += PerformTouch; //önceki pozisyonu, bi önceki tap'ta
        touchControlMap.Touch.Touch.canceled += CancelTouch;

        touchControlMap.Touch.Swerve.performed += PerformSwerve;

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if (float.IsPositiveInfinity(touchControlMap.Touch.Touch.ReadValue<Vector2>().x)) return;
        if (float.IsNegativeInfinity(touchControlMap.Touch.Touch.ReadValue<Vector2>().x)) return;

        OnTouchActionStarted?.Invoke(touchControlMap.Touch.Touch.ReadValue<Vector2>());
    }
    private void PerformTouch(InputAction.CallbackContext context)
    {
        if (float.IsPositiveInfinity(touchControlMap.Touch.Touch.ReadValue<Vector2>().x)) return;
        if (float.IsNegativeInfinity(touchControlMap.Touch.Touch.ReadValue<Vector2>().x)) return;

        OnTouchActionPerformed?.Invoke(touchControlMap.Touch.Touch.ReadValue<Vector2>());
    }
    private void CancelTouch(InputAction.CallbackContext context)
    {
        if (float.IsPositiveInfinity(touchControlMap.Touch.Touch.ReadValue<Vector2>().x)) return;
        if (float.IsNegativeInfinity(touchControlMap.Touch.Touch.ReadValue<Vector2>().x)) return;

        OnTouchActionEnded?.Invoke(touchControlMap.Touch.Touch.ReadValue<Vector2>());
    }
    private void PerformSwerve(InputAction.CallbackContext context)
    {
        //Debug.Log("swerved" + touchControlMap.Touch.Swerve.ReadValue<Vector2>());
        if (float.IsPositiveInfinity(touchControlMap.Touch.Swerve.ReadValue<Vector2>().x)) return;
        if (float.IsNegativeInfinity(touchControlMap.Touch.Swerve.ReadValue<Vector2>().x)) return;

        OnSwervePerformed?.Invoke(touchControlMap.Touch.Swerve.ReadValue<Vector2>()/*, (float)context.startTime*/);
    }


}

