using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kira
{
    public class DataManager : MonoBehaviour
    {
        [Header("Debugging")]
        [SerializeField]
        private bool initializeDataIfNull;

        [Header("File Config")]
        [SerializeField]
        private bool useEncryption = true;

        [SerializeField]
        private bool autoSave = true;

        private GameData _gameData;
        private List<IDataPersistence> _dataPersistenceObjects = new();
        private FileDataHandler _dataHandler;

        private const string FileName = "data.game";
        public static DataManager Instance { get; private set; }

        private void Awake()
        {
            Init();
            _dataHandler = new FileDataHandler(Application.persistentDataPath, FileName, useEncryption);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (autoSave)
            {
                _dataPersistenceObjects = FindAllDataPersistenceObjects();
                LoadGame();
            }
        }

        private void OnSceneUnloaded(Scene scene)
        {
            if (autoSave)
            {
                SaveGame();
            }
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            var dataObjects = FindObjectsByType<MonoBehaviour>((FindObjectsSortMode)FindObjectsInactive.Exclude).OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataObjects);
        }

        private void Init()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        public void NewGame()
        {
            _gameData = new GameData();
        }

        private void SaveGame()
        {
            if (_gameData == null)
            {
                return;
            }

            foreach (var dataObject in _dataPersistenceObjects)
            {
                dataObject.SaveData(ref _gameData);
            }

            _dataHandler.Save(_gameData);
        }

        private void LoadGame()
        {
            _gameData = _dataHandler.Load();

            if (_gameData == null)
            {
                if (initializeDataIfNull)
                {
                    NewGame();
                }
            }

            if (_gameData == null)
            {
                return;
            }

            foreach (var dataObject in _dataPersistenceObjects)
            {
                dataObject.LoadData(_gameData);
            }
        }

        private void OnApplicationQuit()
        {
            // if (SceneManager.GetActiveScene().buildIndex > 0)

            if (autoSave)
            {
                SaveGame();
            }
        }

        [ContextMenu("Delete GameData")]
        public void DeleteGameData()
        {
            if (!HasGameData())
            {
                Debug.LogWarning("no game data to delet");
                return;
            }

            _dataHandler.DeleteData();
            _gameData = null;
        }

        public bool HasGameData()
        {
            return _gameData != null;
        }
    }
}