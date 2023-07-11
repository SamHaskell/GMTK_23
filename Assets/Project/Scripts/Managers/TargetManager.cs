using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {
    public GameObject TargetPrefab;
    public DiskData CurrentDisk;
    public int NumTags;
    public List<Transform> TargetTransforms;
    private GameObject[] _targets;
    private Tag[] _guess;
    private int _targetsHit;

    public event Action<Tag[]> OnGuess;
    public event Action<Tag> OnTargetHit;

    void Start() {
        SpawnTags();
    }

    public void ResetTags()
    {
        DestroyTags();
        SpawnTags();
    }

    void DestroyTags() {
        foreach (GameObject tag in _targets) {
            Destroy(tag);
        }
    }
    
    public void SpawnTags() {
        _targets = new GameObject[NumTags];
        _guess = new Tag[NumTags];
        _targetsHit = 0;
        for (int i = 0; i < NumTags; i++) {
            _targets[i] = Instantiate(TargetPrefab, TargetTransforms[i].position, TargetTransforms[i].rotation);
            _targets[i].GetComponent<TagCollider>().TargetManager = this;
            _targets[i].GetComponent<TagCollider>().Tag = CurrentDisk.Tags[i];
            _targets[i].GetComponent<TagCollider>().Order = i;
        }
    }

    IEnumerator OnSubmitGuess(Tag[] guess)
    {
        OnGuess?.Invoke(guess);
        yield return new WaitForSeconds(2.0f);
        ResetTags();
    }

    IEnumerator SelfDestruct(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        Destroy(this.gameObject);
    }

    public void OnHit(GameObject tag, Tag guess, int order)
    {
        _guess[order] = guess;
        _targetsHit ++;
        OnTargetHit?.Invoke(guess);
        if (_targetsHit == NumTags) {
            _targetsHit = 0;
            StartCoroutine(OnSubmitGuess(_guess));
        }
    }
}
