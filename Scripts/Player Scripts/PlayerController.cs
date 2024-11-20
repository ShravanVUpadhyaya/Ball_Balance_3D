using UnityEngine;

namespace ZombieLabyrinth.Player
{
    public class PlayerController : MonoBehaviour
    {
        public FixedJoystick joyStick;
        public CharacterController controller;
        public float moveSpeed = 5f;
        public float gravity = -9.81f;
        public Animator animator;

        private Vector3 velocity;
        private bool isGrounded;

        void Update()
        {
            float horizontal = joyStick.Horizontal;
            float vertical = joyStick.Vertical;

            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            controller.Move(move * moveSpeed * Time.deltaTime);

            float speed = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            animator.SetFloat("Speed", speed);

            bool isMovingLeft = horizontal < 0 && Mathf.Abs(horizontal) > Mathf.Abs(vertical);
            bool isMovingRight = horizontal > 0 && Mathf.Abs(horizontal) > Mathf.Abs(vertical);
            bool isMovingForward = vertical > 0 && Mathf.Abs(vertical) >= Mathf.Abs(horizontal);
            bool isMovingBackwards = vertical < 0 && Mathf.Abs(vertical) >= Mathf.Abs(horizontal);

            animator.SetBool("IsMovingLeft", isMovingLeft);
            animator.SetBool("IsMovingRight", isMovingRight);
            animator.SetBool("IsMovingBackwards", isMovingBackwards);

            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
