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
        // ó���� �����ϰ� ����
        Color color = _rawImage.color;
        color.a = 0f;
        _rawImage.color = color;

        _imageObject.SetActive(true);

        _videoPlayer.renderMode = VideoRenderMode.APIOnly;
        _videoPlayer.targetTexture = null; // �ڵ� ����

        _videoPlayer.isLooping = true;  // �ݺ� ���

        _videoPlayer.Prepare();
        _videoPlayer.prepareCompleted += OnPrepared;
    }

    void OnPrepared(VideoPlayer vp)
    {
        _rawImage.texture = vp.texture;

        // ���� ���̵��� ���İ� �ø���
        Color color = _rawImage.color;
        color.a = 1f;
        _rawImage.color = color;

        vp.Play();
    }
}
