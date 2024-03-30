using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    public Vector3 Dimensions = new Vector3(3f, 1f, 3f);
    public GameObject MeshObject;

    public BoxCollider Collider;
    public Rigidbody Rigidbody;

    public Vector3 Direction = Vector3.forward;
    public float Velocity = 1f;

    private void Awake()
    {       
        UpdateMesh();
    }

    public void UpdateMesh()
    {
        MeshObject.transform.parent = this.transform;
        MeshObject.transform.localRotation = Quaternion.identity;
        MeshObject.transform.localScale = Dimensions;
        Vector3 localPosition = Vector3.up * Dimensions.y / 2f + Vector3.back * Dimensions.z / 2f;
        MeshObject.transform.localPosition = localPosition;

        Collider.size = new Vector3(Dimensions.x, Dimensions.y * 0.5f, Dimensions.z);
        Collider.center = localPosition + Vector3.up * Dimensions.y * 0.25f;
    }

    public void SetDimensions(Vector3 dimensions)
    {
        Dimensions = dimensions;
        UpdateMesh();
    }

    private void FixedUpdate()
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 translation = Direction.normalized * Velocity * Time.fixedDeltaTime;
        Vector3 newPosition = currentPosition + translation;
        Rigidbody.MovePosition(newPosition);

    }
}
