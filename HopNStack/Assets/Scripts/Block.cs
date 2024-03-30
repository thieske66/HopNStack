using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3 Dimensions = Vector3.one;
    public Transform MeshTransform;

    private void Awake()
    {
        MeshTransform = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
    }

    public void UpdateMesh()
    {
        MeshTransform.transform.parent = this.transform;
        MeshTransform.transform.localRotation = Quaternion.identity;
        MeshTransform.transform.localScale = Dimensions;
        MeshTransform.transform.localPosition = Vector3.up * Dimensions.y / 2f + Vector3.back * Dimensions.z / 2f;
    }

    public void SetDimensions(Vector3 dimensions)
    {
        Dimensions = dimensions;
        UpdateMesh();
    }
}
