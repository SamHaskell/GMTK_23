using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningFloppy : MonoBehaviour
{
    public Vector3 DisplacementAmplitudes;
    public Vector3 DisplacementFrequencies;
    private Vector3 _origin;
    private float _time;
    void Start()
    {
        _origin = transform.position;
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        Vector3 displacement = new Vector3(
            DisplacementAmplitudes.x * Mathf.Sin(_time * DisplacementFrequencies.x),
            DisplacementAmplitudes.y * Mathf.Sin(_time * DisplacementFrequencies.y),
            DisplacementAmplitudes.z * Mathf.Sin(_time * DisplacementFrequencies.z)
        );
        transform.position = _origin + displacement;
        
    }
}
