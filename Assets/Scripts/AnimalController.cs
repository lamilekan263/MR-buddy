using UnityEngine;

public class AnimalController : MonoBehaviour
{

    private enum _animalState
    {
        IDLE, // breathing 0
        PLAYING, // playing 1
        WALKING01, // walking1 2
        WALKING02, // walking1 3
        RUNNING, //running 4
        EATING, // eating 5
        ANGRY, //angry 6
        SITTING, // sitting 7
    }

    private _animalState _currentState;
    private Animator _animator;


    private void Start()

    {
        _animator = GetComponent<Animator>();
        if (!_animator)
        {
            Debug.Log("animator component not found");
            return;
        }

        SetAnimation(0, _animalState.IDLE);
    }


    private void SetAnimation(int _animationId, _animalState _newState)
    {
        if (_currentState == _newState) return;

        _animator.SetInteger("AnimationID", _animationId);
        _currentState = _newState;
    }


}
