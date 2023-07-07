
using UnityEngine;


[CreateAssetMenu(fileName = "New Customer", menuName = "CustomerScriptableObject/New Customer")]
public class CustomerScriptableObject : ScriptableObject
{
    [SerializeField] private GameObject customerModel;
    [SerializeField] private GameSolution gameTitle;
    [SerializeField] private int customerPatience;

    public GameObject CustomerModel { get => customerModel; set => customerModel = value; }
    public GameSolution GameTitle { get => gameTitle; set => gameTitle = value; }
    public int CustomerPatience { get => customerPatience; set => customerPatience = value; }
}
