using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyMovement : MonoBehaviour
{
    public Vector3 DisplacementAmplitudes;
    public Vector3 DisplacementFrequencies;
    private Vector3 _origin;
    private Vector3 _timeOffset;
    private float _time;
    void Start()
    {
        _origin = transform.position;
        _timeOffset = new Vector3(
            Random.Range(0.0f, 100.0f),
            Random.Range(0.0f, 100.0f),
            Random.Range(0.0f, 100.0f));
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        Vector3 displacement = new Vector3(
            DisplacementAmplitudes.x * Mathf.Sin((_time + _timeOffset.x) * DisplacementFrequencies.x),
            DisplacementAmplitudes.y * Mathf.Sin((_time + _timeOffset.y) * DisplacementFrequencies.y),
            DisplacementAmplitudes.z * Mathf.Sin((_time + _timeOffset.z) * DisplacementFrequencies.z)
        );
        transform.position = _origin + displacement;
        
    }
}
