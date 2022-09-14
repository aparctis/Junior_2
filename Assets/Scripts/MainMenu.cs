using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace JuniorProject_01
{
    public class MainMenu : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

        }

        public void ExitGame()
        {
            Application.Quit();

        }

        public void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
        }

    }
}
