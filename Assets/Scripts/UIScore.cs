using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerOneScoreText;
    [SerializeField] private TextMeshProUGUI _playerTwoScoreText;
    [SerializeField] private TextMeshProUGUI _endRoundMessageText;
    [TextArea(minLines: 2, maxLines: 4)]
    [SerializeField] private string _gameContinueMessage = "<color=green>Нажмите на экран для продолжения.</color>";
    private int _playerOneCurrentScore = 0;
    private int _playerTwoCurrentScore = 0;
    private void OnEnable()
    {
        GameManager.SendState += OnState;
    }

    private void OnDisable()
    {
        GameManager.SendState -= OnState;
    }

    private void Awake()
    {
        SetScore(_playerOneScoreText, _playerOneCurrentScore, _playerTwoCurrentScore);
        SetScore(_playerTwoScoreText, _playerTwoCurrentScore, _playerOneCurrentScore);
    }

    private void OnState(State state)
    {
        if (state == State.PLAYER1WIN)
        {
            _playerOneCurrentScore++;
            _endRoundMessageText.SetText("<color=white>Игрок 1 выиграл!</color>\n \n" + _gameContinueMessage);
        }
        else if (state == State.PLAYER2WIN)
        {
            _playerTwoCurrentScore++;
            _endRoundMessageText.SetText("<color=black>Игрок 2 выиграл!</color>\n \n" + _gameContinueMessage);
        }
        else if (state == State.DRAW)
        {
            _endRoundMessageText.SetText("<color=red>Ничья!</color>\n \n" + _gameContinueMessage);
        }
        else
        {
            _endRoundMessageText.SetText("");
        }

        SetScore(_playerOneScoreText, _playerOneCurrentScore, _playerTwoCurrentScore);
        SetScore(_playerTwoScoreText, _playerTwoCurrentScore, _playerOneCurrentScore);
    }
    
    private void SetScore(TextMeshProUGUI text, int player1Score, int player2Score)
    {
        text.SetText($"{player1Score.ToString()} / {player2Score.ToString()}");
    }
}
