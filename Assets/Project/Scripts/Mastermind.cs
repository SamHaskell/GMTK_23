using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Result {
    INCORRECT,
    PARTIAL,
    CORRECT
}

public class Mastermind {
    public List<List<Result>> GuessHistory; // Can change, depending on what UI needs
    public List<ITagble.Tag> SolutionTags; // Tag list for the current game solution
    public List<ITagble.Tag> KnownTags; // Tag list for tags known to player on current guess
    public int TurnsLeft;
    public Dictionary<Result, int> GuessResult;


    public Mastermind(SolutionData solution, int turns)
    {
        this.KnownTags = new();
        GuessHistory = new();
        this.SolutionTags = solution.Tags;
        foreach (ITagble.Tag tag in SolutionTags) {
            this.KnownTags.Add(ITagble.Tag.NONE);
        }
        this.TurnsLeft = turns;
    }

    public void MakeGuess(List<ITagble.Tag> tags)
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

    public void CheckResult()
    {
        GuessResult = new Dictionary<Result, int> { {Result.CORRECT, 0 }, 
                                                    { Result.PARTIAL, 0 }, 
                                                    { Result.INCORRECT, 0 } 
                                                    };
        List<Result> LastGuess = GuessHistory.Last();

        foreach (Result result in LastGuess)
        {
            switch (result)
            {
                case Result.INCORRECT:
                    GuessResult[Result.INCORRECT]++;
                    break;
                case Result.PARTIAL:
                    GuessResult[Result.PARTIAL]++;
                    break;
                case Result.CORRECT:
                    GuessResult[Result.CORRECT]++;
                    break;
            }
        }

 
    }

}
