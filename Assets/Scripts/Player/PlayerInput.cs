// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Assets.Scripts.Player
{
    public class @PlayerInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""f86616ad-8761-4093-86c7-427fb01c58b8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""752b69a0-e147-4efc-ad75-9a17127c4dc2"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton"",
                    ""type"": ""Button"",
                    ""id"": ""a450e557-76fc-479a-b049-522b46ae8641"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""f6e1002a-236c-4aa1-8bbf-f5d10da040df"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""350bd277-db07-488e-a52e-f5442673c1a0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84c7e6ab-27e8-4023-9c89-9c87322d8627"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""de4aced8-0b4f-4dfb-b9c1-ca5e0ec5b6c8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10342257-97cc-4a33-b77e-d21d21b24f04"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1b1e8604-6a2d-4de9-847a-7a57978e8b13"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""346268b6-9408-4796-8370-7dd632b1f860"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2df44631-f94d-499b-ac91-766b728e61ed"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d98ec70a-59d7-41da-b51c-563163c4a4a6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7926a510-e57f-4d54-8cc5-b4b3ec035bcf"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b365d9f1-6dde-4ecf-875e-e67b4636ffc7"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerControls
            m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
            m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
            m_PlayerControls_ActionButton = m_PlayerControls.FindAction("ActionButton", throwIfNotFound: true);
            m_PlayerControls_Sprint = m_PlayerControls.FindAction("Sprint", throwIfNotFound: true);
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

        // PlayerControls
        private readonly InputActionMap m_PlayerControls;
        private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
        private readonly InputAction m_PlayerControls_Move;
        private readonly InputAction m_PlayerControls_ActionButton;
        private readonly InputAction m_PlayerControls_Sprint;
        public struct PlayerControlsActions
        {
            private @PlayerInput m_Wrapper;
            public PlayerControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
            public InputAction @ActionButton => m_Wrapper.m_PlayerControls_ActionButton;
            public InputAction @Sprint => m_Wrapper.m_PlayerControls_Sprint;
            public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerControlsActions instance)
            {
                if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                    @ActionButton.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionButton;
                    @ActionButton.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionButton;
                    @ActionButton.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionButton;
                    @Sprint.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSprint;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @ActionButton.started += instance.OnActionButton;
                    @ActionButton.performed += instance.OnActionButton;
                    @ActionButton.canceled += instance.OnActionButton;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                }
            }
        }
        public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
        public interface IPlayerControlsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnActionButton(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
        }
    }
}
