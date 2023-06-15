using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.IO;


namespace EC
{
    public class PlayerManager : CharacterManager
    {

        PlayerLocomotionManager playerLocomotionManager;
        private PlayerNetworkManager playerNetworkManager;

        protected override void Awake()
        {
            base.Awake();

            // Use inherited Awake() method, and then specify the PlayerManager's personal instructions
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();


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

        public void SaveGameDataToCurrentCharacterData(ref CharacterSaveData currentCharacterData)
        {
            currentCharacterData.characterName = playerNetworkManager.characterName.Value.ToString();
            currentCharacterData.xPosition = transform.position.x;
            currentCharacterData.yPosition = transform.position.y;
            currentCharacterData.zPosition = transform.position.z;
        }

        public void LoadGameDataFromCurrentCharacterData(ref CharacterSaveData currentCharacterData)
        {
            playerNetworkManager.characterName.Value = currentCharacterData.characterName;
            Vector3 myPosition = new Vector3(currentCharacterData.xPosition, currentCharacterData.yPosition, currentCharacterData.zPosition);
            transform.position = myPosition;
        }
    }
}