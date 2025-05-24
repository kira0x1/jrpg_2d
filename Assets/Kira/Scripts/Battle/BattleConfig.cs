namespace Kira
{
    using System;

    [Serializable]
    public class BattleConfig
    {
        public Pet[] playerPets;
        // setup way for randomly generating enemies or setting data for it beforehand
        public Pet[] enemyPets;
        // setup rewards

        public BattleConfig(Pet[] playerPets, Pet[] enemyPets)
        {
            this.playerPets = playerPets;
            this.enemyPets = enemyPets;
        }
    }
}