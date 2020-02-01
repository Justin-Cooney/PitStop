using UnityEngine;

//To be attached onto the object that can be picked up/dropped/placed
public class ObjectController : MonoBehaviour {

    public ObjectContainer container;
    public ObjectProperty property;
    private Transform tform;

    // Start is called before the first frame update
    void Start() {
        tform = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update() {
    }

    public ObjectType GetObjectType() {
        return container.type;
    }

    public bool CompareObjectType(ObjectType otherType) {
        return this.container.type == otherType;
    }

    public bool HasObjectProperty(ObjectProperty property) {
        return container.properties.Contains (property);
    }

    public void SnapObject(Transform snapToTransform) {
        tform.SetParent (snapToTransform);
    }

}
