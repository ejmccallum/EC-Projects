using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace EC
{
    public class InGameMenu : MonoBehaviour
    {
      public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}