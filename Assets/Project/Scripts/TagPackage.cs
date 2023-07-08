using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPackage : MonoBehaviour, ITagged
{
    public TagData TagData;

    public Tag GetTag()
    {
        return TagData.Tag;
    }
}
