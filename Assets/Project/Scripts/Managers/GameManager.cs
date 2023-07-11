using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RoundManager RoundManager;
    public TargetManager TargetManager;
    public bool IsTutorial;
    public ButtonSwitcher ButtonSwitcher;
    public FeedbackDisplay FeedbackDisplay; // Set manually
    public GameObject TagSetPrefab;
    private Time _timePlayed;
    private Time _startTimePlayed;
    private float _timeRemaining;
    public HeadDriver Head;
    public Transform FloppySpawnTransform;
    public static GameManager Instance { get; private set; }
    
    [Header("Scoring")]
    public GameObject ScoreCounter;
    public int GamesSold;

    [Header("Timing")]
    public GameObject TimerUI;
    public bool UseTimer = true;
    public float InitialTime = 240;
    public float TimeAddedPerWin = 60;
    public float TimeAddedPerRemainingGuess = 10;
    public float TimeMax = 240;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }

        if (IsTutorial) {
            Debug.Log("Starting tutorial end timer");
            StartCoroutine(TutorialTimeCoRo());
        }

        TargetManager.OnGuess += OnGuess;
        TargetManager.OnTargetHit += OnTargetHit;

        RoundManager.OnCorrectGuess += OnRoundWin;
        RoundManager.OnIncorrectGuess += OnIncorrectGuess;
        RoundManager.OnRoundLose += OnRoundLose;
    }

    private IEnumerator TutorialTimeCoRo() {
        yield return new WaitForSeconds(57.0f);
        SceneManager.LoadScene(1);
    }

    private void Start() {
        UpdateScore(0);
        _timeRemaining = InitialTime;
        PlayerPrefs.SetInt("Score", 0);
        NewRound();
    }

    private void Update() {
        if (UseTimer) { 
            _timeRemaining -= Time.deltaTime;
            float r = (TimeMax - _timeRemaining) / TimeMax;
            TimerUI.GetComponent<Image>().color = new Color(r, 1-r, 0.0f);
            if (_timeRemaining <= 0) {
                OnGameLose(RoundManager.CurrentDisk);
            }
        }       
    }

    private void UpdateScore(int score) {
        GamesSold = score;
        ScoreCounter.GetComponent<TMP_Text>().text = (GamesSold*100).ToString();
    }

    private IEnumerator FloppyTime(DiskData solution)
    {
        GameObject floppy = Instantiate(solution.Model, FloppySpawnTransform.position, FloppySpawnTransform.rotation);
        floppy.transform.Find("CoverArt").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", solution.BoxArt);
        yield return new WaitForSeconds(2.0f);
        Destroy(floppy);
    }

    private void NewRound()
    {
        RoundManager.NewRound();
        TargetManager.NumTags = RoundManager.NumTags;
        TargetManager.CurrentDisk = RoundManager.CurrentDisk;
        TargetManager.ResetTags();
        FeedbackDisplay.ClearResults();
    }

    private void OnRoundWin(DiskData disk) {
        StartCoroutine(FloppyTime(disk));
        UpdateScore(GamesSold + 1);
        AudioManager.Instance.PlaySound("success");
        Head.SetFace(Faces.Happy, 8f);
        _timeRemaining += TimeAddedPerWin;
        _timeRemaining += RoundManager.TurnsLeft * TimeAddedPerRemainingGuess;
        NewRound();
    }

    private void OnTargetHit(Tag guess) {
        ButtonSwitcher.DisableButton(guess);
    }

    private void OnGuess(Tag[] guess) {
        // Play the guess submission SFX and do whatever.
        RoundManager.SubmitGuess(guess);
        ButtonSwitcher.EnableButtons();
        
    }

    private void OnIncorrectGuess() {
        // Play the bad guess SFX etc etc.
        FeedbackDisplay.AddResult(RoundManager.GuessHistory[^1], RoundManager.ResultHistory[^1]);
        Head.SetFace(Faces.Angry, 4f);
    }

    private void OnRoundLose(DiskData disk) {
        OnGameLose(disk);
    }

    private void OnGameLose(DiskData disk) {
        PlayerPrefs.SetInt("Score", GamesSold * 100);
        AudioManager.Instance.PlaySound("game over");
        AudioManager.Instance.PlayMusicLoop(false);
        SceneManager.LoadScene("GameOver");        
    }
}
