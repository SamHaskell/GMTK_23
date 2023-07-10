using UnityEngine;

public class JointDriver : MonoBehaviour
{
    private CharacterJoint _characterJoint;
    [SerializeField]
    private Vector3 _driveAxis;
    [SerializeField]
    private float _driveCoefficient;
    public Vector3 CurrentDirection;
    Vector3 _targetPos;
    private void Start()
    {
        _characterJoint = GetComponent<CharacterJoint>();
        _targetPos = _characterJoint.connectedBody.transform.position;
    }

    private void FixedUpdate()
    {

        // Calculate the desired rotation or position for the upright position
        Quaternion desiredRotation = Quaternion.identity; // Adjust as per your character's rig
        CurrentDirection = (_characterJoint.connectedBody.transform.position - transform.position).normalized;
        var drivenBody = _characterJoint.connectedBody;
        var driveForce = Vector3.Dot(CurrentDirection, _driveAxis) * _driveCoefficient;
        // drivenBody.AddForce(driveForce * driveAxis, ForceMode.Acceleration);
        
        drivenBody.AddForce(_driveCoefficient * ((_driveAxis + CurrentDirection)/2f), ForceMode.Acceleration);
    }
}
