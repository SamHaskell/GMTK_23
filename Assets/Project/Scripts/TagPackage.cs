using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPackage : MonoBehaviour, ITagged
{
    public TagData PackageTagData;

    public Tag GetTag()
    {
        return PackageTagData.GetTag();
    }
}
