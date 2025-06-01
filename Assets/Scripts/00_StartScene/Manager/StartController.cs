using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    [SerializeField] Image _companyImage;       // 회사이미지
    [SerializeField] Image _loadingImage;       // 로딩이미지
    [SerializeField] Image _loadingBarImage;    // 로딩바이미지
    //[SerializeField] Text _loadingPercentText;  // 로딩 퍼센트 텍스트. 필요하면 나중에 추가
    [SerializeField] Image _gameStartImage;     // 게임시작이미지
    
    float _duration = 2f; // 일단 걸리는 모든 시간을 2초로 해서 공통 사용. 나중에 각각 설정가능

    private void Start()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        yield return FadeInOut(_companyImage, _duration);

        _companyImage.gameObject.SetActive(false);
        _loadingImage.gameObject.SetActive(true);

        yield return FillLoadingBar(_loadingBarImage, 2f);

        _loadingImage.gameObject.SetActive(false);
        _gameStartImage.gameObject.SetActive(true);
    }

    /// <summary>
    /// 게임 시작시 회사이미지를 페이드인/아웃하는 코루틴.
    /// </summary>
    /// <param name="image">페이드인아웃 할 이미지</param>
    /// <param name="duration">페이드인 할 때(혹은 페이드아웃 할 때)걸리는 시간</param>
    /// <returns></returns>
    private IEnumerator FadeInOut(Image image, float duration)
    {
        float timer = 0f;   // 경과한 시간
        Color originalColor = image.color;  // 로고이미지가 켜져있을때 (알파값 1)
        Color transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);  // 로고이미지가 꺼져있을때 (알파값 0)

        // 페이드인 (투명 → 불투명)
        while (timer < duration)
        {
            timer += Time.deltaTime;    // 기본적인 타이머 방식
            float t = timer / duration; // 알파값을 채워줄 비율

            image.color = Color.Lerp(transparentColor, originalColor, t);   // rgb는 항상 1이고 알파값의 비율만 달라짐
            yield return null;
        }

        // 불투명하게 맞춰주기(혹시모름)
        image.color = originalColor;

        // 잠깐 대기(페이드아웃을 하기 전에 잠깐 멈춤)
        yield return new WaitForSeconds(1f);

        // 페이드아웃 (불투명 → 투명)
        timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            image.color = Color.Lerp(originalColor, transparentColor, t);
            yield return null;
        }

        // 투명하게 맞춰주기(혹시모름)
        image.color = transparentColor;
    }

    /// <summary>
    /// 로딩바 이미지를 천천히 채워주는 함수
    /// </summary>
    /// <param name="loadingBarImage">로딩바 이미지</param>
    /// <param name="duration">걸리는 시간</param>
    /// <returns></returns>
    private IEnumerator FillLoadingBar(Image loadingBarImage, float duration)
    {
        float timer = 0f; // 경과한 시간
        loadingBarImage.fillAmount = 0f; // 초기화
        while (timer < duration)
        {
            timer += Time.deltaTime; // 기본적인 타이머 방식
            float t = timer / duration; // 채워지는 비율

            loadingBarImage.fillAmount = Mathf.Lerp(0f, 1f, t); // 0에서 1로 채워짐
            yield return null;
        }
        // 완전히 채워주기(혹시모름)
        loadingBarImage.fillAmount = 1f;
    }

    public void OnGameStart()
    {
        SceneManager.LoadScene("01_MainScene"); // 게임 시작 버튼 클릭시 메인 씬으로 이동
    }
}
