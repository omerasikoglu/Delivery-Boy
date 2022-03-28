using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Foldout("[Input]")] private PlayerInput playerInput;

    private void Awake()
    {
        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
