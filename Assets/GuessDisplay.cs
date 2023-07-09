using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GuessDisplay : MonoBehaviour
{
    public Sprite[] Icons;
    void Start()
    {

    }
    void Update()
    {
        if (GameManager.Instance.CustomerLogicObject.GuessHistory.Count != 0) {
            Tag[] lastGuess = GameManager.Instance.CustomerLogicObject.GuessHistory[^1];
            for (int i = 0; i < 4; i++) {
                transform.GetChild(i).GetComponent<Image>().sprite = Icons[(int)lastGuess[i]];
            }
        }
    }
}
