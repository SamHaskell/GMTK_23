using UnityEngine;

public class RotateSlowly : MonoBehaviour
{
    void Update()
    {
        var eulers = transform.rotation.eulerAngles;
        eulers += new Vector3(1.1f, 0.5f, 0.8f) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(eulers);
    }
}
