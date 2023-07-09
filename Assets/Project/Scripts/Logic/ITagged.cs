using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
    NONE,
    ACTION,
    ADVENTURE,
    SHOOTER,
    MYSTERY,
    INDIE,
    // PUZZLE,
    // RPG,
    // STEALTH,
    PLATFORMER,
    STRATEGY
}

public interface ITagged
{
    public Tag GetTag();
}
