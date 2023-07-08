using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        Vector2 delta = InputManager.MouseDelta;
        Vector2 pos = InputManager.MousePosition;

        GameObject newObject = Instantiate(Model, Camera.main.ScreenToWorldPoint(pos), Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * 3.0f + Camera.main.transform.right * delta.x + Camera.main.transform.up * delta.y;
        
        transform.position = _origin;
    }

    void Update()
    {

    }
}
