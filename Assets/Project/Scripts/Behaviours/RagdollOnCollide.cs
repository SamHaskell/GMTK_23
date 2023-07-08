using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnCollide : MonoBehaviour
{
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        _rb.isKinematic = false;
        if (collision.gameObject.tag == "Target") {
            _rb.AddForceAtPosition(collision.relativeVelocity, collision.transform.position, ForceMode.Impulse);
        }
    }
}
