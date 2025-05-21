using UnityEngine;

namespace Kira
{
    using Interactactions;
    using UnityEditor;
    using UnityEngine.InputSystem;

    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform m_RayStart;
        [SerializeField] private LayerMask m_RayLayerMask;
        private RaycastHit2D hit;

        public void OnInteract()
        {
            hit = Physics2D.Raycast(m_RayStart.position, m_RayStart.up, 500, m_RayLayerMask);
            if (hit) OnRayHit();
        }

        private void OnRayHit()
        {
            var other = hit.transform;
            Interactable interaction = other.GetComponent<Interactable>();

            if (interaction)
            {
                interaction.OnInteract(this);
            }
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