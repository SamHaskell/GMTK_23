using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITagble 
{
    public enum Tag
    {
        NONE,
        ACTION,
        ADVENTURE,
        SHOOTER,
        MYSTERY,
        FIGHTING,
        PUZZLE,
        RPG,
        STEALTH,
        PLATFORMER,
        STRATEGY
    }
    public Tag GetTag();
}
