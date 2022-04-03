using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Foldout("[Input]")] private InputManager inputManager;
    [SerializeField, Foldout("[Input]")] private bool isVerticalSwerveActive, isHorizontalSwerveActive;

    [SerializeField] private Vector3 goCoord, worldOffsetPos;
    [SerializeField] private bool isTouchingObject;

    private void Awake()
    {
        inputManager.OnSwervePerformed += OnSwervePerformed;
        inputManager.OnTouchPerformed += OnTouchPerformed;
        inputManager.OnTouchEnded += OnTouchEnded;
    }

    private void OnTouchEnded()
    {
        isTouchingObject = false;
    }

    private void OnTouchPerformed(Vector2 coord)
    {
        isTouchingObject = true;
    }

    private void OnSwervePerformed(Vector2 swerveOffset)
    {
        if (!isTouchingObject) return;
        //coord:ekranda, pos:d�nyada, offsette z de�i�mez

        Vector3 goWorldPosition = gameObject.transform.position;

        goCoord = UtilsClass.GetWorldToScreenPoint(goWorldPosition); //Z'si 10 ekranda 
        worldOffsetPos = UtilsClass.GetScreenToWorldPoint(goCoord + (Vector3)swerveOffset);

        if (isVerticalSwerveActive) VerticalSwerve();
        if (isHorizontalSwerveActive) HorizontalSwerve();
    }

    private void VerticalSwerve()
    {
        transform.position = new Vector3(transform.position.x, worldOffsetPos.y, transform.position.z);
    }
    private void HorizontalSwerve()
    {
        transform.position = new Vector3(worldOffsetPos.x, transform.position.y, transform.position.z);
    }
}
