//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/_Scripts/Input/PlayerControllerMap.inputactions
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

public partial class @PlayerControllerMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControllerMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllerMap"",
    ""maps"": [
        {
            ""name"": ""PlayerMainMap"",
            ""id"": ""e7b5801e-00ca-498f-befe-f0d3c5dae6e6"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dc33a823-8092-447e-b062-71c01784e3cd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5f004161-8477-4d9d-b5b7-07b2d402cb41"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""83a428ef-aa11-41c5-ba86-e921babee27c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0a236334-3562-4b76-b423-cbc6d385c569"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f0a8b024-ae86-4690-9772-0f3b01c2c3d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""cea39a94-14e0-4677-a781-5df03691228a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""e19f7b0a-e0c6-4c4d-bc11-72576859405c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""2794f196-bc5d-4634-8bfd-72d4ede80c58"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""fd582c34-659f-4abb-bf47-0b2b1c33f5b4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""51fd77f8-ab99-4468-8108-7d7c38625243"",
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
                    ""id"": ""c32fbfa0-6d14-4395-872c-e9a560f9cfdb"",
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
                    ""id"": ""2013798e-c84f-4a0c-b6ab-ce4eec87fad9"",
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
                    ""id"": ""65cf02f7-8906-4644-99ad-afed377d7805"",
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
                    ""id"": ""d5457829-461e-417e-af7a-2025edb11211"",
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
                    ""id"": ""99a8ec48-f3ae-4f63-921b-d083e08e8b93"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ee6a0c2-be61-4ee4-a760-57de6ca70ba9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8be27ce2-c6ef-4f5c-b299-8b1d89e271b6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abf25d5a-42eb-4866-a56b-de7fe290f208"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da654008-3cbb-4715-a6c8-09e7ec7f5425"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88e1e1ab-efb8-4638-8570-a3c2fd2dbe15"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5d910e4-aaac-495f-9867-2d2d48ce33e6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a212fba-7ac9-401f-b35a-43f3a7a93f5d"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMainMap
        m_PlayerMainMap = asset.FindActionMap("PlayerMainMap", throwIfNotFound: true);
        m_PlayerMainMap_Look = m_PlayerMainMap.FindAction("Look", throwIfNotFound: true);
        m_PlayerMainMap_Move = m_PlayerMainMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerMainMap_Sprint = m_PlayerMainMap.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerMainMap_Jump = m_PlayerMainMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMainMap_Dash = m_PlayerMainMap.FindAction("Dash", throwIfNotFound: true);
        m_PlayerMainMap_Attack = m_PlayerMainMap.FindAction("Attack", throwIfNotFound: true);
        m_PlayerMainMap_Block = m_PlayerMainMap.FindAction("Block", throwIfNotFound: true);
        m_PlayerMainMap_PrimaryWeapon = m_PlayerMainMap.FindAction("PrimaryWeapon", throwIfNotFound: true);
        m_PlayerMainMap_Inventory = m_PlayerMainMap.FindAction("Inventory", throwIfNotFound: true);
    }

    ~@PlayerControllerMap()
    {
        UnityEngine.Debug.Assert(!m_PlayerMainMap.enabled, "This will cause a leak and performance issues, PlayerControllerMap.PlayerMainMap.Disable() has not been called.");
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

    // PlayerMainMap
    private readonly InputActionMap m_PlayerMainMap;
    private List<IPlayerMainMapActions> m_PlayerMainMapActionsCallbackInterfaces = new List<IPlayerMainMapActions>();
    private readonly InputAction m_PlayerMainMap_Look;
    private readonly InputAction m_PlayerMainMap_Move;
    private readonly InputAction m_PlayerMainMap_Sprint;
    private readonly InputAction m_PlayerMainMap_Jump;
    private readonly InputAction m_PlayerMainMap_Dash;
    private readonly InputAction m_PlayerMainMap_Attack;
    private readonly InputAction m_PlayerMainMap_Block;
    private readonly InputAction m_PlayerMainMap_PrimaryWeapon;
    private readonly InputAction m_PlayerMainMap_Inventory;
    public struct PlayerMainMapActions
    {
        private @PlayerControllerMap m_Wrapper;
        public PlayerMainMapActions(@PlayerControllerMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_PlayerMainMap_Look;
        public InputAction @Move => m_Wrapper.m_PlayerMainMap_Move;
        public InputAction @Sprint => m_Wrapper.m_PlayerMainMap_Sprint;
        public InputAction @Jump => m_Wrapper.m_PlayerMainMap_Jump;
        public InputAction @Dash => m_Wrapper.m_PlayerMainMap_Dash;
        public InputAction @Attack => m_Wrapper.m_PlayerMainMap_Attack;
        public InputAction @Block => m_Wrapper.m_PlayerMainMap_Block;
        public InputAction @PrimaryWeapon => m_Wrapper.m_PlayerMainMap_PrimaryWeapon;
        public InputAction @Inventory => m_Wrapper.m_PlayerMainMap_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMainMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMainMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMainMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMainMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMainMapActionsCallbackInterfaces.Add(instance);
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Block.started += instance.OnBlock;
            @Block.performed += instance.OnBlock;
            @Block.canceled += instance.OnBlock;
            @PrimaryWeapon.started += instance.OnPrimaryWeapon;
            @PrimaryWeapon.performed += instance.OnPrimaryWeapon;
            @PrimaryWeapon.canceled += instance.OnPrimaryWeapon;
            @Inventory.started += instance.OnInventory;
            @Inventory.performed += instance.OnInventory;
            @Inventory.canceled += instance.OnInventory;
        }

        private void UnregisterCallbacks(IPlayerMainMapActions instance)
        {
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Block.started -= instance.OnBlock;
            @Block.performed -= instance.OnBlock;
            @Block.canceled -= instance.OnBlock;
            @PrimaryWeapon.started -= instance.OnPrimaryWeapon;
            @PrimaryWeapon.performed -= instance.OnPrimaryWeapon;
            @PrimaryWeapon.canceled -= instance.OnPrimaryWeapon;
            @Inventory.started -= instance.OnInventory;
            @Inventory.performed -= instance.OnInventory;
            @Inventory.canceled -= instance.OnInventory;
        }

        public void RemoveCallbacks(IPlayerMainMapActions instance)
        {
            if (m_Wrapper.m_PlayerMainMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMainMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMainMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMainMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMainMapActions @PlayerMainMap => new PlayerMainMapActions(this);
    public interface IPlayerMainMapActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnPrimaryWeapon(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
}
