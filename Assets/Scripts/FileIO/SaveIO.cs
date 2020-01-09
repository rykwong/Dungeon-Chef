using UnityEngine;

public static class SaveIO
{
  private static readonly string baseSavePath;

  static SaveIO()
  {
    baseSavePath = Application.persistentDataPath;
  }

  public static void saveData<T>(string path, T data)
  {
    FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", data);
  }

  public static T loadData<T>(string path)
  {
    string filePath = baseSavePath + "/" + path + ".dat";

    if (System.IO.File.Exists(filePath))
    {
      return FileReadWrite.ReadFromBinaryFile<T>(filePath);
    }
    
    return default(T);
  }
}