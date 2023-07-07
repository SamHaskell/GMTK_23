using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics.Tracing;
using TMPro.EditorUtilities;
using System.IO;

public class PickableSprite : MonoBehaviour, IDragHandler, IDropHandler
{
    private Image _image;
    private Vector3 _origin;
    public GameObject Model;
    void Start()
    {
        _image = GetComponent<Image>();
        _origin = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.position = _origin;
        Debug.Log("Released!");
    }

    void Update()
    {

    }
}
