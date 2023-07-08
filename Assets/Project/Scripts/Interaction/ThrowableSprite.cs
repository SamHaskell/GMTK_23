using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThrowableSprite : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Image _image;
    private Vector3 _origin;
    private Vector3 _armVelocity;
    private Vector3 _prevArmPos;
    private Vector3 _dampVel;
    public GameObject Model;
    public Vector2 HorizontalThrowStrengthBounds;
    public Vector2 VerticalThrowStrengthBounds;
    public float LongitudinalThrowStrength;
    void Start()
    {
        _image = GetComponent<Image>();
        _origin = transform.position;
    }

    void Update()
    {
        Vector2 pos = InputManager.MousePosition;
        Ray ray = Camera.main.ScreenPointToRay(pos);
        Vector3 currArmPos = ray.origin + ray.direction * 2.0f;
        _armVelocity = Vector3.SmoothDamp(currArmPos - _prevArmPos, _armVelocity, ref _dampVel, 0.33f);
        Debug.Log(_armVelocity);
        _prevArmPos = currArmPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 delta = InputManager.MouseDelta;
        Vector2 pos = InputManager.MousePosition;
        Vector2 velocity;

        velocity.x = Mathf.Lerp(HorizontalThrowStrengthBounds.x, HorizontalThrowStrengthBounds.y, Mathf.Abs(delta.x));
        velocity.y = Mathf.Lerp(VerticalThrowStrengthBounds.x, VerticalThrowStrengthBounds.y, Mathf.Abs(delta.y));

        Ray ray = Camera.main.ScreenPointToRay(pos);
        GameObject newObject = Instantiate(Model, ray.origin + ray.direction * 2.0f, Quaternion.identity);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * LongitudinalThrowStrength + Vector3.right * _armVelocity.x + Vector3.up * _armVelocity.y;
        
        transform.position = _origin;
    }
}
