using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    // [Header("Player ONE animators")]
    // [SerializeField] private Animator _playerOneChoiceAnimator;
    // [SerializeField] private Animator _playerOneSelectAnimator;
    // [Header("Player TWO animators")]
    // [SerializeField] private Animator _playerTwoChoiceAnimator;
    // [SerializeField] private Animator _playerTwoSelectAnimator;
    // private void OnEnable()
    // {
    //     GameLogic.SendState += PlayAnimation;
    // }
    // private void OnDisable()
    // {
    //     GameLogic.SendState -= PlayAnimation;
    // }
    // private void PlayAnimation(State state)
    // {
    //     if (state == State.IDLE)
    //     {
    //         _playerOneChoiceAnimator.Play("PlayerOneChoiceMoveForward");
    //         _playerTwoChoiceAnimator.Play("PlayerTwoChoiceMoveForward");
    //         _playerOneSelectAnimator.Play("PlayerOneSelectedImageMoveBackward");
    //         _playerTwoSelectAnimator.Play("PlayerTwoSelectedImageMoveBackward");
    //     }
    //     else
    //     {
    //         _playerOneChoiceAnimator.Play("PlayerOneChoiceMoveBackward");
    //         _playerTwoChoiceAnimator.Play("PlayerTwoChoiceMoveBackward");
    //         _playerOneSelectAnimator.Play("PlayerOneSelectedImageMoveForward");
    //         _playerTwoSelectAnimator.Play("PlayerTwoSelectedImageMoveForward");
    //     }
    // }
    [Header("Player ONE animators")]
    [SerializeField] private Animator _playerOneChoiceAnimator;
    [SerializeField] private Animator _playerOneSelectedImageAnimator;
    [Header("Player TWO animators")]
    [SerializeField] private Animator _playerTwoChoiceAnimator;
    [SerializeField] private Animator _playerTwoSelectedImageAnimator;
    private void OnEnable()
    {
        GameManager.SendState += PlayAnimation;
    }
    private void OnDisable()
    {
        GameManager.SendState -= PlayAnimation;
    }
    private void PlayAnimation(State state)
    {
        if (state == State.STARTROUND)
        {
            _playerOneChoiceAnimator.Play("PlayerOneChoiceMoveForward");
            _playerTwoChoiceAnimator.Play("PlayerTwoChoiceMoveForward");
            _playerOneSelectedImageAnimator.Play("PlayerOneSelectedImageMoveBackward");
            _playerTwoSelectedImageAnimator.Play("PlayerTwoSelectedImageMoveBackward");
        }
        else
        {
            _playerOneChoiceAnimator.Play("PlayerOneChoiceMoveBackward");
            _playerTwoChoiceAnimator.Play("PlayerTwoChoiceMoveBackward");
            _playerOneSelectedImageAnimator.Play("PlayerOneSelectedImageMoveForward");
            _playerTwoSelectedImageAnimator.Play("PlayerTwoSelectedImageMoveForward");
        }
    }
}
