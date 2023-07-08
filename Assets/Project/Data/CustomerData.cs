
using UnityEngine;


[CreateAssetMenu(fileName = "New Customer", menuName = "Customer/New Customer Data")]
public class CustomerData : ScriptableObject
{
    public GameObject CustomerModel;
    public SolutionData CustomerSolutionData;
    public int CustomerPatience;
}
