using UnityEngine;

public class JointDriver : MonoBehaviour
{
    private CharacterJoint characterJoint;
    [SerializeField]
    private Vector3 driveAxis;
    [SerializeField]
    private float driveCoefficient;
    public Vector3 currentDirection;
    Vector3 targetPos;
    // Start is called before the first frame update
    private void Start()
    {
        characterJoint = GetComponent<CharacterJoint>();
        targetPos = characterJoint.connectedBody.transform.position;
    }

    private void FixedUpdate()
    {

        // Calculate the desired rotation or position for the upright position
        Quaternion desiredRotation = Quaternion.identity; // Adjust as per your character's rig
        currentDirection = (characterJoint.connectedBody.transform.position - transform.position).normalized;
        var drivenBody = characterJoint.connectedBody;
        var driveForce = Vector3.Dot(currentDirection, driveAxis) * driveCoefficient;
        // drivenBody.AddForce(driveForce * driveAxis, ForceMode.Acceleration);
        
        drivenBody.AddForce(driveCoefficient * ((driveAxis+currentDirection)/2f), ForceMode.Acceleration);
    }
}
