using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove3rdPerson : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [Header("Speed")]
    [SerializeField] private float speedRotation = 3;
    [SerializeField] private float speed = 5.0f;

    float HorKBInput, VerKBInput;
    Vector3 moveDir, RotDir;

    void Start () { 
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void Update() {
        MoveInput();
    }   

    private void MoveInput()
    {
        HorKBInput = Input.GetAxisRaw("Horizontal");
        VerKBInput = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMovement()
    {
        moveDir = transform.forward * VerKBInput; 

        _rb.MovePosition(transform.position + moveDir * speed * Time.deltaTime); 

        RotDir = transform.up * HorKBInput;

        transform.Rotate(RotDir * speedRotation); 
    }

}
