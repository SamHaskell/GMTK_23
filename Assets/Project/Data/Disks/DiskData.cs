using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDisk", menuName = "Data/New Disk")]
public class DiskData : ScriptableObject
{
    public string Title;
    public Tag[] Tags;
    public GameObject Model;
    public Texture2D BoxArt;
}
