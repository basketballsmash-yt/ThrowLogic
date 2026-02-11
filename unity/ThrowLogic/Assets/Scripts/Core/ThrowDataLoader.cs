using UnityEngine;
using System.IO;

public class ThrowDataLoader : MonoBehaviour
{
    public DataManager dataManager;

    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "dummy_throw.json");
        string json = File.ReadAllText(path);

        ThrowData data = JsonUtility.FromJson<ThrowData>(json);
        dataManager.SetThrowData(data);
    }
}
