using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class TagController : MonoBehaviour
{
    public GameObject TagPrefab;
    public List<Transform> TagTargets;
    public CustomerLogic CustomerLogicObject;
    private GameObject[] _tags;
    private Tag[] _guess;
    private int _tagsHit;

    void Start()
    {
        _tags = new GameObject[CustomerLogicObject.SetSize];
        _guess = new Tag[CustomerLogicObject.SetSize];
        SpawnTags();
    }
    void DestroyTags()
    {
        foreach (GameObject tag in _tags) {
            Destroy(tag);
        }
        _tags = new GameObject[CustomerLogicObject.SetSize];
        _guess = new Tag[CustomerLogicObject.SetSize];
    }
    void SpawnTags()
    {
        _tagsHit = 0;
        for (int i = 0; i < CustomerLogicObject.SetSize; i++) {
            _tags[i] = Instantiate(TagPrefab, TagTargets[i].position, TagTargets[i].rotation);
            _tags[i].GetComponent<TagCollider>().Controller = this;
            _tags[i].GetComponent<TagCollider>().Tag = CustomerLogicObject.SolutionData.Tags[i];
            _tags[i].GetComponent<TagCollider>().Order = i;
        }
    }

    IEnumerator OnSubmitGuess()
    {
        yield return new WaitForSeconds(2.0f);
        DestroyTags();
        SpawnTags();
    }

    IEnumerator SelfDestruct(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        Destroy(this.gameObject);
    }

    public void OnTagHit(GameObject tag, Tag guess, int order)
    {
        _guess[order] = guess;
        _tagsHit ++;
        GameManager.Instance.ButtonSwitcher.DisableButton(guess);
        Debug.Log("Temporarily Disabling");
        Debug.Log(guess);
        if (_tagsHit >= CustomerLogicObject.SetSize) {
            _tagsHit = 0;
            CustomerLogicObject.SubmitGuess(_guess);
            StartCoroutine(OnSubmitGuess());
        }
    }
}
