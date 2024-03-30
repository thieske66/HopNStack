using CustomAttributes;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody Rigidbody;

    [Button("Jump")]
    public bool DoJump = false;

    public float JumpForce = 1f;
    public Stack Stack;

    public bool Standing = true;

    public BoxCollider FeetCollider;
    public BoxCollider BodyCollider;
    public CapsuleCollider RollCollider;

    public bool SafeLanding = false;

    private void Awake()
    {
        RollCollider.enabled = false;
    }

    public void Jump()
    {
        Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        SafeLanding = false;
    }

    public void Fall()
    {
        Rigidbody.constraints = RigidbodyConstraints.None;

        FeetCollider.enabled = false;
        BodyCollider.enabled = false;
        RollCollider.enabled = true;

        Standing = false;

        Stack.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check correct landing
        //yes, continue
        //No, fall

        if (Standing)
        {
            Stack.SpawnNewBlock();
            SafeLanding = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 6)
        {
            return;
        }

        Debug.Log("collision");
        if (Standing && !SafeLanding)
        {
            Fall();
        }
        SafeLanding = false;

        
    }
}
