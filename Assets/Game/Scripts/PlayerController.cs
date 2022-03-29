using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Foldout("[Input]")] private InputManager inputManager;
    [SerializeField] private Camera cam;


    public Vector3 goCoord;
    public Vector3 worldOffsetPos;

    private void Awake()
    {
        inputManager.OnTouchActionStarted += InputManagerOnTouchActionStarted;
        inputManager.OnTouchActionEnded += InputManagerOnTouchActionEnded;
        inputManager.OnTouchActionPerformed += InputManagerOnTouchActionPerformed;

        inputManager.OnSwervePerformed += InputManagerOnSwervePerformed;
    }

    private void InputManagerOnSwervePerformed(Vector2 swerveOffset)
    {
        //coord:ekranda, pos:dünyada

        var goWorldPosition = gameObject.transform.position;

        goCoord = UtilsClass.GetWorldToScreenPoint(goWorldPosition); //Z'si 10 ekranda 

        worldOffsetPos = UtilsClass.GetScreenToWorldPoint(goCoord + (Vector3)swerveOffset); //offsette z deðiþmez

        transform.position = worldOffsetPos;

    }

    private void InputManagerOnTouchActionStarted(Vector2 arg1)
    {
        //Move(swerveOffset);
    }
    private void InputManagerOnTouchActionPerformed(Vector2 obj)
    {
        //Move(obj);
    }

    private void InputManagerOnTouchActionEnded(Vector2 arg1)
    {
        //Move(swerveOffset);
    }

    public void Move(Vector2 screenPosition)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cam.nearClipPlane);
        Vector3 worldCoordinates = cam.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0f;
        //position = worldCoordinates;
        transform.position = worldCoordinates;

    }
}
