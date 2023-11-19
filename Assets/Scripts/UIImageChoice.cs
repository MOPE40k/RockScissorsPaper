using UnityEngine;
using UnityEngine.UI;

public class UIImageChoice : MonoBehaviour
{
    [SerializeField] private Sprite _rockSprite;
    [SerializeField] private Sprite _scissorsSprite;
    [SerializeField] private Sprite _paperSprite;
    [SerializeField] private Image _playerOneImage;
    [SerializeField] private Image _playerTwoImage;

    private void OnEnable()
    {
        ChoiceFigure.SendChoice += OnChoice;
    }

    private void OnDisable()
    {
        ChoiceFigure.SendChoice -= OnChoice;
    }

    private void OnChoice(Figure figure, bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            SetSelectedImage(figure, _playerOneImage);
        }
        else
        {
            SetSelectedImage(figure, _playerTwoImage);
        }
    }

    private void SetSelectedImage(Figure choice, Image target)
    {
        switch (choice)
        {
            case Figure.ROCK:
                target.sprite = _rockSprite;
                break;
            case Figure.SCISSORS:
                target.sprite = _scissorsSprite;
                break;
            case Figure.PAPER:
                target.sprite = _paperSprite;
                break;
        }
    }
}
