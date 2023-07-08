using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class TagController : MonoBehaviour
{
    public GameObject TagPrefab;
    public int NumTags;
    public List<Transform> TagTargets;
    public List<TagData> TagData;
    private List<GameObject> _tagsHit;
    private List<GameObject> _tagsLeft;

    void Start()
    {
        _tagsLeft = new List<GameObject>();
        _tagsHit = new List<GameObject>();
        SpawnTags();
    }
    void DestroyTags()
    {
        foreach (GameObject tag in _tagsLeft) {
            Destroy(tag);
        }
        _tagsLeft.Clear();
        foreach (GameObject tag in _tagsHit) {
            Destroy(tag);
        }
        _tagsHit.Clear();
    }
    void SpawnTags()
    {
        for (int i = 0; i < NumTags; i++) {
            GameObject tag = Instantiate(TagPrefab, TagTargets[i].position, TagTargets[i].rotation);
            tag.GetComponent<TagCollider>().Controller = this;
            tag.GetComponent<TagPackage>().TagData = TagData[0];
            _tagsLeft.Add(tag);
        }
    }
    void Update()
    {
        if (_tagsLeft.Count == 0) {
            DestroyTags();
            SpawnTags();
        }  
    }

    public void OnTagHit(GameObject tag, Tag guess)
    {
        if (tag.GetComponent<TagPackage>().GetTag() == guess) {
            Debug.Log("Poggers");
        }
        _tagsHit.Add(tag);
        _tagsLeft.Remove(tag);
    }
}
