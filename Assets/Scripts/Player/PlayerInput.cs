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
            m_PlayerControls_MoveDown = m_PlayerControls.GetAction("MoveDown");
            if (m_PlayerControlsMoveDownActionStarted != null)
                m_PlayerControls_MoveDown.started += m_PlayerControlsMoveDownActionStarted.Invoke;
            if (m_PlayerControlsMoveDownActionPerformed != null)
                m_PlayerControls_MoveDown.performed += m_PlayerControlsMoveDownActionPerformed.Invoke;
            if (m_PlayerControlsMoveDownActionCancelled != null)
                m_PlayerControls_MoveDown.cancelled += m_PlayerControlsMoveDownActionCancelled.Invoke;
            m_PlayerControls_MoveLeft = m_PlayerControls.GetAction("MoveLeft");
            if (m_PlayerControlsMoveLeftActionStarted != null)
                m_PlayerControls_MoveLeft.started += m_PlayerControlsMoveLeftActionStarted.Invoke;
            if (m_PlayerControlsMoveLeftActionPerformed != null)
                m_PlayerControls_MoveLeft.performed += m_PlayerControlsMoveLeftActionPerformed.Invoke;
            if (m_PlayerControlsMoveLeftActionCancelled != null)
                m_PlayerControls_MoveLeft.cancelled += m_PlayerControlsMoveLeftActionCancelled.Invoke;
            m_PlayerControls_MoveRight = m_PlayerControls.GetAction("MoveRight");
            if (m_PlayerControlsMoveRightActionStarted != null)
                m_PlayerControls_MoveRight.started += m_PlayerControlsMoveRightActionStarted.Invoke;
            if (m_PlayerControlsMoveRightActionPerformed != null)
                m_PlayerControls_MoveRight.performed += m_PlayerControlsMoveRightActionPerformed.Invoke;
            if (m_PlayerControlsMoveRightActionCancelled != null)
                m_PlayerControls_MoveRight.cancelled += m_PlayerControlsMoveRightActionCancelled.Invoke;
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
            m_PlayerControls_MoveDown = null;
            if (m_PlayerControlsMoveDownActionStarted != null)
                m_PlayerControls_MoveDown.started -= m_PlayerControlsMoveDownActionStarted.Invoke;
            if (m_PlayerControlsMoveDownActionPerformed != null)
                m_PlayerControls_MoveDown.performed -= m_PlayerControlsMoveDownActionPerformed.Invoke;
            if (m_PlayerControlsMoveDownActionCancelled != null)
                m_PlayerControls_MoveDown.cancelled -= m_PlayerControlsMoveDownActionCancelled.Invoke;
            m_PlayerControls_MoveLeft = null;
            if (m_PlayerControlsMoveLeftActionStarted != null)
                m_PlayerControls_MoveLeft.started -= m_PlayerControlsMoveLeftActionStarted.Invoke;
            if (m_PlayerControlsMoveLeftActionPerformed != null)
                m_PlayerControls_MoveLeft.performed -= m_PlayerControlsMoveLeftActionPerformed.Invoke;
            if (m_PlayerControlsMoveLeftActionCancelled != null)
                m_PlayerControls_MoveLeft.cancelled -= m_PlayerControlsMoveLeftActionCancelled.Invoke;
            m_PlayerControls_MoveRight = null;
            if (m_PlayerControlsMoveRightActionStarted != null)
                m_PlayerControls_MoveRight.started -= m_PlayerControlsMoveRightActionStarted.Invoke;
            if (m_PlayerControlsMoveRightActionPerformed != null)
                m_PlayerControls_MoveRight.performed -= m_PlayerControlsMoveRightActionPerformed.Invoke;
            if (m_PlayerControlsMoveRightActionCancelled != null)
                m_PlayerControls_MoveRight.cancelled -= m_PlayerControlsMoveRightActionCancelled.Invoke;
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
        private InputAction m_PlayerControls_MoveDown;
        [SerializeField] private ActionEvent m_PlayerControlsMoveDownActionStarted;
        [SerializeField] private ActionEvent m_PlayerControlsMoveDownActionPerformed;
        [SerializeField] private ActionEvent m_PlayerControlsMoveDownActionCancelled;
        private InputAction m_PlayerControls_MoveLeft;
        [SerializeField] private ActionEvent m_PlayerControlsMoveLeftActionStarted;
        [SerializeField] private ActionEvent m_PlayerControlsMoveLeftActionPerformed;
        [SerializeField] private ActionEvent m_PlayerControlsMoveLeftActionCancelled;
        private InputAction m_PlayerControls_MoveRight;
        [SerializeField] private ActionEvent m_PlayerControlsMoveRightActionStarted;
        [SerializeField] private ActionEvent m_PlayerControlsMoveRightActionPerformed;
        [SerializeField] private ActionEvent m_PlayerControlsMoveRightActionCancelled;
        public struct PlayerControlsActions
        {
            private PlayerInput m_Wrapper;
            public PlayerControlsActions(PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveUp { get { return m_Wrapper.m_PlayerControls_MoveUp; } }
            public ActionEvent MoveUpStarted { get { return m_Wrapper.m_PlayerControlsMoveUpActionStarted; } }
            public ActionEvent MoveUpPerformed { get { return m_Wrapper.m_PlayerControlsMoveUpActionPerformed; } }
            public ActionEvent MoveUpCancelled { get { return m_Wrapper.m_PlayerControlsMoveUpActionCancelled; } }
            public InputAction @MoveDown { get { return m_Wrapper.m_PlayerControls_MoveDown; } }
            public ActionEvent MoveDownStarted { get { return m_Wrapper.m_PlayerControlsMoveDownActionStarted; } }
            public ActionEvent MoveDownPerformed { get { return m_Wrapper.m_PlayerControlsMoveDownActionPerformed; } }
            public ActionEvent MoveDownCancelled { get { return m_Wrapper.m_PlayerControlsMoveDownActionCancelled; } }
            public InputAction @MoveLeft { get { return m_Wrapper.m_PlayerControls_MoveLeft; } }
            public ActionEvent MoveLeftStarted { get { return m_Wrapper.m_PlayerControlsMoveLeftActionStarted; } }
            public ActionEvent MoveLeftPerformed { get { return m_Wrapper.m_PlayerControlsMoveLeftActionPerformed; } }
            public ActionEvent MoveLeftCancelled { get { return m_Wrapper.m_PlayerControlsMoveLeftActionCancelled; } }
            public InputAction @MoveRight { get { return m_Wrapper.m_PlayerControls_MoveRight; } }
            public ActionEvent MoveRightStarted { get { return m_Wrapper.m_PlayerControlsMoveRightActionStarted; } }
            public ActionEvent MoveRightPerformed { get { return m_Wrapper.m_PlayerControlsMoveRightActionPerformed; } }
            public ActionEvent MoveRightCancelled { get { return m_Wrapper.m_PlayerControlsMoveRightActionCancelled; } }
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
                    MoveDown.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveDown;
                    MoveDown.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveDown;
                    MoveDown.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveDown;
                    MoveLeft.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveLeft;
                    MoveLeft.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveLeft;
                    MoveLeft.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveLeft;
                    MoveRight.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveRight;
                    MoveRight.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveRight;
                    MoveRight.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveRight;
                }
                m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    MoveUp.started += instance.OnMoveUp;
                    MoveUp.performed += instance.OnMoveUp;
                    MoveUp.cancelled += instance.OnMoveUp;
                    MoveDown.started += instance.OnMoveDown;
                    MoveDown.performed += instance.OnMoveDown;
                    MoveDown.cancelled += instance.OnMoveDown;
                    MoveLeft.started += instance.OnMoveLeft;
                    MoveLeft.performed += instance.OnMoveLeft;
                    MoveLeft.cancelled += instance.OnMoveLeft;
                    MoveRight.started += instance.OnMoveRight;
                    MoveRight.performed += instance.OnMoveRight;
                    MoveRight.cancelled += instance.OnMoveRight;
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
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
    }
}
