using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System;

public class SaveAndLoad : MonoBehaviour
{
    public GameObject savingIcon;

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();
        formatter.Serialize(stream, data);
        stream.Close();  
    }

    public static SaveData Load()
    {
        string path = Application.persistentDataPath + "/Game.fun";
        FileStream stream = new FileStream(path, FileMode.Open);
        if (File.Exists(path) && stream.Length > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            SaveData data = formatter.Deserialize(stream) as SaveData;

            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            stream.Close();
            return null;
        }
    }

    IEnumerator Saving()
    {
        savingIcon.SetActive(true);
        yield return new WaitForSeconds(3);
        savingIcon.SetActive(false);
    }
}
