using System;
using System.IO;
using UnityEngine;

namespace Kira
{
    public class FileDataHandler
    {
        private readonly string _dataDirPath;
        private readonly string _dataFileName;

        private readonly bool _useEncryption;
        private const string EncryptionCodeWord = "Catgirls";

        public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
        {
            _dataDirPath = dataDirPath;
            _dataFileName = dataFileName;
            _useEncryption = useEncryption;
        }

        public GameData Load()
        {
            string fullPath = Path.Combine(_dataDirPath, _dataFileName);
            GameData loadedData = null;

            if (File.Exists(fullPath))
            {
                try
                {
                    string dataToLoad = "";

                    using (var stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

                    if (_useEncryption)
                    {
                        dataToLoad = EncryptDecrypt(dataToLoad);
                    }

                    loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error occured when trying to load data to file: {fullPath}\n{e}");
                }
            }

            return loadedData;
        }

        public void Save(GameData data)
        {
            string fullPath = Path.Combine(_dataDirPath, _dataFileName);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                string dataToStore = JsonUtility.ToJson(data);

                if (_useEncryption)
                {
                    dataToStore = EncryptDecrypt(dataToStore);
                }

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error occured when trying to save data to file: {fullPath}\n{e}");
            }
        }

        public void DeleteData()
        {
            string fullPath = Path.Combine(_dataDirPath, _dataFileName);

            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error occured when trying to delete save data: {fullPath}\n{e}");
                }
            }
            else
            {
                Debug.LogWarning($"Trying to delete file that doesnt exist at: {fullPath}");
            }
        }

        private string EncryptDecrypt(string data)
        {
            string modifiedData = "";

            for (int i = 0; i < data.Length; i++)
            {
                modifiedData += (char)(data[i] ^ EncryptionCodeWord[i % EncryptionCodeWord.Length]);
            }

            return modifiedData;
        }
    }
}