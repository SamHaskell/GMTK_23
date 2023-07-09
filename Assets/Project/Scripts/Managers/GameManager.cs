using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public CustomerLogic CustomerLogicObject; // Set manually
    public Transform FloppySpawnTransform;
    public ButtonSwitcher ButtonSwitcher;
    public FeedbackDisplay FeedbackDisplay; // Set manually
    public GameObject ScoreCounter;
    public GameObject TagSetPrefab;
    private Time _timePlayed;
    private Time _startTimePlayed;
    public int GamesSold;
    private float _timeRemaining;
    public static GameManager Instance { get; private set; }

    [Header("Time Pressure Parameters")]
    public float InitialTime;
    public float BaseTimeAddedPerWin;
    public float TimeAddedPerRemainingGuess;
    public float TimeMax;

    public HeadDriver head;
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
        OnScoreChange(GamesSold);
        _timeRemaining = InitialTime;
        PlayerPrefs.SetInt("Score", 0);
    }

    private void Update()
    {
        _timeRemaining -= Time.deltaTime;
        Debug.Log(_timeRemaining);
        if (CustomerLogicObject.CheckResult) {
            if (CustomerLogicObject.CheckMastermindResult()) {
                GameWin(CustomerLogicObject.SolutionData);
                FeedbackDisplay.ClearResults();
                Debug.Log("You Win!");
            } else {
                FeedbackDisplay.AddResult(CustomerLogicObject.GuessHistory[^1], CustomerLogicObject.GuessResult[^1]);
                // Debug.Log(CustomerLogicObject.TurnsLeft);
                AudioManager.instance.PlaySound("incorrect");
                head.SetFace(Faces.Angry, 4f);
            }
            ButtonSwitcher.EnableButtons();
            _timeRemaining = Mathf.Clamp(_timeRemaining, _timeRemaining, TimeMax);
        }
        if (CustomerLogicObject.TurnsLeft == 0)
        {
            GameLose();
            FeedbackDisplay.ClearResults();
        }
    }

    private void OnScoreChange(int score)
    {
        ScoreCounter.GetComponent<TMP_Text>().text = (GamesSold*100).ToString();
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
        OnScoreChange(GamesSold);
        AudioManager.instance.PlaySound("success");
        head.SetFace(Faces.Happy, 8f);
        // TIME ADDITION
        _timeRemaining += BaseTimeAddedPerWin;
        _timeRemaining += CustomerLogicObject.TurnsLeft * TimeAddedPerRemainingGuess;
        //
        CustomerLogicObject.ResetCustomerLogic();


        //EmitParticles(Feedback.Success);
    }

    private void GameLose() {
        PlayerPrefs.SetInt("Score", GamesSold * 100);
        AudioManager.instance.PlaySound("game over");
        AudioManager.instance.PlayMusicLoop(false);
        SceneManager.LoadScene("GameOver");        
    }


}
