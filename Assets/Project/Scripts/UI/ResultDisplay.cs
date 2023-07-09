using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

public class ResultDisplay : MonoBehaviour
{
    public Sprite CorrectResult;
    public Sprite PartialResult;
    public Sprite WrongResult;
    public void SetResult(Dictionary<Result, int> result) {
        int counter = 0;
        for (int i = 0; i < result[Result.CORRECT]; i++) {
            transform.GetChild(counter).GetComponent<Image>().sprite = CorrectResult;
            counter ++;
            if (counter == 3) {
                return;
            }
        }
        for (int i = 0; i < result[Result.PARTIAL]; i++) {
            transform.GetChild(counter).GetComponent<Image>().sprite = PartialResult;
            counter ++;
            if (counter == 3) {
                return;
            }
        }
        for (int i = 0; i < result[Result.INCORRECT]; i++) {
            transform.GetChild(counter).GetComponent<Image>().sprite = WrongResult;
            counter ++;
            if (counter == 3) {
                return;
            }
        }
    }
}
