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

    private void Awake()
    {
        //playerýnput.onactiontriggered += playerýnput_onactiontriggered;
        //inputmanager.onstarttouchaction += move;
        //inputmanager.onendtouchaction += move;

        inputManager.OnTouchActionStarted += InputManagerOnTouchActionStarted;
        inputManager.OnTouchActionEnded += InputManagerOnTouchActionEnded;
        inputManager.OnTouchActionPerformed += InputManagerOnTouchActionPerformed;

        inputManager.OnSwerveStarted += InputManagerOnSwerveStarted;
    }

    private void InputManagerOnSwerveStarted(Vector2 arg1, float arg2)
    {
        Debug.Log("swerve2");
        Move(arg1);
    }


    private void InputManagerOnTouchActionStarted(Vector2 arg1, float arg2)
    {
        Move(arg1, arg2);
    }
    private void InputManagerOnTouchActionPerformed(Vector2 obj,float f)
    {
        //Move(obj);
    }

    private void InputManagerOnTouchActionEnded(Vector2 arg1, float arg2)
    {
        //Move(arg1, arg2);
    }

    //private void InputManagerOnTouchActionStarted(Vector2 arg1, float arg2)
    // {
    //     throw new NotImplementedException();
    // }
    // private void InputManagerOnTouchActionEnded(Vector2 arg1, float arg2)
    // {
    //     throw new NotImplementedException();
    // }
    // private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    // {
    //     throw new NotImplementedException();
    // }
    //private void OnEnable()
    //{
    //    inputManager.OnTouchActionStarted += Move;
    //}
    //private void OnDisable()
    //{
    //    inputManager.OnTouchActionEnded -= Move;
    //}
    public void Move(Vector2 screenPosition, float time = 0f)
    {
        //var position = gameObject.transform.position;
        //float screenPosZ = UtilsClass.GetWorldToScreenPoint(position).z;

        //Debug.Log(screenPosition);

        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cam.nearClipPlane);
        Vector3 worldCoordinates = cam.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0f;
        //position = worldCoordinates;
        transform.position = worldCoordinates;
    }
}
