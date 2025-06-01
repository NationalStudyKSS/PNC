using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] GameObject _imageObject;
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] RawImage _rawImage;

    void Start()
    {
        // 처음엔 투명하게 설정
        Color color = _rawImage.color;
        color.a = 0f;
        _rawImage.color = color;

        _imageObject.SetActive(true);

        _videoPlayer.renderMode = VideoRenderMode.APIOnly;
        _videoPlayer.targetTexture = null; // 자동 설정

        _videoPlayer.isLooping = true;  // 반복 재생

        _videoPlayer.Prepare();
        _videoPlayer.prepareCompleted += OnPrepared;
    }

    void OnPrepared(VideoPlayer vp)
    {
        _rawImage.texture = vp.texture;

        // 영상 보이도록 알파값 올리기
        Color color = _rawImage.color;
        color.a = 1f;
        _rawImage.color = color;

        vp.Play();
    }
}
