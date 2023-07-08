using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITagble 
{
    public enum Tag
    {
        NONE, A, B, C, D, E, F
    }
    public Tag GetTag();
}
