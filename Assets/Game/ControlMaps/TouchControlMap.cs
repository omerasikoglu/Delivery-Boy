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
                    ""name"": ""Touch"",
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
                    ""action"": ""Touch"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Touch = m_Touch.FindAction("Touch", throwIfNotFound: true);
        m_Touch_Swerve = m_Touch.FindAction("Swerve", throwIfNotFound: true);
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
    private readonly InputAction m_Touch_Touch;
    private readonly InputAction m_Touch_Swerve;
    public struct TouchActions
    {
        private @TouchControlMap m_Wrapper;
        public TouchActions(@TouchControlMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_Touch_Touch;
        public InputAction @Swerve => m_Wrapper.m_Touch_Swerve;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouch;
                @Swerve.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSwerve;
                @Swerve.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSwerve;
                @Swerve.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSwerve;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @Swerve.started += instance.OnSwerve;
                @Swerve.performed += instance.OnSwerve;
                @Swerve.canceled += instance.OnSwerve;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnSwerve(InputAction.CallbackContext context);
    }
}
