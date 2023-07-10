using UnityEngine;

public class TagCollider : MonoBehaviour
{
    public Tag Tag;
    public TargetManager TargetManager;
    public int Order;
    public bool HasCollided;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        HasCollided = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (HasCollided || (collision.gameObject.tag != "Target")) {
            return;
        } else {
            HasCollided = true;
        }

        _rb.isKinematic = false;
        _rb.useGravity = true;
        _rb.AddForceAtPosition(collision.relativeVelocity, collision.transform.position, ForceMode.Impulse);
        collision.gameObject.GetComponent<Collider>().enabled = false;

        if (Tag != Tag.NONE) {
            if (TargetManager != null) {
                TargetManager.OnHit(gameObject, collision.gameObject.GetComponent<TagCollider>().Tag, this.Order);
            }
        }
        AudioManager.Instance.PlaySound("explosion");
    }
}
