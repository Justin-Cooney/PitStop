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
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""34ff15c5-9468-4b96-935f-36ed16f3bf1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""4ad376e0-6135-4f3b-b1da-357a6f46437c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f9ede16f-8755-4d6d-b3f5-23dfcb5a6fe6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""b9ccc981-584d-4bd0-9a75-70d42b48b668"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""752b69a0-e147-4efc-ad75-9a17127c4dc2"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""24621a62-755a-4402-b5bb-17e57fc1b34f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb4fd18e-a2f2-4c9c-a6b4-7aed3b593b6f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a696865d-584b-4506-84d8-3d5022ed64be"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""045551db-1493-4e24-a7b2-2c8f3358fb23"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerControls
            m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
            m_PlayerControls_MoveUp = m_PlayerControls.FindAction("MoveUp", throwIfNotFound: true);
            m_PlayerControls_MoveDown = m_PlayerControls.FindAction("MoveDown", throwIfNotFound: true);
            m_PlayerControls_MoveLeft = m_PlayerControls.FindAction("MoveLeft", throwIfNotFound: true);
            m_PlayerControls_MoveRight = m_PlayerControls.FindAction("MoveRight", throwIfNotFound: true);
            m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
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
        private readonly InputAction m_PlayerControls_MoveUp;
        private readonly InputAction m_PlayerControls_MoveDown;
        private readonly InputAction m_PlayerControls_MoveLeft;
        private readonly InputAction m_PlayerControls_MoveRight;
        private readonly InputAction m_PlayerControls_Move;
        public struct PlayerControlsActions
        {
            private @PlayerInput m_Wrapper;
            public PlayerControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveUp => m_Wrapper.m_PlayerControls_MoveUp;
            public InputAction @MoveDown => m_Wrapper.m_PlayerControls_MoveDown;
            public InputAction @MoveLeft => m_Wrapper.m_PlayerControls_MoveLeft;
            public InputAction @MoveRight => m_Wrapper.m_PlayerControls_MoveRight;
            public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
            public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerControlsActions instance)
            {
                if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
                {
                    @MoveUp.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveUp;
                    @MoveUp.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveUp;
                    @MoveUp.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveUp;
                    @MoveDown.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveDown;
                    @MoveDown.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveDown;
                    @MoveDown.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveDown;
                    @MoveLeft.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveLeft;
                    @MoveRight.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveRight;
                    @MoveRight.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveRight;
                    @MoveRight.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveRight;
                    @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveUp.started += instance.OnMoveUp;
                    @MoveUp.performed += instance.OnMoveUp;
                    @MoveUp.canceled += instance.OnMoveUp;
                    @MoveDown.started += instance.OnMoveDown;
                    @MoveDown.performed += instance.OnMoveDown;
                    @MoveDown.canceled += instance.OnMoveDown;
                    @MoveLeft.started += instance.OnMoveLeft;
                    @MoveLeft.performed += instance.OnMoveLeft;
                    @MoveLeft.canceled += instance.OnMoveLeft;
                    @MoveRight.started += instance.OnMoveRight;
                    @MoveRight.performed += instance.OnMoveRight;
                    @MoveRight.canceled += instance.OnMoveRight;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
        public interface IPlayerControlsActions
        {
            void OnMoveUp(InputAction.CallbackContext context);
            void OnMoveDown(InputAction.CallbackContext context);
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
        }
    }
}
