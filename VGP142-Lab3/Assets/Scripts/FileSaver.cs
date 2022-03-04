using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class FileSaver : MonoBehaviour
{
    private static FileSaver instance;
    private string defaultFilePath;

    public static FileSaver Instance { get => instance; }

    private void Awake()
    {
        if (!instance) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(instance);

        defaultFilePath = Application.dataPath + "/SaveGameData/GameSaveData.text";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData(SaveableData saveData)
    {
        SaveUsingXML(saveData);

    }

    public SaveableData LoadData(string filepath_)
    {
       return LoadUsingXML(filepath_);
    }

    private void SaveUsingXML(SaveableData saveData)
    {
        XmlDocument xmlDoc = new XmlDocument();

        #region Create Elements

        XmlElement root = xmlDoc.CreateElement("Save");

        XmlElement playerLives = xmlDoc.CreateElement("PlayerLives");
        playerLives.InnerText = saveData.playerLives.ToString();
        root.AppendChild(playerLives);

        XmlElement checkpointPosX = xmlDoc.CreateElement("CheckpointPositionX");
        checkpointPosX.InnerText = saveData.checkpointPositionX.ToString();
        root.AppendChild(checkpointPosX);

        XmlElement checkpointPosY = xmlDoc.CreateElement("CheckpointPositionY");
        checkpointPosY.InnerText = saveData.checkpointPositionY.ToString();
        root.AppendChild(checkpointPosY);

        XmlElement checkpointPosZ = xmlDoc.CreateElement("CheckpointPositionZ");
        checkpointPosZ.InnerText = saveData.checkpointPositionZ.ToString();
        root.AppendChild(checkpointPosZ);

        #endregion

        xmlDoc.AppendChild(root);

        xmlDoc.Save(defaultFilePath);
        if(File.Exists(defaultFilePath))
        {
            Debug.Log("FILE SAVED");
        }
    }

    SaveableData LoadUsingXML(string filepath_)
    {
        if (!File.Exists(filepath_))
        {
            Debug.Log("FILE NOT FOUND");
            return null;
        }
            SaveableData saveData = new SaveableData();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(defaultFilePath);

            saveData.playerLives = int.Parse(xmlDoc.GetElementsByTagName("PlayerLives")[0].InnerText);
            saveData.checkpointPositionX = float.Parse(xmlDoc.GetElementsByTagName("CheckpointPositionX")[0].InnerText);
            saveData.checkpointPositionY = float.Parse(xmlDoc.GetElementsByTagName("CheckpointPositionY")[0].InnerText);
            saveData.checkpointPositionZ = float.Parse(xmlDoc.GetElementsByTagName("CheckpointPositionZ")[0].InnerText);
            return saveData;
    }
}
