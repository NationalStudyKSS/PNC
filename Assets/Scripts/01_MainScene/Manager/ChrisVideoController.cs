using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChrisVideoController : MonoBehaviour
{
    [SerializeField] private GameObject _videoPanel;       // 비디오 패널
    [SerializeField] private VideoPlayer _videoPlayer;     // 비디오 플레이어
    [SerializeField] private RawImage _rawImage;           // 영상이 표시될 RawImage

    public void ShowVideoPanel()
    {
        _videoPanel.SetActive(true); // 패널을 보여줌

        _videoPlayer.renderMode = VideoRenderMode.APIOnly;
        _videoPlayer.targetTexture = null;

        _videoPlayer.isLooping = true;

        _videoPlayer.prepareCompleted += OnPrepared;
        _videoPlayer.Prepare(); // 영상 준비 시작
    }

    private void OnPrepared(VideoPlayer vp)
    {
        _rawImage.texture = vp.texture;

        // RawImage 투명도 1로 설정
        Color color = _rawImage.color;
        color.a = 1f;
        _rawImage.color = color;

        vp.Play();

        _videoPlayer.prepareCompleted -= OnPrepared; // 중복 방지
    }
}
