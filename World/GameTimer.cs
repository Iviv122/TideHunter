using System;
using Modules;
using UnityEngine;
using VContainer.Unity;

namespace World
{
    public class GameTimer : ITickable
    {
        public event Action TimeOut;
        readonly public CountdownTimer timer;
        private bool started = false;
        int init = 300;
        public GameTimer(Radar radar)
        {
            radar.OnStart += Start;

            timer = new(init);
            timer.OnTimerStop = () =>
            {
                Debug.Log("Victory!");
                TimeOut?.Invoke();
            };
            started = false;
        }
        public void Start()
        {
            started = true;
            Debug.Log("trial started");
            timer.Start();
        }
        void ITickable.Tick()
        {
            if (started)
            {
                timer.Tick(Time.deltaTime);
                Debug.Log("Elaborate left: " + timer.Time);
            }

        }
    }
}
