using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EC
{

    public class CraftingSystem : MonoBehaviour
    {

        public static CraftingSystem Instance { get; set; }

        public GameObject craftingScreenUI;
        public GameObject toolScreenUI;

        public List<string> inventoryItemList = new List<string>();

        public bool craftingScreenIsOpen;

        //Category buttons
        Button toolsButton;

        //Craft buttons
        Button craftAxeButton;

        //Requirement Text
        Text axeReq1, axeReq2;

        public ItemBlueprint axeBlueprint = new ItemBlueprint("Axe", 2, "Wood", 3, "Stone", 2);






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

        // Start is called before the first frame update
        void Start()
        {
            craftingScreenIsOpen = false;

            toolsButton = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
            toolsButton.onClick.AddListener(delegate { OpenToolScreen(); });

            //Axe
            axeReq1 = toolScreenUI.transform.Find("Axe").Find("req1").GetComponent<Text>();
            axeReq2 = toolScreenUI.transform.Find("Axe").Find("req2").GetComponent<Text>();

            craftAxeButton = toolScreenUI.transform.Find("Axe").Find("Button").GetComponent<Button>();
            craftAxeButton.onClick.AddListener(delegate { CraftAnyItem(axeBlueprint); });
            
        }

        // Update is called once per frame
        void Update()
        {
            RefreshNeededItems();

            if (Input.GetKeyDown(KeyCode.C) && !craftingScreenIsOpen)
            {
    
                craftingScreenUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                craftingScreenIsOpen = true;
    
            }
            else if (Input.GetKeyDown(KeyCode.C) && craftingScreenIsOpen)
            {
                craftingScreenUI.SetActive(false);
                toolScreenUI.SetActive(false);

                if(!InventorySystem.Instance.inventoryIsOpen)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                craftingScreenIsOpen = false;
            }
            
        }

        private void OpenToolScreen()
        {
            craftingScreenUI.SetActive(false);
            toolScreenUI.SetActive(true);
        }

        private void CraftAnyItem(ItemBlueprint itemBlueprint)
        {

            //add crafted item into inventory
            StartCoroutine(WaitToCraft(itemBlueprint));


            //remove required items from inventory
            if(itemBlueprint.numofReq == 1)
            {
                InventorySystem.Instance.RemoveItemFromInventory(itemBlueprint.req1, itemBlueprint.req1Amount);
            }else if(itemBlueprint.numofReq == 2)
            {
                InventorySystem.Instance.RemoveItemFromInventory(itemBlueprint.req1, itemBlueprint.req1Amount);
                InventorySystem.Instance.RemoveItemFromInventory(itemBlueprint.req2, itemBlueprint.req2Amount);
            }
            

            //refresh inventory
            StartCoroutine(Refresh());

            //refresh crafting screen
            RefreshNeededItems();
            
        }

        public IEnumerator Refresh()
        {
            yield return new WaitForSeconds(1f);

            //add crafted item into inventory
            InventorySystem.Instance.RefreshInventory();
        }

        public IEnumerator WaitToCraft(ItemBlueprint itemBlueprint)
        {
            yield return new WaitForSeconds(1f);

            //add crafted item into inventory
            InventorySystem.Instance.AddItemToInventory(itemBlueprint.itemName);
        }

        private void RefreshNeededItems()
        {
            int stoneCount = 0;
            int woodCount = 0;

            inventoryItemList = InventorySystem.Instance.itemList;

            foreach (string itemName in inventoryItemList)
            {
                switch (itemName)
                {
                    case "Stone":
                        stoneCount++;
                        break;
                    case "Wood":
                        woodCount++;
                        break;
                    default:
                        break;
                }
            }

            //Axe requirements

            axeReq1.text = "Stone : 2 [" + stoneCount + "]";
            axeReq2.text = "Wood : 3 [" + woodCount + "]";

            if(stoneCount >= 2 && woodCount >= 3)
            {
                craftAxeButton.gameObject.SetActive(true);
            }
            else
            {
                craftAxeButton.gameObject.SetActive(false);
            }
        }


    }
}
