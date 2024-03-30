using CustomAttributes;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody Rigidbody;

    [Button("Jump")]
    public bool DoJump = false;

    public float JumpForce = 1f;
    public Stack Stack;

    

    public void Jump()
    {
        Debug.Log("Do jump");
        Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    public void Fall()
    {
        Debug.Log("Do fall");
        Rigidbody.constraints = RigidbodyConstraints.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        Stack.SpawnNewBlock();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
