using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagCollider : MonoBehaviour
{
    public Tag Tag;
    public TagController Controller;
    public int Order;
    private Rigidbody _rb;
    public bool HasCollided;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        HasCollided = false;
    }
    
    void Update()
    {
        
    }

    public void StartSelfDestruct()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (HasCollided) {
            return;
        }

        if (collision.gameObject.tag != "Target") {
            return;
        }

        HasCollided = true;

        _rb.isKinematic = false;
        _rb.useGravity = true;
        
        _rb.AddForceAtPosition(collision.relativeVelocity, collision.transform.position, ForceMode.Impulse);
        collision.gameObject.GetComponent<Collider>().enabled = false;

        AudioManager.instance.PlaySound("explosion");

        if (Tag != Tag.NONE) {
            if (Controller != null) {
                Controller.OnTagHit(gameObject, collision.gameObject.GetComponent<TagCollider>().Tag, this.Order);
            }
        }
    }
}
