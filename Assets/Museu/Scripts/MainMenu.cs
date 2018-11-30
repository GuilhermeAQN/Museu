using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowOptions(){
        BookController.instance.Show();
    }
    public void HideOptions(){
        BookController.instance.Hide();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
