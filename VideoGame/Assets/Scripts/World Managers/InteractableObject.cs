using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class InteractableObject : MonoBehaviour
    {
        public string itemName;
        public bool playerInRange = true;

        public string GetItemName()
        {
            return itemName;
        }

        private void OnTriggerEvent(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                playerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                playerInRange = false;
            }
        }

    }
}