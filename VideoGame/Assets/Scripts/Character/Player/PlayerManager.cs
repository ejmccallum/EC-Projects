using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class PlayerManager : CharacterManager
    {

        [HideInInspector] public PlayerLocomotionManager playerLocomotionManager;
        [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;

        protected override void Awake()
        {
            base.Awake();

            // Use inherited Awake() method, and then specify the PlayerManager's personal instructions
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
            playerAnimatorManager = GetComponent<PlayerAnimatorManager>();


        }

        protected override void Update()
        {
            base.Update();

            // If this is not the owner of the character, then do not handle movement
            if(!IsOwner)
            {
                return;
            }

            // Handle all movement
            playerLocomotionManager.HandleAllMovement();

        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();

            // If this is the owner of the character, then handle movement
            if(IsOwner)
            {
                PlayerCamera.instance.player = this;
                PlayerInputManager.instance.player = this;
            }

            // Handle all movement
            
        }

        protected override void LateUpdate()
        {
            // If this is not the owner of the character, then do not handle camera
            if(!IsOwner)
            {
                return;
            }

            base.LateUpdate();
            // Handle camera

            PlayerCamera.instance.HandleAllCameraActions();

        }

        
    }
}