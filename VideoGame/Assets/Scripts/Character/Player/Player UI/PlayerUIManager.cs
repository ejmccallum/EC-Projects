using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

namespace EC
{   
    public class PlayerUIManager : MonoBehaviour
    {
        public static PlayerUIManager instance;
        public GameObject interactionUI;
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
            interactionText = interactionUI.GetComponent<Text>();
            DontDestroyOnLoad(gameObject);
        }
        private void Update()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selectionTransform = hit.transform;
                

                if(selectionTransform.GetComponent<InteractableObject>() && selectionTransform.GetComponent<InteractableObject>().playerInRange == true)
                {
                    
                    interactionText.text = hit.transform.GetComponent<InteractableObject>().GetItemName();
                    interactionUI.SetActive(true);
                }    
                else
                {
                    interactionUI.SetActive(false);
                }

            }
            else
            {
                interactionUI.SetActive(false);
            }
        }   
    }
}