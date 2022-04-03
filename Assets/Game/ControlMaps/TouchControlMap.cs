//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Game/ControlMaps/TouchControlMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @TouchControlMap : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControlMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControlMap"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""d1669231-1195-41d8-b874-207abe226d37"",
            ""actions"": [
                {
                    ""name"": ""TouchPos"",
                    ""type"": ""PassThrough"",
                    ""id"": ""09509a72-138b-4e20-ad94-91b7a9ab7545"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Swerve"",
                    ""type"": ""Value"",
                    ""id"": ""304b7929-9c60-4393-84a7-39a75e5c703a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""IsTouching"",
                    ""type"": ""Button"",
                    ""id"": ""14cd3ef2-854d-4b66-a7a6-6334304088ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""963a2517-110c-4f65-af76-476cedab760f"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc45a627-39a1-401a-a400-126dec27a23a"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swerve"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b31595c-3067-4579-a2a1-a3ab50ed1455"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IsTouching"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_TouchPos = m_Touch.FindAction("TouchPos", throwIfNotFound: true);
        m_Touch_Swerve = m_Touch.FindAction("Swerve", throwIfNotFound: true);
        m_Touch_IsTouching = m_Touch.FindAction("IsTouching", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_TouchPos;
    private readonly InputAction m_Touch_Swerve;
    private readonly InputAction m_Touch_IsTouching;
    public struct TouchActions
    {
        private @TouchControlMap m_Wrapper;
        public TouchActions(@TouchControlMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPos => m_Wrapper.m_Touch_TouchPos;
        public InputAction @Swerve => m_Wrapper.m_Touch_Swerve;
        public InputAction @IsTouching => m_Wrapper.m_Touch_IsTouching;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @TouchPos.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPos;
                @TouchPos.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPos;
                @TouchPos.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPos;
                @Swerve.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSwerve;
                @Swerve.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSwerve;
                @Swerve.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSwerve;
                @IsTouching.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnIsTouching;
                @IsTouching.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnIsTouching;
                @IsTouching.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnIsTouching;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPos.started += instance.OnTouchPos;
                @TouchPos.performed += instance.OnTouchPos;
                @TouchPos.canceled += instance.OnTouchPos;
                @Swerve.started += instance.OnSwerve;
                @Swerve.performed += instance.OnSwerve;
                @Swerve.canceled += instance.OnSwerve;
                @IsTouching.started += instance.OnIsTouching;
                @IsTouching.performed += instance.OnIsTouching;
                @IsTouching.canceled += instance.OnIsTouching;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnTouchPos(InputAction.CallbackContext context);
        void OnSwerve(InputAction.CallbackContext context);
        void OnIsTouching(InputAction.CallbackContext context);
    }
}
