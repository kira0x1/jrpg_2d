namespace Kira
{
    public struct BattleCommand : IBattleCommand
    {
        public EUserType Caster { get; }
        public ECommandType CommandType { get; }
        public EUserType Target { get; }
        public ETargetType TargetType { get; }
        public int Order { get; set; }
        public int TurnCount { get; }

        public BattleCommand(EUserType caster, ECommandType commandType, EUserType target, ETargetType targetType, int order, int turnCount)
        {
            Caster = caster;
            CommandType = commandType;
            Target = target;
            TargetType = targetType;
            Order = order;
            TurnCount = turnCount;
        }
    }

    public interface IBattleCommand
    {
        public EUserType Caster { get; }
        public ECommandType CommandType { get; }
        public EUserType Target { get; }
        public ETargetType TargetType { get; }
        public int Order { get; set; }
        public int TurnCount { get; }
    }

    public enum ECommandType
    {
        Disabled, // I.E stunned, frozen, etc
        Attack,
        Magic,
        Guard,
        Pass,
        UseItem,
        Flee,
        Switch
    }

    public enum ETargetType
    {
        Self,
        Enemy,
        Friendly,
        Enivornment
    }

    /// <summary>
    /// Who did the command,
    /// Examples
    ///     player -> useitem,
    ///     creature -> casts ability on round start,
    ///     enivronment -> debuff on battle start
    /// </summary>
    public enum EUserType
    {
        Player,
        Creature,
        Trainer,
        Environment
    }
}