namespace Kira
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 10.0f;
        [SerializeField] private Transform m_Graphics;
        private Rigidbody2D m_Body;
        private Vector2 m_Move;
        private Vector3 m_Rot;

        private void Start()
        {
            m_Body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // float xIn = Input.GetAxisRaw("Horizontal");
            // float yIn = Input.GetAxisRaw("Vertical");
            //
            // Vector2 input = new Vector2(xIn * _Speed, yIn * _Speed);
            // transform.Translate(input * Time.deltaTime);
            m_Body.linearVelocity = m_Move;
            m_Graphics.rotation = Quaternion.Euler(m_Rot);
        }

        public void OnMove(InputValue value)
        {
            m_Move = value.Get<Vector2>();
            m_Move *= m_Speed;


            if (m_Move.y < 0) m_Rot.z = -180;
            else if (m_Move.y > 0) m_Rot.z = 0;

            if (m_Move.x < 0) m_Rot.z = 90;
            else if (m_Move.x > 0) m_Rot.z = -90;
        }
    }
}