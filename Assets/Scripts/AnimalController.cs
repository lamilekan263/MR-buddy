using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{


    [SerializeField]
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

    private Dictionary<_animalState, int> _mapAnimalStateToId = new Dictionary<_animalState, int>
    {
        {_animalState.IDLE, 0},
        {_animalState.PLAYING, 1},
        {_animalState.WALKING01, 2},
        {_animalState.WALKING02, 3},
        {_animalState.RUNNING, 4},
        {_animalState.EATING, 5},
        {_animalState.ANGRY, 6},
        {_animalState.SITTING, 7},
    };
    [SerializeField]
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
        _currentState = _animalState.WALKING01;
        SetAnimation(_currentState);
        Debug.Log(_currentState + "currentState");
    }

    private void Update()
    {
        SetAnimation(_currentState);
    }

    private void SetAnimation(_animalState _newState)
    {
        Debug.Log(_mapAnimalStateToId[_newState] + " state number");
        Debug.Log($"{_currentState}-currentState ${_newState}-newState");
        // if (_currentState == _newState) return;

        _animator.SetInteger("AnimationID", _mapAnimalStateToId[_newState]);
        _currentState = _newState;
    }


}
