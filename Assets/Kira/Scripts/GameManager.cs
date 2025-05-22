using UnityEngine;

namespace Kira
{
    using UnityEngine.SceneManagement;

    public enum SceneData
    {
        BootScene = 0,
        OverWorld = 1,
        BattleScene = 2
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private PlayerCharacter playerCharacter;
        private bool gameSceneLoaded;

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);


            playerCharacter = GetComponent<PlayerCharacter>();
            LoadData();

            if (!gameSceneLoaded)
            {
                gameSceneLoaded = true;
                SceneManager.LoadScene(1, LoadSceneMode.Additive);
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            Debug.Log($"scene loaded: {scene.name}, mode: {(sceneMode == LoadSceneMode.Single ? "single" : "additive")}");
        }

        public void LoadData()
        {
            playerCharacter.character = PlayerState.playerCharacter;
            playerCharacter.transform.position = PlayerState.position;
            playerCharacter.transform.rotation = Quaternion.Euler(PlayerState.rotation);
        }

        public void SaveState()
        {
            PlayerState.playerCharacter = playerCharacter.character;
            PlayerState.position = playerCharacter.transform.position;
            PlayerState.rotation = playerCharacter.transform.rotation.eulerAngles;
        }
    }

    public static class PlayerState
    {
        public static Vector3 position;
        public static Vector3 rotation;
        public static CharacterData playerCharacter;
    }
}