using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tag", menuName = "Tag/New Tag Data")]
public class TagData : ScriptableObject
{
    public Tag Tag;
    public Sprite TagSprite;
    public Sprite TagBackground;
}
