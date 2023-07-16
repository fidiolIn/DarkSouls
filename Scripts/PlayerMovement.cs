using UnityEngine;

namespace Sources.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float velocity;
        [SerializeField] private float jumpForce;
        public float Velocity => velocity;

        public void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            Vector3 movementAmount = direction * (Velocity * Time.deltaTime);
            transform.Translate(movementAmount);
        }

        public virtual void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
