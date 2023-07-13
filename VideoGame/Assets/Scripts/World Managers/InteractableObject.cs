using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class InteractableObject : MonoBehaviour
    {
        public string itemName;
        public string addedToInventoryText;
        public bool playerInRange;
        //public bool isPickup;

        public string GetItemName()
        {
            return itemName;
        }

        public string GetAddedToInventoryText()
        {
            return addedToInventoryText;
        }

        void Update()
        {

            if(playerInRange && Input.GetKeyDown(KeyCode.E) 
                && PlayerUIManager.instance.onTarget 
                && PlayerUIManager.instance.selectedObject == gameObject)
            {
                //isPickup = true;
                if(InventorySystem.Instance.CheckIfInventoryIsFull() == false)
                {
                    AddItemToInventory();
                }
                else
                {
                    Debug.Log("Inventory is full");
                }
                

            }
        }

        private void AddItemToInventory()
        {

            InventorySystem.Instance.AddItemToInventory(itemName);
            Destroy(gameObject);
        }

        

        private void OnTriggerEnter(Collider other)
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