using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTag", menuName = "Data/New Tag")]
public class TagData : ScriptableObject
{
    public string Name;
    public Tag Tag;
    public Sprite TagSprite;
    public Sprite TagSpriteInverted;
    public Sprite TagBackground;
}
