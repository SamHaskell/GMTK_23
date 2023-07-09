using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LaunchableTagButton : MonoBehaviour
{
    private Image _image;
    private Vector3 _origin;
    private GameObject _clone;
    private Color _baseColor;
    public GameObject Model;
    public float LaunchSpeed;
    public TagData TagData;
    public bool _available;
    #if UNITY_EDITOR
        void OnValidate()
        {
            // GetComponentInChildren<TMP_Text>().text = TagData.Name;
            // transform.Find("Icon").GetComponentInChildren<Image>().sprite = TagData.TagSprite;
        }
    #endif

    public void MarkAsUsed()
    {
        _available = false;
        transform.GetComponent<Image>().color = Color.white;
    }

    public void MarkAsFree()
    {
        _available = true;
        transform.GetComponent<Image>().color = _baseColor;
    }

    void Awake()
    {
        _available = true;
        _image = GetComponent<Image>();
        _origin = transform.position;
        _baseColor = transform.GetComponent<Image>().color;
    }

    public void OnPress()
    {
        if (_available) {
            _clone = Instantiate(gameObject, transform.position, Quaternion.identity, transform.root);
        }
    }

    public void OnDrag()
    {
        if (_available) {
            Vector2 pos = InputManager.MousePosition;
            _clone.transform.position = pos;
        }
    }

    public void OnRelease()
    {
        if (_available) {
            AudioManager.instance.PlaySound("throw");
            Vector2 pos = InputManager.MousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            GameObject newObject = Instantiate(Model, ray.origin + ray.direction * 0.5f, Quaternion.identity);
            newObject.GetComponent<TagCollider>().Tag = TagData.Tag;
            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = ray.direction * LaunchSpeed;
            rb.angularVelocity = new Vector3(
                Random.Range(-15f, 15f),
                Random.Range(-15f, 15f),
                Random.Range(-15f, 15f)
            );
            Destroy(_clone);
            newObject.GetComponent<TagCollider>().StartSelfDestruct();
        }
    }
}
