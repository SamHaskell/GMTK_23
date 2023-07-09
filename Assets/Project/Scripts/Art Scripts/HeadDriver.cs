using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDriver : MonoBehaviour
{

    public Transform headIKTarget;
    public Transform bone;
    public float driveForce;
    public Texture2D[] expressions;
    public Faces face;
    [SerializeField]
    private float blinkTime = 6f;
    Material mat;

    // Start is called before the first frame update
    void Start(){
        mat = GetComponent<Material>();
        StartCoroutine(Blink());
    }
    // Update is called once per frame
    void Update()
    {
        // bone.transform.localRotation = Quaternion.Euler(jointDriver.currentDirection);
        bone.transform.localRotation = Quaternion.Slerp(bone.transform.localRotation, Quaternion.Euler((bone.transform.position-headIKTarget.transform.position)*100f), Time.deltaTime * driveForce);
        // bone.transform.localRotation = Quaternion.Euler((bone.transform.position-headIKTarget.transform.position)*100f);
        if(Quaternion.Angle(bone.transform.localRotation, Quaternion.Euler((bone.transform.position-headIKTarget.transform.position)*100f)) > 30f){
            StartCoroutine(SetExpression(face, 0.1f));
        }
        switch (face){
            case Faces.Relaxed:
                mat.mainTexture = expressions[(int)face];
                break;
            case Faces.Blink:
                mat.mainTexture = expressions[(int)face];
                break;
            case Faces.Happy:
                mat.mainTexture = expressions[(int)face];
                break;
            case Faces.Angry:
                mat.mainTexture = expressions[(int)face];
                break;
        }
    }
    IEnumerator Blink(){
        while(true){
        yield return new WaitForSeconds(Random.Range(blinkTime-2f, blinkTime+2f));
        if(face == Faces.Relaxed){
            face = Faces.Blink;
            yield return new WaitForSeconds(0.4f);
            face = Faces.Relaxed;
            }
        }
    }
    IEnumerator SetExpression(Faces face, float time){
        var oldFace = face;
        face = Faces.Blink;
        yield return new WaitForSeconds(time);
        face = oldFace;
    }
}
public enum Faces{
    Relaxed,
    Blink,
    Happy,
    Angry
}
