using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Model
{
    public class DataStorage: IPinDataStorage
    {
        private string _filePath = Application.persistentDataPath + "/pins.dat";
        private string _savedData = Application.persistentDataPath + "/savedData.txt";
        private string _loadedData = Application.persistentDataPath + "/loadedData.txt";

        public void Save(List<PinData> pinDataList)
        {
            using (FileStream fileStream = new FileStream(_filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, pinDataList);
            }

            WriteLog(_savedData, pinDataList);

            Debug.Log("Data saved to " + _filePath);
        }

        private void WriteLog(string path, List<PinData> pinDataList)
        {
            foreach (var pinData in pinDataList)
            {
                File.WriteAllText(path,pinData.ToString());
            }
        }
        public List<PinData> Load()
        {
            if (!File.Exists(_filePath))
            {
                Debug.LogWarning("Save file not found.");
                return new List<PinData>();
            }

            using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    var pins =  (List<PinData>)formatter.Deserialize(fileStream);
                    WriteLog(_loadedData, pins);
                    return pins;
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e);
                    return null;
                }

            }
        }
    }
}