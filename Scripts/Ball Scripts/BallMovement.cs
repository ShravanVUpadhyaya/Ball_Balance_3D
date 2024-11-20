using System;
using UnityEngine;

namespace BallBalance3d.BallController
{
    public class BallMovement : MonoBehaviour
    {

        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private float speed;
        [SerializeField] private float jumpSpeed;

        bool isTouching = false;


        void OnCollisionStay()
        {
            isTouching = true;
        }

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

            rigidBody.AddForce(movement * speed);

            if (Input.GetKey(KeyCode.Space) && isTouching)
            {
                FindObjectOfType<AudioManager>().Play("Ball_Jump");
                rigidBody.AddForce(Vector3.up * jumpSpeed);
            }
            isTouching = false;
        }
    }
}
