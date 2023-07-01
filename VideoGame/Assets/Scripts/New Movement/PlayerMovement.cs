using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        PlayerManager player;

        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;
        public float moveAmount;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        Vector3 velocity;

        bool isGrounded;

         protected void Awake()
        {
            player = GetComponent<PlayerManager>();
        }
        
        void Update()
        {
            // Check if the player is on the ground
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // If the player is on the ground, then reset the velocity
            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // Get the horizontal and vertical input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            // Move the player
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            moveAmount = Mathf.Clamp01(Mathf.Abs(x) + Mathf.Abs(z));

            if(moveAmount <= 0.5 && moveAmount > 0)
            {
                moveAmount = 0.5f;
            }
            else if(moveAmount > 0.5 && moveAmount <= 1)
            {
                moveAmount = 1;
            }

            player.playerAnimatorManager.UpdateAnimatorMovementParameters(moveAmount, 0);

            // If the player is on the ground and the jump button is pressed, then jump
            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Apply gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        
    }
}