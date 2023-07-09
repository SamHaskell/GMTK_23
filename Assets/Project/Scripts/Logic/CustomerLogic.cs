using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CustomerLogic : MonoBehaviour
{
    public bool CheckResult;
    public List<SolutionData> PossibleSolutions;
    public SolutionData SolutionData;
    public int CustomerPatience;
    public List<Tag[]> GuessHistory { get; private set; }
    public List<Dictionary<Result, int>> GuessResult { get; private set; }
    private Mastermind _customerMastermind;
    public int SetSize;
    public int TurnsLeft;
    private Tag[] _tagsForMakeGuess;


    private void Start() {
        GuessHistory = new List<Tag[]>();
        GuessResult = new List<Dictionary<Result, int>>();
        
        SetSize = SolutionData.Tags.Length;
        TurnsLeft = CustomerPatience;

        _customerMastermind = new Mastermind(SolutionData, CustomerPatience);
        _tagsForMakeGuess = new Tag[SetSize];
        
        CheckResult = false;
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
        return isSuccess;
    }

}
