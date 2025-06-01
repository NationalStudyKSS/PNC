using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChrisVideoController : MonoBehaviour
{
    [SerializeField] private GameObject _videoPanel;       // ���� �г�
    [SerializeField] private VideoPlayer _videoPlayer;     // ���� �÷��̾�
    [SerializeField] private RawImage _rawImage;           // ������ ǥ�õ� RawImage

    public void ShowVideoPanel()
    {
        _videoPanel.SetActive(true); // �г��� ������

        _videoPlayer.renderMode = VideoRenderMode.APIOnly;
        _videoPlayer.targetTexture = null;

        _videoPlayer.isLooping = true;

        _videoPlayer.prepareCompleted += OnPrepared;
        _videoPlayer.Prepare(); // ���� �غ� ����
    }

    private void OnPrepared(VideoPlayer vp)
    {
        _rawImage.texture = vp.texture;

        // RawImage ���� 1�� ����
        Color color = _rawImage.color;
        color.a = 1f;
        _rawImage.color = color;

        vp.Play();

        _videoPlayer.prepareCompleted -= OnPrepared; // �ߺ� ����
    }
}
