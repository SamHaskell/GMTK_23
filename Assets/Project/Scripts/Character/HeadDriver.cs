using System.Collections;
using UnityEngine;

public class HeadDriver : MonoBehaviour
{

    public Transform HeadIKTarget;
    public Transform Bone;
    public Transform HeadMesh;
    public float DriveForce;
    public Texture2D[] Expressions;
    public Faces Face;
    [SerializeField]
    private float _blinkTime = 6f;
    Material _mat;

    // Start is called before the first frame update
    void Start(){
        _mat = HeadMesh.GetComponent<Renderer>().material;
        StartCoroutine(Blink());       
    }
    // Update is called once per frame
    void Update()
    {
        // bone.transform.localRotation = Quaternion.Euler(jointDriver.currentDirection);
        Bone.transform.localRotation = Quaternion.Slerp(Bone.transform.localRotation, Quaternion.Euler((Bone.transform.position - HeadIKTarget.transform.position)*100f), Time.deltaTime * DriveForce);
        // bone.transform.localRotation = Quaternion.Euler((bone.transform.position-headIKTarget.transform.position)*100f);
        if(Quaternion.Angle(Bone.transform.localRotation, Quaternion.Euler((Bone.transform.position - HeadIKTarget.transform.position)*100f)) > 30f){
            StartCoroutine(SetExpression(Face, 0.1f));
        }
        _mat.SetTexture("_Texture2D", Expressions[(int)Face]);
    }
    IEnumerator Blink(){
        while(true){
        yield return new WaitForSeconds(Random.Range(_blinkTime - 2f, _blinkTime + 2f));
        if(Face == Faces.Relaxed){
            Face = Faces.Blink;
            yield return new WaitForSeconds(0.2f);
            Face = Faces.Relaxed;
            }
        }
    }
    public void SetFace(Faces newFace, float time){
        StartCoroutine(SetExpression(newFace, time));
        // Debug.Log("Setting face.");
    }
    IEnumerator SetExpression(Faces newFace, float time){
        var oldFace = Faces.Relaxed; //lol
        Face = newFace;
        // Debug.Log(face);
        yield return new WaitForSeconds(time);
        Face = oldFace;
    }
}
public enum Faces{
    Relaxed,
    Blink,
    Happy,
    Angry
}
