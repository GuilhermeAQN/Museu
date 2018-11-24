using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void BookUp()
    {
        BookController.instance.Slide();
    }

}
