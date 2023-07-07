
using UnityEngine;


[CreateAssetMenu(fileName = "New Customer", menuName = "Customer/New Customer Data")]
public class CustomerData : ScriptableObject
{
    [SerializeField] private GameObject customerModel;
    [SerializeField] private SolutionData gameTitle;
    [SerializeField] private int customerPatience;

    public GameObject CustomerModel { get => customerModel; set => customerModel = value; }
    public SolutionData GameTitle { get => gameTitle; set => gameTitle = value; }
    public int CustomerPatience { get => customerPatience; set => customerPatience = value; }
}
