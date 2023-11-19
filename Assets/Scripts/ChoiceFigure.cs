using System;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceFigure : MonoBehaviour
{
    public static event Action<Figure, bool> SendChoice;
    [SerializeField] private Figure _buttonChoice;
    [SerializeField] private bool _isPlayerOne;
    private Button _button;
    private GameManager _gameManager;
    private void Awake()
    {
        _button = GetComponent<Button>();

        _gameManager = FindObjectOfType<GameManager>(true);

        if(_gameManager == null)
        {
            throw new Exception("GameManager component was missing on the " + gameObject.name);
        }
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(ChoiceSelected);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChoiceSelected);
    }
    private void ChoiceSelected()
    {
        SendChoice?.Invoke(this._buttonChoice, this._isPlayerOne);

        if (_gameManager.isVersusAi)
        {
            Figure rFigure = (Figure)UnityEngine.Random.Range(0, 3);
            SendChoice?.Invoke(rFigure, false);
        }
    }
}
