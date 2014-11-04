using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    public Camera playerCamera;
    public KeyBindings keyBinding;


    public float walkSpeed = 0.1f;
    public float runMultiplikator = 2.0f;

    public float rotatationSpeedLeftRight = 0.5f;
    public float rotationSpeedUpDown = 100.0f;

    public float minCameraAngel = -50.0f;
    public float maxCameraAngel = 50.0f;
    public float lookDirectionUpDown = 0;






    private float distanceToGround;


    // Use this for initialization
    void Start()
    {
        distanceToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        Jump();
        Move();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(keyBinding.keyMoveJump) && IsGrounded())
        {
            gameObject.rigidbody.AddForce(new Vector3(0, 10 * gameObject.rigidbody.mass, 0), ForceMode.Impulse);
        }
    }

    private bool IsGrounded() { return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);}

    private void MouseLook()
    {
        //Input.mousePosition.Set(Screen.width / 2, Screen.height / 2, 0);
        //Screen.lockCursor = true;

        lookDirectionUpDown += Input.GetAxisRaw("Mouse Y") * 100 * Time.deltaTime;
        lookDirectionUpDown = Mathf.Clamp(lookDirectionUpDown, minCameraAngel, maxCameraAngel);

        playerCamera.transform.localEulerAngles = (new Vector3(-lookDirectionUpDown, 0, 0));


        Vector3 characterRotation = this.transform.localEulerAngles;
        characterRotation.y += Input.GetAxisRaw("Mouse X") * rotatationSpeedLeftRight;
        this.transform.localEulerAngles = characterRotation;
    }

    private void Move()
    {
        float moveSpeed = walkSpeed;

        Vector3 newPos = this.transform.position;

        if (Input.GetKey(keyBinding.keyMoveRun) && Input.GetKey(KeyCode.W) && IsGrounded()) moveSpeed *= runMultiplikator;

        if (Input.GetKey(keyBinding.keyMoveForward)) { newPos += this.transform.forward * moveSpeed; }
        if (Input.GetKey(keyBinding.keyMoveBackward)) { newPos -= this.transform.forward * moveSpeed; }
        if (Input.GetKey(keyBinding.keyMoveRight)) { newPos += this.transform.right * moveSpeed; }
        if (Input.GetKey(keyBinding.keyMoveLeft)) { newPos -= this.transform.right * moveSpeed; }

        this.transform.position = newPos;
    }
}
