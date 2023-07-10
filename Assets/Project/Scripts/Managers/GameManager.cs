using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CustomerLogic CustomerLogicObject; // Set manually
    public Transform FloppySpawnTransform;
    public bool IsTutorial;
    public ButtonSwitcher ButtonSwitcher;
    public FeedbackDisplay FeedbackDisplay; // Set manually
    public GameObject TimerUI;
    public GameObject ScoreCounter;
    public GameObject TagSetPrefab;
    private Time _timePlayed;
    private Time _startTimePlayed;
    public int GamesSold;
    private float _timeRemaining;
    public bool UseTimer;
    public static GameManager Instance { get; private set; }

    [Header("Time Pressure Parameters")]
    public float InitialTime;
    public float BaseTimeAddedPerWin;
    public float TimeAddedPerRemainingGuess;
    public float TimeMax;
    public HeadDriver Head;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    private IEnumerator TutorialTimeCoRo() {
        yield return new WaitForSeconds(60.0f);
        SceneManager.LoadScene(1);
    }

    private void Start() {
        if (IsTutorial) {
            TutorialTimeCoRo();
            IsTutorial = false;
        }
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
                GameWin(CustomerLogicObject.CurrentDisk);
                FeedbackDisplay.ClearResults();
                Debug.Log("You Win!");
            } else {
                FeedbackDisplay.AddResult(CustomerLogicObject.GuessHistory[^1], CustomerLogicObject.GuessResult[^1]);
                AudioManager.Instance.PlaySound("incorrect");
                Head.SetFace(Faces.Angry, 4f);
            }
            ButtonSwitcher.EnableButtons();
            _timeRemaining = Mathf.Clamp(_timeRemaining, _timeRemaining, TimeMax);
        }
        if (CustomerLogicObject.TurnsLeft == 0)
        {
            GameLose();
            FeedbackDisplay.ClearResults();
        }
        float r = (TimeMax - _timeRemaining)/TimeMax;
        if (UseTimer) {TimerUI.GetComponent<Image>().color = new Color(r, 1-r, 0.0f);}
    }

    private void OnScoreChange(int score)
    {
        ScoreCounter.GetComponent<TMP_Text>().text = (GamesSold*100).ToString();
    }

    private IEnumerator FloppyTime(DiskData solution)
    {
        GameObject floppy = Instantiate(solution.Model, FloppySpawnTransform.position, FloppySpawnTransform.rotation);
        floppy.transform.Find("CoverArt").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", solution.BoxArt);
        yield return new WaitForSeconds(5.0f);
        Destroy(floppy);
    }

    private void GameWin(DiskData solution) {
        StartCoroutine(FloppyTime(solution));
        GamesSold ++;
        OnScoreChange(GamesSold);
        AudioManager.Instance.PlaySound("success");
        Head.SetFace(Faces.Happy, 8f);
        _timeRemaining += BaseTimeAddedPerWin;
        _timeRemaining += CustomerLogicObject.TurnsLeft * TimeAddedPerRemainingGuess;
        CustomerLogicObject.ResetCustomerLogic();

    }

    private void GameLose() {
        PlayerPrefs.SetInt("Score", GamesSold * 100);
        AudioManager.Instance.PlaySound("game over");
        AudioManager.Instance.PlayMusicLoop(false);
        SceneManager.LoadScene("GameOver");        
    }


}
