namespace Kira
{
    using UnityEngine;

    public class PlayerManager : MonoBehaviour, IDataPersistence
    {
        public void LoadData(GameData data)
        {
            Debug.Log($"Loading: {data.position}");
            transform.position = data.position;
        }

        public void SaveData(ref GameData data)
        {
            Debug.Log($"Saving: {transform.position}");
            data.position = transform.position;
        }
    }
}