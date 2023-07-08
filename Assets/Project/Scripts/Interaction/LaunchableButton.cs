using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class LaunchableButton : MonoBehaviour
{
    private Image _image;
    private Vector3 _origin;
    public GameObject Model;
    public float LaunchSpeed;
    public Vector3 LaunchVelocity { get; private set; }
    void Start()
    {
        _image = GetComponent<Image>();
        _origin = transform.position;
    }

    public void OnPress()
    {

    }

    public void OnDrag()
    {
        transform.position = InputManager.MousePosition;
    }

    public void OnRelease()
    {
        Vector2 pos = InputManager.MousePosition;

        Ray ray = Camera.main.ScreenPointToRay(pos);
        GameObject newObject = Instantiate(Model, ray.origin + ray.direction * 2.0f, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        LaunchVelocity = ray.direction * LaunchSpeed;
        rb.velocity = LaunchVelocity;
        transform.position = _origin;
    }
}
