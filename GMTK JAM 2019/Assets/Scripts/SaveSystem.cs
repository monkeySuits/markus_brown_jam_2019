using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem {
    static string fileName = "jump.jones";

    public static void SaveHighscore(int highscore) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, fileName);
        FileStream stream = new FileStream(path, FileMode.Create);

        HighscoreData data = new HighscoreData(highscore);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static int LoadHighscore() {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighscoreData data = formatter.Deserialize(stream) as HighscoreData;
            stream.Close();

            return data.highscore;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return 0;
        }
    }
}