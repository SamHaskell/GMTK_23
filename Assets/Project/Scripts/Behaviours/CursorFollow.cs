using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorFollow : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Image>().enabled = false;
    }
    void Update()
    {
        transform.position = InputManager.MousePosition;    
    }
}
