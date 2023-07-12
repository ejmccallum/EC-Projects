using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{    
    public class InventorySystem : MonoBehaviour
    {
    
        public static InventorySystem Instance { get; set; }
    
        public GameObject inventoryScreenUI;

        public List<GameObject> slotList = new List<GameObject>();
        public List<string> itemList = new List<string>();

        private GameObject itemToAdd;
        private GameObject slotToAddTo;

        public bool inventoryIsFull = false;
        public bool inventoryIsOpen;
    
    
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    
    
        void Start()
        {
            inventoryIsOpen = false;

            PopulateSlotList();

        }
    
    
        void Update()
        {
    
            if (Input.GetKeyDown(KeyCode.I) && !inventoryIsOpen)
            {
    
                Debug.Log("i is pressed");
                inventoryScreenUI.SetActive(true);
                inventoryIsOpen = true;
    
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryIsOpen)
            {
                inventoryScreenUI.SetActive(false);
                inventoryIsOpen = false;
            }
        }

        public void AddItemToInventory(string itemName)
        {
            if(CheckIfInventoryIsFull())
            {
                Debug.Log("Inventory is full");
                return;
            }
            else
            {
               slotToAddTo = FindNextAvailableSlot();
               itemToAdd = Instantiate(Resources.Load<GameObject>(itemName), slotToAddTo.transform.position, slotToAddTo.transform.rotation);
                itemToAdd.transform.SetParent(slotToAddTo.transform);

                itemList.Add(itemName);
            }
        }

        private bool CheckIfInventoryIsFull()
        {
            if(itemList.Count == slotList.Count)
            {
                inventoryIsFull = true;
                return true;
            }
            else
            {
                inventoryIsFull = false;
                return false;
            }
        }

        private void PopulateSlotList()
        {
            foreach (Transform child in inventoryScreenUI.transform)
            {
                if (child.CompareTag("Slot"))
                {
                    slotList.Add(child.gameObject);
                }
            }
        }

        private GameObject FindNextAvailableSlot()
        {
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount == 0)
                {
                    return slot;
                }
            }
            return null;
        }

    
    }
}