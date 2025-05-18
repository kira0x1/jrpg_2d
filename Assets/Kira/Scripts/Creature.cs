using UnityEngine;

namespace Kira
{
    using System;

    public class Creature
    {
        public int health;
        public int maxHealth;

        public int energy;
        public int maxEnergy;

        public int exp;
        public int maxExp;
        public int level;

        public ElementTypes elementType;
    }

    [Flags]
    public enum ElementTypes
    {
        Normal,
        Fire,
        Water,
        Grass,
        Electric,
        Ground
    }
}