using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<State> SendState;
    private Figure _playerOneChoice = Figure.NONE;
    private bool _isPlayerOneSelected = false;
    private Figure _playerTwoChoice = Figure.NONE;
    private bool _isPlayerTwoSelected = false;
    private bool _isRoundFinished = false;
    public bool isVersusAi { get; private set; } = true;
    private void OnEnable()
    {
        ChoiceFigure.SendChoice += OnChoice;
    }

    private void OnDisable()
    {
        ChoiceFigure.SendChoice -= OnChoice;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _playerOneChoice = Figure.NONE;
        _isPlayerOneSelected = false;
        _playerTwoChoice = Figure.NONE;
        _isPlayerTwoSelected = false;

        _isRoundFinished = false;

        SendState?.Invoke(State.STARTROUND);
    }

    private void OnChoice(Figure choice, bool isPlayerOne)
    {
        if (_isRoundFinished)
        {
            return;
        }

        if (isPlayerOne)
        {
            _playerOneChoice = choice;

            _isPlayerOneSelected = true;
        }
        else
        {
            _playerTwoChoice = choice;

            _isPlayerTwoSelected = true;
        }

        if (_isPlayerOneSelected && _isPlayerTwoSelected)
        {
            _isRoundFinished = true;

            DetermineWinner();
        }
    }

    public void AiButtonToggle()
    {
        isVersusAi = !isVersusAi;
    }

    private void DetermineWinner()
    {
        if (_playerOneChoice == _playerTwoChoice)
        {
            SendState?.Invoke(State.DRAW);
        }
        else if (_playerOneChoice == Figure.ROCK && _playerTwoChoice == Figure.SCISSORS ||
        _playerOneChoice == Figure.SCISSORS && _playerTwoChoice == Figure.PAPER ||
        _playerOneChoice == Figure.PAPER && _playerTwoChoice == Figure.ROCK)
        {
            SendState?.Invoke(State.PLAYER1WIN);
        }
        else
        {
            SendState?.Invoke(State.PLAYER2WIN);
        }
    }
}
