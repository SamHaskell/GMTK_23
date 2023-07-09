using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    // Nothing wrong with public variables, just hide from inspector where possible and make them pascal-case.
    public float ExamplePublicVariable;
    // Even better, make a property.
    public Vector3 ExampleProperty { get; private set; }
    // Private fields should be camel-case prefixed with _ to distinguish them.
    private Rigidbody _examplePrivateComponent;
    
    void Awake()
    {
        // NOTE: Do this in Awake if possible ...
        _examplePrivateComponent = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Print("I love naming conventions!");
    }

    void Update()
    {
        
    }

    // NOTE: Parameters in functions should be camelcase
    private void Print(string message)
    {
        Debug.Log(message);
    }
}
