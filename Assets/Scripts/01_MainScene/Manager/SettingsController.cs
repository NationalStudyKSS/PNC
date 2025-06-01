using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the settings panel GameObject

    void Awake()
    {
        // VSync 켜기 (1: 매 프레임마다 동기화)
        QualitySettings.vSyncCount = 1;

        // 프레임 제한 (60FPS)
        Application.targetFrameRate = 60;
    }

    public void OnClickSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void OnClickCloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
