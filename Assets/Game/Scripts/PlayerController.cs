using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField, Foldout("[Input]")] private PlayerInput playerInput;
    [SerializeField, Foldout("[Input]")] private InputManager inputManager;
    [SerializeField] private Camera cam;


    public Vector3 swerveInputScreenOffsetCoord;
    public Vector3 goScreenCoord;
    public Vector3 goNextPosCoord;
    public Vector3 worldOffsetCoord;
    public float screenPosZ;

    private void Awake()
    {
        //playerýnput.onactiontriggered += playerýnput_onactiontriggered;
        //inputmanager.onstarttouchaction += move;
        //inputmanager.onendtouchaction += move;

        inputManager.OnTouchActionStarted += InputManagerOnTouchActionStarted;
        inputManager.OnTouchActionEnded += InputManagerOnTouchActionEnded;
        inputManager.OnTouchActionPerformed += InputManagerOnTouchActionPerformed;

        inputManager.OnSwervePerformed += InputManagerOnSwervePerformed;
    }

    private void InputManagerOnSwervePerformed(Vector2 screenOffset)
    {
        var goPosition = gameObject.transform.position;
        screenPosZ = UtilsClass.GetWorldToScreenPoint(goPosition).z;

        //Debug.Log("screenOffset" + screenOffset.x + " | " + screenOffset.y);
        swerveInputScreenOffsetCoord = new Vector3(screenOffset.x, screenOffset.y, screenPosZ);

        goScreenCoord = cam.WorldToScreenPoint(goPosition);
        //goScreenCoord.z = screenPosZ;

        goNextPosCoord = goScreenCoord + swerveInputScreenOffsetCoord;
        //goNextPosCoord = new Vector3(goScreenCoord.x + swerveInputScreenOffsetCoord.x,
        //    goScreenCoord.y + swerveInputScreenOffsetCoord.y);

        worldOffsetCoord = cam.ScreenToWorldPoint(goNextPosCoord);
        worldOffsetCoord.z = screenPosZ;

        transform.position = worldOffsetCoord;
        //Debug.Log(cam.ScreenToWorldPoint(swerveInputScreenOffsetCoord));

    }

    private void InputManagerOnTouchActionStarted(Vector2 arg1)
    {
        //Move(screenOffset);
    }
    private void InputManagerOnTouchActionPerformed(Vector2 obj)
    {
        //Move(obj);
    }

    private void InputManagerOnTouchActionEnded(Vector2 arg1)
    {
        //Move(screenOffset);
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
