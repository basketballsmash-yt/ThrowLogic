using UnityEngine;
using UnityEngine.UIElements;

public class MainLayoutController : MonoBehaviour
{
    public ThrowPlayer throwPlayer;

    private Button playButton;
    private Button pauseButton;
    private Button nextButton;
    private Image previewImage;
    public RenderTexture previewTexture;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        playButton = root.Q<Button>("play-button");
        pauseButton = root.Q<Button>("pause-button");
        nextButton = root.Q<Button>("next-button");
        previewImage = root.Q<Image>("preview-image");

        previewImage.image = previewTexture;


        playButton.clicked += OnPlayClicked;
        pauseButton.clicked += OnPauseClicked;
        nextButton.clicked += OnNextClicked;
        var rt = Resources.Load<RenderTexture>("PreviewRT");
    }

    private void OnPlayClicked()
    {
        throwPlayer.Play();
        Debug.Log("Play pressed");
    }

    private void OnPauseClicked()
    {
        throwPlayer.Pause();
        Debug.Log("Pause pressed");
    }

    private void OnNextClicked()
    {
        throwPlayer.NextFrame();
        Debug.Log("Next pressed");
    }
}
