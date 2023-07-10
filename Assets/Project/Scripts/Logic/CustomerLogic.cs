using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    public bool CheckResult;
    public List<DiskData> PossibleDisks;
    public DiskData CurrentDisk;
    public int MaxTurns;
    public List<Tag[]> GuessHistory { get; private set; }
    public List<Dictionary<Result, int>> GuessResult { get; private set; }
    public int SetSize;
    public int TurnsLeft;
    private Mastermind _customerMastermind;
    private Tag[] _tagsForMakeGuess;


    private void Start() {
        GuessHistory = new List<Tag[]>();
        GuessResult = new List<Dictionary<Result, int>>();

        int sol = Random.Range(0, PossibleDisks.Count);
        CurrentDisk = PossibleDisks[sol];
        SetSize = CurrentDisk.Tags.Length;
        TurnsLeft = MaxTurns;
        _customerMastermind = new Mastermind(CurrentDisk, MaxTurns);
        _tagsForMakeGuess = new Tag[SetSize];
        
        CheckResult = false;
    }
    public void ResetCustomerLogic()
    {
        Start();
    }

    public void OnTagHit(Tag tag, int idx) {
        _tagsForMakeGuess[idx] = tag;
    }

    public void SubmitGuess(Tag[] guess)
    {
        GuessHistory.Add(guess);
        _customerMastermind.MakeGuess(guess);
        CheckResult = true;
        TurnsLeft --;
    }

    public bool CheckMastermindResult()
    {
        bool isSuccess = false;
        Dictionary<Result, int> result = _customerMastermind.CheckResult();
        GuessResult.Add(result);
        CheckResult = false;
        // need to check isSuccess and change it so that GameManager can detect a win.
        if (result[Result.CORRECT] == SetSize) {
            isSuccess = true;
        }
        return isSuccess;
    }

}
