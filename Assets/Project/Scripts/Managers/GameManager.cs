using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public FeedbackDisplay FeedbackDisplay;
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
            FeedbackDisplay.ClearResults();
        }
        if (CustomerLogicObject.CheckResult) {
            if (CustomerLogicObject.CheckMastermindResult()) {
                GameWin();
                FeedbackDisplay.ClearResults();
                Debug.Log("You Win!");
            } else {
                FeedbackDisplay.AddResult(CustomerLogicObject.GuessHistory[^1], CustomerLogicObject.GuessResult[^1]);
                Debug.Log(CustomerLogicObject.TurnsLeft);
            }
        }
    }

    private void GameWin() {
        GamesSold ++;
    }

    private void GameLose() {
        SceneManager.LoadScene("MainMenu");
    }

}
