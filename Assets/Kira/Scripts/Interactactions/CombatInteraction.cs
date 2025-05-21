namespace Kira.Interactactions
{
    using UnityEngine;

    public class CombatInteraction : Interactable
    {
        [SerializeField, Tooltip("Minimum Distance to interact with object"), Range(0f, 100f)]
        public float m_MinDistance = 1.2f;

        public override void OnInteract(PlayerInteraction player)
        {
            float dist = Vector2.Distance(this.transform.position, player.transform.position);
            // Debug.Log($"distance: {dist:F1}");
            if (dist > m_MinDistance) return;
            // Debug.Log($"{player.name} interacted with {gameObject.name}");

            FindFirstObjectByType<BattleManager>().InitiateBattle();
        }
    }
}