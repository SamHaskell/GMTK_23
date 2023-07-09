using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

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
    public int GamesSold;
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
        GamesSold = 0;
    }

    private void Update()
    {
        if (CustomerLogicObject.TurnsLeft == 0) {
            GameLose();
        }
        if (CustomerLogicObject.CheckResult) {
            if (CustomerLogicObject.CheckMastermindResult()) {
                GameWin();
            }
            Debug.Log(CustomerLogicObject.TurnsLeft);
        }
    }

    private void GameWin() {
        GamesSold ++;
    }

    private void GameLose() {
        SceneManager.LoadScene("MainMenu");
    }

}
