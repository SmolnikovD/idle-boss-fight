using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonUI : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(() => SceneChanger.Instance.LoadGameScene());
    }
}
