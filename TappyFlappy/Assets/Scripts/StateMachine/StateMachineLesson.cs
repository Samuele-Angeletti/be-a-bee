using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class StateMachineLesson<T> where T : Enum
    {
        private Dictionary<T, State> _allStates = new Dictionary<T, State>();
        private State _currentState;
        public State CurrentState => _currentState;
        public void RegisterState(T stateType, State state)
        {
            if (_allStates.ContainsKey(stateType))
                throw new Exception($"Esiste gi? uno stato {stateType}");


            _allStates.Add(stateType, state);
        }

        public void SetState(T stateType)
        {
            if(!_allStates.ContainsKey(stateType))
            {
                throw new Exception($"Lo stato {stateType} non esiste");
            }

            _currentState?.OnEnd();

            _currentState = _allStates[stateType];
            _currentState.OnBegin();
        }

        public void OnUpdate() => _currentState?.OnUpdate();

        public void OnFixedUpdate() => _currentState?.OnFixedUpdate();
       
    }
}
