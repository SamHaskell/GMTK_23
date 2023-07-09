using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    public bool CheckResult;
    public SolutionData SolutionData;
    public int CustomerPatience;
    public List<Tag[]> GuessHistory;
    public List<Dictionary<Result, int>> GuessResult;
    private Mastermind _customerMastermind;
    public int SetSize;
    private Tag[] _tagsForMakeGuess;


    private void Start() {
        GuessHistory = new();
        GuessResult = new();
        _customerMastermind = new Mastermind(SolutionData, CustomerPatience);
        SetSize = SolutionData.Tags.Length;
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
        // Debug.Log((int)guess[0]);
        // Debug.Log((int)guess[1]);
        // Debug.Log((int)guess[2]);
        // Debug.Log((int)guess[3]);
    }
    public void CheckResultFlag() {
        if (!CheckResult) {
            CheckResult = true;
        }
    }

    public void CheckMastermindResult()
    {
        Dictionary<Result, int> result = _customerMastermind.CheckResult();
        GuessResult.Add(result);
        Debug.Log(result[Result.CORRECT]);
        Debug.Log(result[Result.PARTIAL]);
        Debug.Log(result[Result.INCORRECT]);
        CheckResult = false;
    }

}
