using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace JuniorProject_01
{
    public class MainMenu : MonoBehaviour
    {
        //singleton
        public static MainMenu singletonMenu;

        //advices
        [SerializeField] private List <GameObject> advices = new List<GameObject>();

        //Audio
        private AudioSource source;



        private void Start()
        {
            Time.timeScale = 1;

            if (singletonMenu == null)
            {
                singletonMenu = this;
            }

            else
            {
                Debug.Log("Singleton mainMenu error");
            }

            if (GetComponent<AudioSource>() != null) source = GetComponent<AudioSource>();
        }
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

        public void PausaStart()
        {
            Time.timeScale = 0;
        }

        public void PausaOver()
        {
            Time.timeScale = 1;

        }

        //advices
        public void CallAdvice(int adviceIndex)
        {
            if (advices[adviceIndex] != null)
            {
                advices[adviceIndex].SetActive(true);
                PausaStart();
            }

            else
            {
                Debug.Log("Wrong advice index!");
            }
        }

        //audio
        public void SetVolume(float newVolume)
        {
            if(GetComponent<AudioSource>()!= null)
            {
                source.volume = newVolume;
            }
        }
    }
}
