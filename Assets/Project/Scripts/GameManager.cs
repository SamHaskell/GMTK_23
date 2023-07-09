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
    public GameObject TagSetPrefab;
    private Time _timePlayed;
    private Time _startTimePlayed;
    private double _moneyMade;
    public static GameManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        GameObject tagSet = Instantiate(TagSetPrefab);
        tagSet.GetComponent<TagController>().CustomerLogicObject = CustomerLogicObject;
    }

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
