using UnityEngine;
using Base;
using System;

namespace Modules
{
    abstract public class Module : ScriptableObject
    {
        public event Action<bool> OnStateChange;
        virtual public void Start()
        {

        }
        virtual public void Tick(float deltaTime)
        {

        }
        abstract public void TurnOn(Building building);
        abstract public void TurnOff(Building building);
        virtual public void BlackOut(Building building)
        {

        }
        abstract public void SwitchState(Building building);
        public void StateChange(bool state)
        {
            OnStateChange?.Invoke(state);
        }

    }
}
