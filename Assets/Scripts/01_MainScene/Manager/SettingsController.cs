using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the settings panel GameObject

    void Awake()
    {
        // VSync �ѱ� (1: �� �����Ӹ��� ����ȭ)
        QualitySettings.vSyncCount = 1;

        // ������ ���� (60FPS)
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
