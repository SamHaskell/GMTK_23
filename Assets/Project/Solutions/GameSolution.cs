using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//TODO: Replace with the actual tags we want to use.
public enum Tag {
    A, B, C, D, E, F
}

[CreateAssetMenu, ]
public class GameSolution : ScriptableObject 
{
    public List<Tag> Tags;
}
