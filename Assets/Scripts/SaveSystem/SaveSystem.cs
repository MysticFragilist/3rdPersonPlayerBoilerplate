using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.SaveSystem;
using UnityEngine;

public static class SaveSystem
{
    public class NoSaveFileException : UnityException
    {
        private static string _mes = "No save file present in application.";
        public NoSaveFileException() : base(_mes)
        { }
    }

    private static string _path
    {
        get { return Path.Combine(Application.persistentDataPath, "data{0}.bin"); }
    }

    public static void SavePlayer(Player player, int index = 0)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(String.Format(_path, index), FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(int index = 0)
    {
        if (!File.Exists(_path))
            throw new NoSaveFileException();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(String.Format(_path, index), FileMode.Open);
        var data = (PlayerData) formatter.Deserialize(stream);
        stream.Close();

        return data;
    }
}

