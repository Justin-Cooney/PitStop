// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInput.inputactions'

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Input;


namespace Assets.Scripts.Player
{
    [Serializable]
    public class PlayerInput : InputActionAssetReference
    {
        public PlayerInput()
        {
        }
        public PlayerInput(InputActionAsset asset)
            : base(asset)
        {
        }
        private bool m_Initialized;
        private void Initialize()
        {
            // PlayerControls
            m_PlayerControls = asset.GetActionMap("PlayerControls");
            m_PlayerControls_MoveUp = m_PlayerControls.GetAction("MoveUp");
            if (m_PlayerControlsMoveUpActionStarted != null)
                m_PlayerControls_MoveUp.started += m_PlayerControlsMoveUpActionStarted.Invoke;
            if (m_PlayerControlsMoveUpActionPerformed != null)
                m_PlayerControls_MoveUp.performed += m_PlayerControlsMoveUpActionPerformed.Invoke;
            if (m_PlayerControlsMoveUpActionCancelled != null)
                m_PlayerControls_MoveUp.cancelled += m_PlayerControlsMoveUpActionCancelled.Invoke;
            m_Initialized = true;
        }
        private void Uninitialize()
        {
            if (m_PlayerControlsActionsCallbackInterface != null)
            {
                PlayerControls.SetCallbacks(null);
            }
            m_PlayerControls = null;
            m_PlayerControls_MoveUp = null;
            if (m_PlayerControlsMoveUpActionStarted != null)
                m_PlayerControls_MoveUp.started -= m_PlayerControlsMoveUpActionStarted.Invoke;
            if (m_PlayerControlsMoveUpActionPerformed != null)
                m_PlayerControls_MoveUp.performed -= m_PlayerControlsMoveUpActionPerformed.Invoke;
            if (m_PlayerControlsMoveUpActionCancelled != null)
                m_PlayerControls_MoveUp.cancelled -= m_PlayerControlsMoveUpActionCancelled.Invoke;
            m_Initialized = false;
        }
        public void SetAsset(InputActionAsset newAsset)
        {
            if (newAsset == asset) return;
            var PlayerControlsCallbacks = m_PlayerControlsActionsCallbackInterface;
            if (m_Initialized) Uninitialize();
            asset = newAsset;
            PlayerControls.SetCallbacks(PlayerControlsCallbacks);
        }
        public override void MakePrivateCopyOfActions()
        {
            SetAsset(ScriptableObject.Instantiate(asset));
        }
        // PlayerControls
        private InputActionMap m_PlayerControls;
        private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
        private InputAction m_PlayerControls_MoveUp;
        [SerializeField] private ActionEvent m_PlayerControlsMoveUpActionStarted;
        [SerializeField] private ActionEvent m_PlayerControlsMoveUpActionPerformed;
        [SerializeField] private ActionEvent m_PlayerControlsMoveUpActionCancelled;
        public struct PlayerControlsActions
        {
            private PlayerInput m_Wrapper;
            public PlayerControlsActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveUp { get { return m_Wrapper.m_PlayerControls_MoveUp; } }
            public ActionEvent MoveUpStarted { get { return m_Wrapper.m_PlayerControlsMoveUpActionStarted; } }
            public ActionEvent MoveUpPerformed { get { return m_Wrapper.m_PlayerControlsMoveUpActionPerformed; } }
            public ActionEvent MoveUpCancelled { get { return m_Wrapper.m_PlayerControlsMoveUpActionCancelled; } }
            public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled { get { return Get().enabled; } }
            public InputActionMap Clone() { return Get().Clone(); }
            public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerControlsActions instance)
            {
                if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
                {
                    MoveUp.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveUp;
                    MoveUp.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveUp;
                    MoveUp.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveUp;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    MoveUp.started += instance.OnMoveUp;
                    MoveUp.performed += instance.OnMoveUp;
                    MoveUp.cancelled += instance.OnMoveUp;
                }
            }
        }
        public PlayerControlsActions @PlayerControls
        {
            get
            {
                if (!m_Initialized) Initialize();
                return new PlayerControlsActions(this);
            }
        }
        [Serializable]
        public class ActionEvent : UnityEvent<InputAction.CallbackContext>
        {
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
    }
}
