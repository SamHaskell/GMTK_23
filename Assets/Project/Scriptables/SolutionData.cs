using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//TODO: Replace with the actual tags we want to use.

public enum Tag {
    NONE, A, B, C, D, E, F
}

[CreateAssetMenu(fileName = "New Solution", menuName = "Solution/New Solution Data")]
public class SolutionData : ScriptableObject 
{
    public string Title;
    public List<Tag> Tags;
}
