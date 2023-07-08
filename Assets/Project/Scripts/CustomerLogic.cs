using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    public CustomerData MyCustomerData;
    //public Rigidbody CustomerRigidbody;
    private Mastermind _customerMastermind;
    private int _setSize;
    private List<Tag> _tagsForMakeGuess;


    private void Start()
    {
        _customerMastermind = new Mastermind(MyCustomerData.CustomerSolutionData, MyCustomerData.CustomerPatience);
        _setSize = MyCustomerData.CustomerSolutionData.Tags.Count;
        _tagsForMakeGuess = new List<Tag>(_setSize);
    }

    private void OnCollisionEnter(Collision collision)
    {

        ITagged colliderTagble = collision.collider.GetComponent<ITagged>();
        _tagsForMakeGuess.Add(colliderTagble.GetTag());
        if(_tagsForMakeGuess.Count >= _setSize)
        {
            _customerMastermind.MakeGuess(_tagsForMakeGuess);
            _customerMastermind.CheckResult();
            _tagsForMakeGuess.Clear();
        }
    }

    
}
