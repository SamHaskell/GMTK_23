using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public Sprite CorrectResult;
    public Sprite PartialResult;
    public Sprite WrongResult;
    void Start()
    {
        
    }
    void Update()
    {
        if (GameManager.Instance.CustomerLogicObject.GuessResult.Count != 0) {
            Dictionary<Result, int> lastResult = GameManager.Instance.CustomerLogicObject.GuessResult[^1];
            int counter = 0;
            for (int i = 0; i < lastResult[Result.CORRECT]; i++) {
                transform.GetChild(counter).GetComponent<Image>().sprite = CorrectResult;
                counter ++;
                if (counter == 4) {
                    return;
                }
            }
            for (int i = 0; i < lastResult[Result.PARTIAL]; i++) {
                transform.GetChild(counter).GetComponent<Image>().sprite = PartialResult;
                counter ++;
                if (counter == 4) {
                    return;
                }
            }
            for (int i = 0; i < lastResult[Result.INCORRECT]; i++) {
                transform.GetChild(counter).GetComponent<Image>().sprite = WrongResult;
                counter ++;
                if (counter == 4) {
                    return;
                }
            }
        }
    }
}
