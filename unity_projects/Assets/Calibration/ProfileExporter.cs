using System.IO;
using UnityEngine;

[System.Serializable]
public class ProfileSettings
{
    public float visual;
    public float audio;
    public float motion;
    public float haptic;
}

public class ProfileExporter : MonoBehaviour
{
    public void ExportCurrentProfileToJson()
    {
        var profile = UserProfileManager.Instance.CurrentProfile;

        ProfileSettings settings = new ProfileSettings
        {
            visual = profile.VisualIntensity,
            audio = profile.AudioCutoff,
            motion = profile.MotionSmoothness,
            haptic = profile.HapticStrength
        };

        string json = JsonUtility.ToJson(settings, true);

        string filename = $"user_profile_{System.DateTime.Now:yyyy-MM-dd_HH-mm}.json";
        string path = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllText(path, json);

        Debug.Log($"Profile exported: {path}");
    }
}

