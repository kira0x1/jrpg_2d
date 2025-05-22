namespace Kira
{
    using System;
    using UnityEngine;

    [Serializable]
    public class GameData
    {
        public CharacterData playerCharacter;
        public Vector2 position;
        public Vector3 rotation;

        // TODO: fill in with jrpg data

        public GameData()
        {
            playerCharacter = new CharacterData();
            position = new Vector2();
            rotation = new Vector3();
        }
    }
}