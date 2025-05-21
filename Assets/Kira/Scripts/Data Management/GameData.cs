namespace Kira
{
    using System;
    using UnityEngine;

    [Serializable]
    public class GameData
    {
        public CharacterData playerCharacter;
        public Vector2 position;

        // TODO: fill in with jrpg data

        public GameData()
        {
            playerCharacter = new CharacterData();
            position = new Vector2();
        }
    }
}