using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_manager : MonoBehaviour
{

    public string PlayScene;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Ouvrir le Menu pause avec getkey
    }

    public void OnClickplay()
    {
        SceneManager.LoadScene(PlayScene);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickUnPaused()
    {
        GameObject.Find("MainMenu").SetActive(false);
    }
    public void OnClickPaused()
    {
        GameObject.Find("MainMenu").SetActive(true);

    }

}



