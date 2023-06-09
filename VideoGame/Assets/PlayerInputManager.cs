using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class PlayerInputManager : MonoBehaviour
    {
        PlayerControls playerControls;

        [SerializeField] Vector2 movement;

        

        private void OnEnable()
        {
            if(playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movement = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }
    }
}
