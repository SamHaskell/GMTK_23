using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GuessDisplay : MonoBehaviour
{
    public Sprite[] Icons;
    public void SetGuess(Tag[] guess)
    {
        for (int i = 0; i < 3; i++) {
            transform.GetChild(i).GetComponent<Image>().sprite = Icons[(int)guess[i]];
        }
    }
}
