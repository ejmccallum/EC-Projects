// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace EC
// {
//     public class MenuManager : MonoBehaviour
//     {
//         public static MenuManager Instance { get; set; }

//         public GameObject menuCanvas;

//         public GameObject uiCanvas;

//         public GameObject saveMenu;
//         public GameObject settingsMenu;
//         public GameObject mainMenu;

//         public bool isMenuOpen;
//         private void Awake()
//         {
//             if(Instance == null)
//             {
//                 Instance = this;
//                 DontDestroyOnLoad(gameObject);
//             }
//             else
//             {
//                 Destroy(this);
//             }
//         }

//         private void Update()
//         {
//             if (Input.GetKeyDown(KeyCode.M) && !isMenuOpen)
//             {
//                 uiCanvas.SetActive(false);
//                 menuCanvas.SetActive(true);
//                 isMenuOpen = true;

//                 Cursor.lockState = CursorLockMode.None;
//                 Cursor.visible = true;

//                 SelectionManager.Instance.DisableSelection();
//                 SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;


//             }
//             else if(Input.GetKeyDown(KeyCode.M) && isMenuOpen)
//             {
//                 uiCanvas.SetActive(true);
//                 menuCanvas.SetActive(false);
//                 isMenuOpen = false;

//                 // if(CraftingSystem.Instance.isOpen == false && InventorySysten.Instance.isOpen == false)
//                 // {
//                 //     Cursor.lockState = CursorLockMode.Locked;
//                 //     Cursor.visible = false;
//                 // }

//                 Cursor.lockState = CursorLockMode.Locked;
//                 Cursor.visible = false;



//                 SelectionManager.Instance.EnableSelection();
//                 SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
//             }
//         }


//     }


// }
