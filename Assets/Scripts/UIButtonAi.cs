using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonAi : MonoBehaviour
{
    private GameManager _gameManagerScript;
    private Button _button;
    private TextMeshProUGUI _buttonText;
    private void OnEnable()
    {
        _button.onClick.AddListener(PressButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PressButton);
    }

    private void Awake()
    {
        _button = GetComponent<Button>();

        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>(true);

        if (_gameManagerScript == null)
        {
            throw new System.Exception("GameManager component was missing on the " + gameObject.name);
        }

        SetAiButtonText(_gameManagerScript.isVersusAi);
    }

    private void PressButton()
    {
        _gameManagerScript.AiButtonToggle();

        SetAiButtonText(_gameManagerScript.isVersusAi);
    }

    private void SetAiButtonText(bool state)
    {
        _buttonText.SetText(state ? "vs.\nПК" : "vs.\nИгрок");
    }
}