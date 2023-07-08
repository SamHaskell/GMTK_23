using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    public CustomerData MyCustomerData;
    //public Rigidbody CustomerRigidbody;
    private Mastermind customerMastermind;
    private int setSize;
    private List<ITagble.Tag> tagsForMakeGuess;


    private void Start()
    {
        customerMastermind.TurnsLeft = MyCustomerData.CustomerPatience;
        customerMastermind.SolutionTags = MyCustomerData.CustomerSolutionData.Tags;
        setSize = MyCustomerData.CustomerSolutionData.Tags.Count;
        tagsForMakeGuess = new List<ITagble.Tag>(setSize);
    }

    private void OnCollisionEnter(Collision collision)
    {

        ITagble myTagble = collision.collider.GetComponent<ITagble>();
        Debug.Log(myTagble);
    }

    
}
