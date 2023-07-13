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

        public bool inventoryIsOpen;
        public bool inventoryIsFull;
    
    
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
                Cursor.lockState = CursorLockMode.None;
                inventoryIsOpen = true;
    
            }
            else if (Input.GetKeyDown(KeyCode.I) && inventoryIsOpen)
            {
                inventoryScreenUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                inventoryIsOpen = false;
            }
        }

        public void AddItemToInventory(string itemName)
        {

            slotToAddTo = FindNextAvailableSlot();
            itemToAdd = Instantiate(Resources.Load<GameObject>(itemName), slotToAddTo.transform.position, slotToAddTo.transform.rotation);
            itemToAdd.transform.SetParent(slotToAddTo.transform);

            itemList.Add(itemName);

        }

        public bool CheckIfInventoryIsFull()
        {
            int counter = 0;
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount > 0)
                {
                    counter++;
                }

            }
            if (counter == slotList.Count)
            {
                inventoryIsFull = true;
                return true;
            }
            else
            {
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
            return new GameObject();
        }

    
    }
}