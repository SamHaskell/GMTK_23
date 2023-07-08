using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagCollision : MonoBehaviour
{
    public TagController Controller;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collisionFlag = false;
    }
    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        _rb.isKinematic = false;
        if (collision.gameObject.tag == "Target") {
            _rb.AddForceAtPosition(collision.relativeVelocity, collision.transform.position, ForceMode.Impulse);
        }
        TagPackage tagPackage = collision.gameObject.GetComponent<TagPackage>();
        if (tagPackage != null) {
            if (Controller != null) {
                Controller.OnTagHit(gameObject, tagPackage.GetTag());
            }
        }
    }
}
