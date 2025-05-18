using UnityEngine;

namespace Kira
{
    using UnityEngine.Serialization;

    [CreateAssetMenu(fileName = "new creature", menuName = "Kira/New Creature")]
    public class CreatureData : ScriptableObject
    {
        public string creatureName;
        public int id;
        public Sprite icon;
        public Sprite creatureArt; // replace with prefab to give and handle more complex visuals

        public int health;
        public int maxHealth;

        public int energy;
        public int maxEnergy;

        public int exp;
        public int maxExp;
        public int level;

        [FormerlySerializedAs("creatureType")] public ElementTypes elementType;
    }
}