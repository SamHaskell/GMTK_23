using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public CustomerLogic CustomerLogicObject; // Set manually
    public Transform FloppySpawnTransform;
    public FeedbackDisplay FeedbackDisplay; // Set manually
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
                GameWin(CustomerLogicObject.SolutionData);
                FeedbackDisplay.ClearResults();
                Debug.Log("You Win!");
            } else {
                FeedbackDisplay.AddResult(CustomerLogicObject.GuessHistory[^1], CustomerLogicObject.GuessResult[^1]);
                Debug.Log(CustomerLogicObject.TurnsLeft);
                AudioManager.instance.PlaySound("incorrect");
            }
        }
    }

    private IEnumerator FloppyTime(SolutionData solution)
    {
        // TEMPORARY UNTIL WE ADD SOME PAZZAZZ
        GameObject floppy = Instantiate(solution.Model, FloppySpawnTransform.position, FloppySpawnTransform.rotation);
        floppy.transform.Find("CoverArt").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", solution.BoxArt);
        yield return new WaitForSeconds(5.0f);
        Destroy(floppy);
    }

    private void GameWin(SolutionData solution) {
        StartCoroutine(FloppyTime(solution));
        GamesSold ++;
        AudioManager.instance.PlaySound("success");
    }

    private void GameLose() {
        SceneManager.LoadScene("MainMenu");
        AudioManager.instance.PlaySound("game over");
    }

}
