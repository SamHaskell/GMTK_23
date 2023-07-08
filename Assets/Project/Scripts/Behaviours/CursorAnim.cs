using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorAnim : MonoBehaviour
{
    public Sprite IdleSprite;
    public Sprite ClickSprite;
    private Image _image;
    void Start()
    {
        _image = GetComponent<Image>();
        _image.enabled = true;
        _image.sprite = IdleSprite;
        Cursor.visible = false;
    }

    void OnEnable() {
        Cursor.visible = false;
    }
    void OnDisable() {
        Cursor.visible = true;
    }

    void Update()
    {
        if (InputManager.MouseDown) {
            _image.sprite = ClickSprite;
        } else {
            _image.sprite = IdleSprite;
        }
    }
}
