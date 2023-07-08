using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tag", menuName = "Tag/New Tag Data")]
public class TagData : ScriptableObject, ITagged
{
    public Tag MyTag;
    public Sprite TagSprite;
    public Sprite TagBackground;

    public Tag GetTag()
    {
        return MyTag;
    }
}
