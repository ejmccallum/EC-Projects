using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class CharacterAnimatorManager : MonoBehaviour
    {   
        CharacterManager character;

        float vertical;
        float horizontal;

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }
        public void UpdateAnimatorMovementParameters(float verticalMovement, float horizontalMovement)
        {
            // Update animator movement parameters
            character.animator.SetFloat("Vertical", verticalMovement, 0.1f, Time.deltaTime);
            character.animator.SetFloat("Horizontal", horizontalMovement, 0.1f, Time.deltaTime);
        }

    }
}