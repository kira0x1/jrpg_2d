using UnityEngine;

namespace Kira
{
    using System;
    using System.Collections.Generic;

    public enum EGender
    {
        Male,
        Female,
        NonBinary
    }

    [Serializable]
    public class CharacterData
    {
        public string name;
        public EGender gender;
        public int health;
        public int maxHealth;
        public bool isDead;
        public int gold;
        public List<Pet> pets = new List<Pet>();

        // Current location -> city, position in city. scene data etc
    }

    // Last location
    // Party 
    // Stats related to game progress and completion I.E caught creatures, locations discovered, etc
    // Inventory
    // Achievments
    // Quests

    // PlayerCharacter Stats
    //  - Catch Rate
    //  - Global Modifiers


    // Character Info ( name, gender, clothes, etc )
    //  Money
    // Other currencies

    public class PlayerCharacter : MonoBehaviour, IDataPersistence
    {
        public CharacterData character;

        public List<Pet> playerPets = new List<Pet>();

        public void LoadData(GameData data)
        {
            character = data.playerCharacter;
        }

        public void SaveData(ref GameData data)
        {
            data.playerCharacter = character;
        }
    }
}