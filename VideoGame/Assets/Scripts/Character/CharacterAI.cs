using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EC
{
    public class CharacterAI : MonoBehaviour
    {

        Animator animator;

        public float moveSpeed = .3f;

        Vector3 destination;

        float walkTime;
        public float walkCounter;
        float waitTime;
        public float waitCounter;

        int walkDirection;

        public bool isWalking;

        void Start()
        {
            animator = GetComponent<Animator>();

            walkTime = Random.Range(3, 6);
            waitTime = Random.Range(3, 5);


            waitCounter = waitTime;
            walkCounter = walkTime;
            ChooseDirection();
        }

        void Update()
        {
            if(isWalking)
            {
                animator.SetBool("isWalking", true);

                walkCounter -= Time.deltaTime;

                transform.localRotation = Quaternion.Euler(0, walkDirection, 0);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

                if(walkCounter <= 0)
                {
                    destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    isWalking = false;

                    transform.position = destination;
                    animator.SetBool("isWalking", false);

                    waitCounter = waitTime;
                }
            }
            else
            {
                waitCounter -= Time.deltaTime;

                if(waitCounter <= 0)
                {
                    ChooseDirection();
                }
            }
        }

        public void ChooseDirection()
        {
            walkDirection = Random.Range(0, 360);

            isWalking = true;
            walkCounter = walkTime;
        }

    }
}