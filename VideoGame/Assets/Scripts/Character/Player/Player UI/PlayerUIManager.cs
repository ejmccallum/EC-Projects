using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

namespace EC
{   
    public class PlayerUIManager : MonoBehaviour
    {


        public static PlayerUIManager instance{get; set;}

        public bool onTarget;

        public GameObject interactionUI;
        public GameObject selectedObject;

        Text interactionText;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            onTarget = false;
            interactionText = interactionUI.GetComponent<Text>();
            //DontDestroyOnLoad(gameObject);
        }
        private void Update()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selectionTransform = hit.transform;

                InteractableObject interactableObject = selectionTransform.GetComponent<InteractableObject>();
                
                if(interactableObject && interactableObject.playerInRange)
                {
                    onTarget = true;
                    selectedObject = interactableObject.gameObject;

                    interactionText.text = interactableObject.GetItemName();
                    interactionUI.SetActive(true);

                }    
                else
                {
                    onTarget = false;
                    interactionUI.SetActive(false);
                }

            }
            else
            {
                onTarget = false;
                interactionUI.SetActive(false);
            }
        }   
    }
}