using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDriver : MonoBehaviour
{

    public Transform headIKTarget;
    public Transform bone;
    public float driveForce;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // bone.transform.localRotation = Quaternion.Euler(jointDriver.currentDirection);
        bone.transform.localRotation = Quaternion.Slerp(bone.transform.localRotation, Quaternion.Euler((bone.transform.position-headIKTarget.transform.position)*100f), Time.deltaTime * driveForce);
        // bone.transform.localRotation = Quaternion.Euler((bone.transform.position-headIKTarget.transform.position)*100f);
    }
}
