using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 5;
    public float speed = 5;
    public float jumpSpeed = 10;
    public Vector3 gravityVelocity;
    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Vector3 move = input * speed * Time.deltaTime;

        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            gravityVelocity = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravityVelocity = Vector3.up * jumpSpeed * Time.deltaTime;
            }
        }
        gravityVelocity += Vector3.down * Time.deltaTime;

        controller.Move(move + gravityVelocity);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Water")
        {
            gravity = 3;
            speed = 2.5f;
            jumpSpeed = 7;
            gravityVelocity += Vector3.down * Time.deltaTime;
        }
        if (hit.transform.tag == "Ground")
        {
            gravity = 5;
            speed = 5;
            jumpSpeed = 10;
        }
    }
}