# Neuroverse: Adaptive VR for Neurodivergent Empathy
[![Docs](https://img.shields.io/badge/wiki-Documentation-blue?logo=github)](https://github.com/Ziforge/Neuroverse/wiki)
[![Overleaf](https://img.shields.io/badge/View%20Thesis-Overleaf-brightgreen?logo=Overleaf&logoColor=white)](https://www.overleaf.com/read/nddwcrqrpbcs#c4cd87)

---
[![Weekly Timesheet](https://img.shields.io/badge/Open_This_Week's_Timesheet-blue?style=for-the-badge)](https://github.com/Ziforge/Neuroverse/blob/main/weekly_notes/week-13-timesheet.md)
[![📋 Neuroverse Sprint Board](https://img.shields.io/badge/Project%20Board-Neuroverse-green?style=for-the-badge)](https://github.com/users/Ziforge/projects/1/views/1)
[![🧠 Sensory Calibration Questionnaire](https://img.shields.io/badge/Questionnaire-%F0%9F%A7%A0-blue?style=for-the-badge)](https://github.com/Ziforge/Neuroverse/wiki/Sensory-Calibration-Questionnaire)
[![🛡️ GDPR Consent Form](https://img.shields.io/badge/GDPR%20Consent-View%20Policy-blue?style=for-the-badge)](https://github.com/Ziforge/Neuroverse/wiki/GDPR-Consent-Form)
=======


> 🌍 A VR platform that adapts to individual sensory needs — connecting neurodivergent and neurotypical users through shared, empathetic interaction.

This project explores adaptive sensory filtering and profile blending in shared VR experiences between neurotypical and neurodivergent individuals. Built in Unity using C# and deployed on Meta Quest 3.

## 🧠 

```mermaid
flowchart TB
    style ND fill:#aec6cf,stroke:#333,stroke-width:2px,color:#000
    style SubNT fill:#c9f7c0,stroke:#333,stroke-width:2px,color:#000
    style Shared fill:#fff8b0,stroke:#333,stroke-width:2px,color:#000
    style SubND fill:#d9d2e9,stroke:#333,stroke-width:2px,color:#000
    style NT fill:#f4cccc,stroke:#333,stroke-width:2px,color:#000

    ND[ND Zone\nStable Settings\nControlled by ND]
    SubNT[Subzone:\nND experiences\nfull NT world]
    Shared[Gradient Zone\nMixed Settings\nBoth Users Present]
    SubND[Subzone:\nNT experiences\nfull ND world]
    NT[NT Zone\nNo Control\nEmergency Kill Switch]

    ND --> SubNT
    NT --> SubND
    SubNT --> Shared
    SubND --> Shared
```



```mermaid
flowchart TD
    A1[Controller 🎮 Y button] --> B1[Kill all sound - mute]
    A2[Controller 🎮 B button] --> B2[Kill all visual changes]
    A[Raise Wrist 🧠] --> B{Input Type?}

    B -- "Hand Tracking ✋" --> C[Tap Wrist to Open UI 👆]
    B -- "Controller 🎮" --> D[Press Menu Button 🎮]
    B -- "Gesture 🫰" --> E[Wrist Pinch Activation ✋]

    C --> F[Show Sensory Menu Panel 📺]
    D --> F
    E --> F

    F --> G{Choose Tab}
    G --> G1[Sensory Filters 🔆]
    G --> G2[Presets 🎮]
    G --> G3[Profile 🧑‍🦱]
    G --> G4[Environment 🌍]

    G1 --> H1[Adjust Sliders:\nVisual, Audio, Haptics, Motion]
    G2 --> H2[Select Mode:\nCalm / Stim / Focus]
    G3 --> H3[Save or Load Profile]
    G4 --> H4[Adjust Lighting, Space, Background]

    H1 --> I[Save Settings ✅]
    H2 --> I
    H3 --> I
    H4 --> I

    I --> J[Return to VR World 🧘]

    %% Improved styling for accessibility
    style F fill:#ffffff,stroke:#333,stroke-width:2px
    style G1 fill:#ddeeff,stroke:#000,stroke-width:1px
    style G2 fill:#ddeeff,stroke:#000,stroke-width:1px
    style G3 fill:#ddeeff,stroke:#000,stroke-width:1px
    style G4 fill:#ddeeff,stroke:#000,stroke-width:1px
```



```mermaid
flowchart TD
    A[🏁 Start VR Session] --> B{Calm Mode Active?}

    B -- Yes --> C[🧘 Stationary or Room-Scale Only]
    B -- No --> D{User Movement Preference?}

    D -- "Teleportation 🔄" --> E[Point & Click to Move]
    D -- "Smooth Locomotion 🎮" --> F[Joystick Movement]

    F --> F1[🎚️ Speed Slider:\nDrift / Natural / Snappy]
    F --> F2[🎚️ Turn Rate Slider:\nSlow / Medium / Fast]

    D -- "Dash (Short Burst) ⚡" --> G[Click to Dash]

    D -- "Waypoint Auto-Move 🎯" --> H[Select Path > Auto Glide]

    E --> I[🛑 Motion Lock Option Available]
    F2 --> I
    G --> I
    H --> I

    I --> J[✅ Save Movement Profile]
    J --> K[🌍 Begin Experience]

    style A fill:#ffffff,stroke:#222222,stroke-width:1.5px
    style B fill:#eeeeee,stroke:#444444,stroke-width:1.5px
    style D fill:#dddddd,stroke:#444444,stroke-width:1.5px
    style E fill:#d0eaff,stroke:#000000,stroke-width:1.5px
    style F fill:#d0eaff,stroke:#000000,stroke-width:1.5px
    style G fill:#d0eaff,stroke:#000000,stroke-width:1.5px
    style H fill:#d0eaff,stroke:#000000,stroke-width:1.5px
    style I fill:#f9f9f9,stroke:#333333,stroke-width:1.5px
    style J fill:#c8f0c8,stroke:#000000,stroke-width:1.5px
    style K fill:#b2f0e0,stroke:#000000,stroke-width:1.5px
```

    
=======

- Sensory calibration and profile prediction using ML
- Real-time filtering (audio, visual, motion)
- Shared user blending engine
- GDPR-compliant anonymous data collection
- Modular Unity-based architecture

➡️ **[See Full Development Guide on GitHub Wiki](https://github.com/Ziforge/Neuroverse/wiki/Development-Setup-Guide)**


## 🔁 Flow Chart

```mermaid
flowchart TD
    A[Start VR Session] --> B[Consent + GDPR Notice]
    B --> C[Calibration Scene]
    C --> D[Passive Behavior Tracking]
    D --> E[ML Predicts Sensory Profile]
    E --> F{Is Other User Nearby?}
    F -- Yes --> G[Blend Sensory Profiles]
    F -- No --> H[Continue Solo Experience]
    G --> I[Adapt Environment]
    H --> I
    I --> J[Cooperative Task or Puzzle]
    J --> K[Post-Session Debrief]
    K --> L[Session Ends]
```


## 📂 Structure

- `docs/`: Academic LaTeX report and diagrams  
- `unity_project/`: Unity C# source files  
- `data/`: Anonymized datasets  
- `website/`: HTML files for recruitment and consent  

## 🧪 Run the Study

1. Clone the repo  
2. Open `unity_project/` in Unity 2022+  
3. Load the calibration or experience scenes  
4. Start testing on Meta Quest 3  

## 📜 License

Licensed under GPL-3.0 or MIT

## 👥 Contributing

See [Contributing Guide on the Wiki](https://github.com/Ziforge/Neuroverse/wiki/Contributing‐to‐Neuroverse)
---

# XR Interaction Toolkit Examples

This section contains example scenes and components from the XR Interaction Toolkit.
Merged into Neuroverse for development and experimentation.
