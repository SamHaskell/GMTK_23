using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorAnim : MonoBehaviour
{
    public Texture2D IdleSprite;
    public Texture2D ClickSprite;
    private Image _image;
    void Awake()
    {
        Cursor.SetCursor(IdleSprite, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        if (InputManager.MouseDown) {
            Cursor.SetCursor(ClickSprite, Vector2.zero, CursorMode.Auto);
        } else {
            Cursor.SetCursor(IdleSprite, Vector2.zero, CursorMode.Auto);
        }
    }
}
