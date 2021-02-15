using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButtonUI : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Image buttonImage;
    [SerializeField]
    private Sprite musicOnImage;
    [SerializeField]
    private Sprite musicOffImage;


    public bool isMuted = false;

    private void Awake()
    {
        musicButton.onClick.AddListener(() => ToggleMusicButton(!isMuted));
    }

    private void Start()
    {
        isMuted = AudioPlayer.Instance.isMuted;
        ChangeButtonImage();
    }

    private void ToggleMusicButton(bool value)
    {
        isMuted = value;
        ChangeButtonImage();
        AudioPlayer.Instance.ToggleAudioMute(value);
    }

    private void ChangeButtonImage()
    {
        buttonImage.sprite = isMuted ? musicOffImage : musicOnImage;
    }
}
