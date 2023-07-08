using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    public bool CheckResult;
    public CustomerData MyCustomerData;
    public List<List<Tag>> GuessHistory;
    public List<Dictionary<Result, int>> GuessResult;
    //public Rigidbody CustomerRigidbody;
    private Mastermind _customerMastermind;
    private int _setSize;
    private List<Tag> _tagsForMakeGuess;


    private void Start()
    {
        GuessHistory = new();
        GuessHistory = new();
        _customerMastermind = new Mastermind(MyCustomerData.CustomerSolutionData, MyCustomerData.CustomerPatience);
        _setSize = MyCustomerData.CustomerSolutionData.Tags.Count;
        _tagsForMakeGuess = new List<Tag>(_setSize);
        CheckResult = false;
    }

    public void OnTagHit(Tag colliderTag)
    {
        _tagsForMakeGuess.Add(colliderTag);
        if(_tagsForMakeGuess.Count >= _setSize)
        {
            _customerMastermind.MakeGuess(_tagsForMakeGuess);
            CheckResultFlag();
            GuessHistory.Add(_tagsForMakeGuess);
            _tagsForMakeGuess.Clear();
        }
    }

    public void CheckResultFlag()
    {
        if (!CheckResult)
        {
            CheckResult = true;
        }
    }

    public void CheckMastermindResult()
    {
        GuessResult.Add(_customerMastermind.CheckResult());
        CheckResult = false;
    }

}
