using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    /*
    Start game ()
    End game ()
    
    Change scenes ()
     */

    
    public CustomerLogic CustomerLogicObject;

    private Time _timePlayed;
    private Time _startTimePlayed;
    private double _moneyMade;


    private void Update()
    {
        if (CustomerLogicObject.CheckResult)
        {
            CustomerLogicObject.CheckMastermindResult();
        }
    }
    private void GameOver()
    {
        SceneManager.LoadScene("MaineMenu");
    }

}
