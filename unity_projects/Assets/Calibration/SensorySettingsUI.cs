using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensorySettingsUI : MonoBehaviour
{
    public Slider visualSlider, audioSlider, hapticSlider, motionSlider;
    public TextMeshProUGUI visualLabel, audioLabel, hapticLabel, motionLabel;

    public VisualFilterManager visualManager;
    public AudioFilterManager audioManager;
    public HapticManager hapticManager;
    public MotionSmoothingManager motionManager;

    void Start()
    {
        var profile = UserProfileManager.Instance.CurrentProfile;

        visualSlider.value = profile.VisualIntensity;
        audioSlider.value = profile.AudioCutoff;
        hapticSlider.value = profile.HapticStrength;
        motionSlider.value = profile.MotionSmoothness;

        visualLabel.text = GetPerceptualLabel(visualSlider.value, "Visual");
        audioLabel.text = GetPerceptualLabel(audioSlider.value, "Audio");
        hapticLabel.text = GetPerceptualLabel(hapticSlider.value, "Haptic");
        motionLabel.text = GetPerceptualLabel(motionSlider.value, "Motion");

        visualSlider.onValueChanged.AddListener(UpdateVisual);
        audioSlider.onValueChanged.AddListener(UpdateAudio);
        hapticSlider.onValueChanged.AddListener(UpdateHaptic);
        motionSlider.onValueChanged.AddListener(UpdateMotion);
    }

    public void UpdateVisual(float value)
    {
        UserProfileManager.Instance.CurrentProfile.VisualIntensity = value;
        visualLabel.text = GetPerceptualLabel(value, "Visual");
        visualManager.SetIntensity(value);
    }

    public void UpdateAudio(float value)
    {
        UserProfileManager.Instance.CurrentProfile.AudioCutoff = value;
        audioLabel.text = GetPerceptualLabel(value, "Audio");
        audioManager.SetCutoff(value);
    }

    public void UpdateHaptic(float value)
    {
        UserProfileManager.Instance.CurrentProfile.HapticStrength = value;
        hapticLabel.text = GetPerceptualLabel(value, "Haptic");
        hapticManager.SendHaptic(value);
    }

    public void UpdateMotion(float value)
    {
        UserProfileManager.Instance.CurrentProfile.MotionSmoothness = value;
        motionLabel.text = GetPerceptualLabel(value, "Motion");
        motionManager.SetSmoothness(value);
    }

    public void SaveAll()
    {
        UserProfileManager.Instance.SaveProfile();
    }

    string GetPerceptualLabel(float value, string type)
    {
        if (type == "Visual") return value < 0.4f ? "Dim" : value < 0.8f ? "Balanced" : "Bright";
        if (type == "Audio") return value < 1000 ? "Muffled" : value < 6000 ? "Clear" : "Crisp";
        if (type == "Haptic") return value < 0.3f ? "Soft" : value < 0.6f ? "Noticeable" : "Strong";
        if (type == "Motion") return value < 0.6f ? "Slow" : value < 1.2f ? "Natural" : "Fast";
        return "Unknown";
    }
}
