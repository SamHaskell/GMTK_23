using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FeedbackDisplay : MonoBehaviour
{
    private List<GameObject> _feedbackPanels;
    public GameObject PanelPrefab;
    void Awake()
    {
        _feedbackPanels = new();
    }
    public void AddResult(Tag[] guess, Dictionary<Result, int> result)
    {
        GameObject panel = Instantiate(PanelPrefab, this.transform);
        GuessDisplay gd = panel.GetComponentInChildren<GuessDisplay>();
        gd.SetGuess(guess);
        ResultDisplay rd = panel.GetComponentInChildren<ResultDisplay>();
        rd.SetResult(result);
        _feedbackPanels.Add(panel);
    }
    public void ClearResults()
    {
        if (_feedbackPanels.Count == 0) {
            return;
        }
        foreach (GameObject panel in _feedbackPanels) {
            Destroy(panel);
        }
        _feedbackPanels.Clear();
    }

    void OnDisable()
    {
        ClearResults();
    }
}
