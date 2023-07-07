using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mastermind {
    public List<Tag> Tags;
    public int TurnsLeft;
    public Mastermind(GameSolution solution, int turns)
    {
        this.Tags = solution.Tags;
        this.TurnsLeft = turns;
    }

    public void MakeGuess(List<Tag> tags)
    {
        TurnsLeft --;
    }
}
