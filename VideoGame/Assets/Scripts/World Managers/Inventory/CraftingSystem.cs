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
            craftAxeButton.onClick.AddListener(delegate { CraftAnyItem(); });
            
        }

        // Update is called once per frame
        void Update()
        {
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
                Cursor.lockState = CursorLockMode.Locked;
                craftingScreenIsOpen = false;
            }
            
        }

        private void OpenToolScreen()
        {
            craftingScreenUI.SetActive(false);
            toolScreenUI.SetActive(true);
        }

        private void CraftAnyItem()
        {

            //add item into inventory

            //remove items from inventory
            
        }


    }
}
