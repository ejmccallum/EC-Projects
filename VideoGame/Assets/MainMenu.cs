using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EC
{
    public class MainMenu : MonoBehaviour
    {
        public void NewGame()
        {
            SceneManager.LoadScene("Scene_World_01");
        }

        public void ExitGame()
        {
            Debug.Log("Exiting Game");
            Application.Quit();
        }
    }
}