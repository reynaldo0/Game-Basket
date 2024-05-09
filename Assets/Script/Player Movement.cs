using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player Movement : MonoBehaviour{

    Rigidbody myRigidbody;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    float hInput;
    float vInput;
    bool jumpInput;

    void Awake(){
        myRigidbody = GetComponent<Rigidbody> ();
    }
     
    void Update(){
        hInput = Input.GetAxis ("Horizontal") * moveSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        jumpInput = Input.GetKeyDown (KeyCode.Space);
    }

    void FixedUpdate(){
        Move ();

        if(jumpInput){
            Jump ();
            jumpInput = false;
        }
    }
    void Move(){
        myRigidbody.AddForce (hInput * Time.fixedDeltaTime, 0f, vInput * Time.fixedDeltaTime);
    }

    void Jump(){
        myRigidbody.AddForce(Vector3.up * JumpPower * Time.fixedDeltaTime, forceMode.Impulse)
    }
}
