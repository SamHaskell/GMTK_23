using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public enum Result {
    INCORRECT,
    PARTIAL,
    CORRECT
}

public class Mastermind {
    public List<List<Result>> GuessHistory; // Can change, depending on what UI needs
    public List<Tag> SolutionTags; // Tag list for the current game solution
    public List<Tag> KnownTags; // Tag list for tags known to player on current guess
    public int TurnsLeft;
    public Mastermind(GameSolution solution, int turns)
    {
        this.SolutionTags = solution.Tags;
        foreach (Tag tag in SolutionTags) {
            this.KnownTags.Add(Tag.NONE);
        }
        this.TurnsLeft = turns;
    }
    public void MakeGuess(List<Tag> tags)
    {
        List<Result> guess = new List<Result>();
        for (int i = 0; i < SolutionTags.Count(); i++) {
            if (tags[i] == SolutionTags[i]) {
                guess.Add(Result.CORRECT);
                KnownTags[i] = SolutionTags[i];
            } else if (SolutionTags.Contains(tags[i])) {
                guess.Add(Result.PARTIAL);
            } else {
                guess.Add(Result.INCORRECT);
            }
        }
        GuessHistory.Add(guess);
        TurnsLeft --;
    }

    public void 
}
