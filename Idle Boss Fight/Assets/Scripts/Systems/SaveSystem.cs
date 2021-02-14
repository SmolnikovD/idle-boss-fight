using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private const string directory = "/SaveData/";

    public static void Save<T>(T dataToSave) where T : class, ISaveable => Save(dataToSave, "");
    public static void Save<T>(T dataToSave, string id) where T : class, ISaveable
    {
        string path = Application.persistentDataPath + directory;

        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(path + dataToSave.GetType().ToString() + id, json);
    }

    public static T Load<T>(T dataToLoad) where T : class, ISaveable => Load(dataToLoad, "");
    public static T Load<T>(T dataToLoad, string id) where T : class, ISaveable
    {
        string path = Application.persistentDataPath + directory + dataToLoad.GetType().ToString() + id;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }

        return dataToLoad;
    }
}

public interface ISaveable { }
