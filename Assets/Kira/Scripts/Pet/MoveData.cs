namespace Kira
{
    using Stats;
    using UnityEngine;

    [CreateAssetMenu(fileName = "new move", menuName = "Kira/New Move")]
    public class MoveData : ScriptableObject
    {
        public string moveName;
        public int energyCost;
        public ElementTypes elementTypes;
        public ETargetType targetRule;
        public StatMod moveStatsModifier;

        // have a list of attack graphics to choose from i.e swipe,ice claw,fire ball,lightning,scratch,punch
    }
}