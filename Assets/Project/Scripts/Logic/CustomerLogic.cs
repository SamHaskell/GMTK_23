using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    public bool CheckResult;
    public List<SolutionData> PossibleSolutions;
    public SolutionData SolutionData;
    public int CustomerPatience;
    public List<Tag[]> GuessHistory;
    public List<Dictionary<Result, int>> GuessResult;
    private Mastermind _customerMastermind;
    public int SetSize;
    public int TurnsLeft;
    private Tag[] _tagsForMakeGuess;


    private void Start() {
        GuessHistory = new();
        GuessResult = new();
        _customerMastermind = new Mastermind(SolutionData, CustomerPatience);
        SetSize = SolutionData.Tags.Length;
        TurnsLeft = CustomerPatience;
        _tagsForMakeGuess = new Tag[SetSize];
        CheckResult = false;
    }

    public void OnTagHit(Tag tag, int idx) {
        _tagsForMakeGuess[idx] = tag;
    }

    public void SubmitGuess(Tag[] guess)
    {
        _customerMastermind.MakeGuess(guess);
        CheckResultFlag();
        GuessHistory.Add(guess);
        TurnsLeft --;
    }
    
    public void CheckResultFlag() {
        if (!CheckResult) {
            CheckResult = true;
        }
    }

    public bool CheckMastermindResult()
    {
        bool isSuccess = false;
        Dictionary<Result, int> result = _customerMastermind.CheckResult();
        GuessResult.Add(result);
        CheckResult = false;
        return isSuccess;
    }

}
