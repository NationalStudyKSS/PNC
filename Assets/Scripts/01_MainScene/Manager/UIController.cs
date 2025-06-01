using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject _uiPanel;
    [SerializeField] GameObject _mainPanel; // 메인 패널
    [SerializeField] GameObject _licoPanel; // 상점 패널
    [SerializeField] List<GameObject> shopCategoryImages; // 상점 카테고리 이미지들
    [SerializeField] List<GameObject> gachaCategoryImages; // 가챠 카테고리 이미지들


    [Header("패널 목록")]
    Stack<GameObject> _panelStack = new Stack<GameObject>();
    // Start is called before the first frame update

    void Start()
    {
        ResetToMain(_mainPanel); // 게임 시작 시 메인패널만 등록
    }

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

    public void OpenPanel(GameObject panel)
    {
        if (_panelStack.Count > 0)
            _panelStack.Peek().SetActive(false); // 현재 패널 숨김

        //만약 패널에 비디오가 있다면
        // 비디오를 재생

        _panelStack.Push(panel); // 새 패널 저장
        panel.SetActive(true);
    }

    // 뒤로가기
    public void Back()
    {
        if (_panelStack.Count <= 1)
            return;

        GameObject top = _panelStack.Pop(); // 현재 패널 꺼냄
        top.SetActive(false);               // 끔

        _panelStack.Peek().SetActive(true); // 이전 패널 다시 켬
    }

    public void OnHomeButtonClicked()
    {
        ResetToMain(_mainPanel);
    }

    // 현재 스택 클리어 (예: 메인 화면 초기화 시 사용)
    public void ResetToMain(GameObject mainPanel)
    {
        foreach (var panel in _panelStack)
            panel.SetActive(false);

        _panelStack.Clear();

        _panelStack.Push(mainPanel);
        mainPanel.SetActive(true);
    }

    public void ShopCategoryChange(GameObject shopImage)
    {
        // 모든 카테고리 이미지를 끔
        foreach (var img in shopCategoryImages)
        {
            img.SetActive(false);
        }

        // 클릭한 이미지 켬
        shopImage.SetActive(true);
    }

    public void GachaCategoryChange(GameObject gachaImage)
    {
        // 모든 카테고리 이미지를 끔
        foreach (var img in gachaCategoryImages)
        {
            img.SetActive(false);
        }
        // 클릭한 이미지 켬
        gachaImage.SetActive(true);
    }
}
