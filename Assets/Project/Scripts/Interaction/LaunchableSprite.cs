using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LaunchableSprite : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Image _image;
    private Vector3 _origin;
    public GameObject Model;
    public float LaunchSpeed;
    void Start()
    {
        _image = GetComponent<Image>();
        _origin = transform.position;
    }

    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 pos = InputManager.MousePosition;

        Ray ray = Camera.main.ScreenPointToRay(pos);
        GameObject newObject = Instantiate(Model, ray.origin + ray.direction * 2.0f, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = ray.direction * LaunchSpeed;

        transform.position = _origin;
    }
}
