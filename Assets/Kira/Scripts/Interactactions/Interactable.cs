namespace Kira.Interactactions
{
    using UnityEngine;

    public abstract class Interactable : MonoBehaviour
    {
        public abstract void OnInteract(PlayerInteraction player);
    }
}