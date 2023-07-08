using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using System.Xml;

public class LaunchableButton : MonoBehaviour
{
    private Image _image;
    private Vector3 _origin;
    private GameObject _clone;
    public GameObject Model;
    public float LaunchSpeed;
    public 
    void Start()
    {
        _image = GetComponent<Image>();
        _origin = transform.position;
    }

    public void OnPress()
    {
        _clone = Instantiate(gameObject, transform.position, Quaternion.identity, transform.parent.parent);
    }

    public void OnDrag()
    {
        Vector2 pos = InputManager.MousePosition;
        _clone.transform.position = pos;
    }

    public void OnRelease()
    {
        Vector2 pos = InputManager.MousePosition;
        Ray ray = Camera.main.ScreenPointToRay(pos);
        GameObject newObject = Instantiate(Model, ray.origin + ray.direction * 0.5f, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = ray.direction * LaunchSpeed;
        rb.angularVelocity = new Vector3(
            Random.Range(-15f, 15f),
            Random.Range(-15f, 15f),
            Random.Range(-15f, 15f)
        );
        Destroy(_clone);
    }
}
