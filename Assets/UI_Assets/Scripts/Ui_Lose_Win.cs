using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Ui_Lose_Win : MonoBehaviour
{

    public string PlayGame;
    public string PlayMenu;

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
        SceneManager.LoadScene(PlayGame);
    }
    public void OnClickExit()
    {
        SceneManager.LoadScene(PlayMenu);
    }


}



