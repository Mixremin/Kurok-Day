using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float turnSpeed = 720;
    private Vector3 Keys;

    void Start() {
        _rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Orient();
    }

    void FixedUpdate() {
        Move();
    }


    void Orient() {
        if (Keys != Vector3.zero) {
            
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));
            var skewedInput = matrix.MultiplyPoint3x4(Keys);

            var relative = (transform.position + skewedInput) - transform.position;
            var Rotation = Quaternion.LookRotation(relative, transform.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, turnSpeed * Time.deltaTime);
        }
    }

    void GetInput() {
        Keys = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
    }

    void Move() {
        _rb.MovePosition(transform.position + (transform.forward * Keys.magnitude) * speed * Time.deltaTime);
    }
}
