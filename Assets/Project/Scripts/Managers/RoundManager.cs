using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public bool CheckResult;
    public List<DiskData> PossibleDisks;
    public DiskData CurrentDisk;
    public int MaxTurns;
    public List<Tag[]> GuessHistory { get; private set; }
    public List<Dictionary<Result, int>> ResultHistory { get; private set; }
    public int NumTags;
    public int TurnsLeft;

    public Action<DiskData> OnCorrectGuess;
    public Action OnIncorrectGuess;
    public Action<DiskData> OnRoundLose;
    
    private void Awake() {
        GuessHistory = new List<Tag[]>();
        ResultHistory = new List<Dictionary<Result, int>>();
    }
    
    public void NewRound() {
        GuessHistory.Clear();
        ResultHistory.Clear();
        int disk = UnityEngine.Random.Range(0, PossibleDisks.Count);
        CurrentDisk = PossibleDisks[disk];
        NumTags = CurrentDisk.Tags.Length;
        TurnsLeft = MaxTurns;
        CheckResult = false;
    }

    public void SubmitGuess(Tag[] tags) {
        var result = new Dictionary<Result, int>  { { Result.CORRECT, 0 }, 
                                                    { Result.PARTIAL, 0 }, 
                                                    { Result.INCORRECT, 0 } };

        List<Tag> tagList = new List<Tag>(CurrentDisk.Tags);
        for (int i = 0; i < CurrentDisk.Tags.Length; i++) {
            if (tags[i] == CurrentDisk.Tags[i]) {
                result[Result.CORRECT]++;
            } else if (tagList.Contains(tags[i])) {
                result[Result.PARTIAL]++;
            } else {
                result[Result.INCORRECT]++;
            }
        }
        GuessHistory.Add(tags);
        ResultHistory.Add(result);
        if (result[Result.CORRECT] == NumTags) {
            CorrectGuess();
        } else {
            IncorrectGuess();
            TurnsLeft --;
        }

        if (TurnsLeft == 0) {
            RoundLose();
        }
    }

    public void RoundLose() {
        OnRoundLose?.Invoke(CurrentDisk);
    }

    public void CorrectGuess() {
        OnCorrectGuess?.Invoke(CurrentDisk);
    }

    public void IncorrectGuess() {
        OnIncorrectGuess?.Invoke();
    }
}
