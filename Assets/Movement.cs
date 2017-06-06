using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 6;
    public float jumpspeed = 8;
    public float gravity = 20;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //feed movedirection
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpspeed;
            }
            //applying gravity to controller
            moveDirection.y -= gravity * Time.deltaTime;
            //making the character move
            controller.Move(moveDirection * Time.deltaTime);
        }
	}
}
