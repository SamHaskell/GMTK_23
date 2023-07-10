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

    void Awake() {
    }
    void Start() {
        SpawnTags();
    }

    void DestroyTags() {
        foreach (GameObject tag in _targets) {
            Destroy(tag);
        }
    }
    
    void SpawnTags() {
        _targets = new GameObject[NumTags];
        _guess = new Tag[NumTags];
        Debug.Log(_guess.Length);
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
        DestroyTags();
        yield return new WaitForSeconds(2.0f);
        SpawnTags();
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
            Debug.Log(_guess[0]);
            Debug.Log(_guess[1]);
            Debug.Log(_guess[2]);
            StartCoroutine(OnSubmitGuess(_guess));
        }
    }
}
