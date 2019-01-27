using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
   
    public static void SaveData(bool a, bool b, bool c, bool d, bool e) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.i";

        FileStream stream = new FileStream(path, FileMode.Create);

        bool[] data = new bool[5];
        data[0] = a; data[1] = b; data[2] = c; data[3] = d; data[4] = e;

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save");
    }

    public static bool[] LoadData() {
        string path = Application.persistentDataPath + "/data.i";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            bool[] data = new bool[5];
            data = formatter.Deserialize(stream) as bool[];
            stream.Close();

            Debug.Log("Load");
            return data;
        }
        else {
            Debug.LogError("Nie odnaleziono zapisu gry w " + path);
            return null;
        }
    }
}
