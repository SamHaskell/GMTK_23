using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlowly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var eulers = transform.rotation.eulerAngles;
        eulers += new Vector3(1.1f, 0.5f, 0.8f) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(eulers);
    }
}
