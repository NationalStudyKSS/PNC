using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject _uiPanel;
    [SerializeField]
    // Start is called before the first frame update


    /// <summary>
    /// 켜져있는 UI를 키거나 끌 수 있는 함수
    /// </summary>
    public void UIShowHideControl()
    {
        if (_uiPanel != null)
        {
            _uiPanel.SetActive(!_uiPanel.activeSelf);
        }
    }
    public void ClosePanel(GameObject nowPanel, GameObject clickedPanel)
    {
        if (clickedPanel != null)
            nowPanel.SetActive(false);
    }
    public void OpenPanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(true);
    }
}
