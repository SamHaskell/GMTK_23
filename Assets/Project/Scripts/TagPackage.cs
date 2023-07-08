using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPackage : MonoBehaviour, ITagble
{
    public TagData PackageTagData;

    public ITagble.Tag GetTag()
    {
        return PackageTagData.GetTag();
    }
}
