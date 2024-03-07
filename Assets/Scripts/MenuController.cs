using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void LoadScene (int sceneIndex)
    {
        //loads the scene given index in the Scene list
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit() {
        //quits the player out of the game
        Application.Quit();
    }
}
