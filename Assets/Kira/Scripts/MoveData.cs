namespace Kira
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "new move", menuName = "Kira/New Move")]
    public class MoveData : ScriptableObject
    {
        public string moveName;
        public int energyCost;
        public ElementTypes moveType;
        // have a list of attack graphics to choose from i.e swipe,ice claw,fire ball,lightning,scratch,punch
    }
}