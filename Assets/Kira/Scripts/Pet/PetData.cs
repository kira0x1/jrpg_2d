namespace Kira
{
    using Stats;
    using UnityEngine;
    using UnityEngine.Serialization;

    [CreateAssetMenu(fileName = "new pet", menuName = "Kira/New Pet")]
    public class PetData : ScriptableObject
    {
        [FormerlySerializedAs("creatureName")] public string petName;
        public int id;
        public Sprite icon;
        public Sprite petArt; // replace with prefab to give and handle more complex visuals
        public ElementTypes elementType;
        public EntityStats stats;
    }
}