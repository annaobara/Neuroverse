using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(fileName = "StoredAnswers", menuName = "Scriptable Objects/StoredAnswers")]
public class StoredAnswers : ScriptableObject
{


    [SerializedDictionary("Question", "Participants Answer")]
    public SerializedDictionary<string, string> QuestionsWithAnswers = new SerializedDictionary<string, string>();






}
