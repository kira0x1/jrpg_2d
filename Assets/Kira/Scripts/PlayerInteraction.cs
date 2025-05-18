using UnityEngine;

namespace Kira
{
    using UnityEditor;

    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform m_RayStart;
        [SerializeField] private LayerMask m_RayLayerMask;
        private RaycastHit2D hit;

        private void FixedUpdate()
        {
            hit = Physics2D.Raycast(m_RayStart.position, m_RayStart.up, 500, m_RayLayerMask);
            if (hit) OnRayHit();
        }

        private void OnRayHit()
        {
            var other = hit.transform;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying || !hit) return;
            var pos = m_RayStart.position;
            Debug.Log(hit.transform.name);
            Gizmos.DrawLine(pos, hit.point);
        }
    }
}