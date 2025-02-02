using Space.CoreSystem;
using Space.FSM;
using UnityEngine;


namespace Space.FSM
{
    public class PlayerScript : MonoBehaviour
    {
        #region State Variables
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }

        public PlayerCarryState CarryState { get; private set; }



        [SerializeField]
        private PlayerData playerData;
        #endregion

        #region Components
        public Core Core { get; private set; }
        public Animator Anim { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Rigidbody2D RB { get; private set; }
        public BoxCollider2D MovementCollider { get; private set; }
        #endregion

        #region Other Variables         

        private Vector2 workspace;

        #endregion

        #region Unity Callback Functions
        private void Awake()
        {
            Core = GetComponentInChildren<Core>();

            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
            InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
            LandState = new PlayerLandState(this, StateMachine, playerData, "land");
            CarryState = new PlayerCarryState(this, StateMachine, playerData, "carry");


        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            RB = GetComponent<Rigidbody2D>();
            MovementCollider = GetComponent<BoxCollider2D>();

            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            Core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        #region Other Functions

        public void SetColliderHeight(float height)
        {
            Vector2 center = MovementCollider.offset;
            workspace.Set(MovementCollider.size.x, height);

            center.y += (height - MovementCollider.size.y) / 2;

            MovementCollider.size = workspace;
            MovementCollider.offset = center;
        }

        #endregion
    }

}