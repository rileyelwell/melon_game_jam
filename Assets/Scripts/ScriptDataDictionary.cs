using System.Collections.Generic;
using UnityEngine;

public class ScriptDataDictionary : MonoBehaviour
{
    // Define the dictionary as static
    public static Dictionary<string, string[]> scriptDict { get; private set; }

    // Static constructor to initialize the dictionary
    static ScriptDataDictionary()
    {
        scriptDict = new Dictionary<string, string[]>();
        LoadDictionaryFromJSON();
    }

    private static void LoadDictionaryFromJSON()
    {
        // Load the JSON file from Resources
        TextAsset jsonTextFile = Resources.Load<TextAsset>("scriptData");
        if (jsonTextFile != null)
        {
            string jsonString = jsonTextFile.text;

            // Deserialize the JSON into a list of key-value pairs
            List<SerializableKeyValuePair> keyValuePairs = JsonUtility.FromJson<SerializationWrapper>(jsonString).keyValuePairs;

            // Add the key-value pairs to the dictionary
            foreach (var kvp in keyValuePairs)
            {
                scriptDict.Add(kvp.Key, kvp.Value);
            }
        }
        else
        {
            Debug.LogError("Could not find the JSON file in Resources.");
        }
    }

    private void Start()
    {
        if (scriptDict.TryGetValue("Key1", out string[] values))
        {
            Debug.Log("Values for Key1: " + string.Join(", ", values));
        }
    }

    [System.Serializable]
    public class SerializableKeyValuePair
    {
        public string Key;
        public string[] Value;
    }

    [System.Serializable]
    public class SerializationWrapper
    {
        public List<SerializableKeyValuePair> keyValuePairs;
    }
}
