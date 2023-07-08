using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Targets") {
            coll.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        }
    }
}
