using System;
namespace Base
{
    public class StatModifier : IDisposable
    {
        public StatType StatType { get; }
        public IOperationalStrategy Operation { get; }
        public event Action<StatModifier> OnDispose = delegate { };
        readonly CountdownTimer timer;
        public bool MarkedForRemoval;
        public StatModifier(StatType statType, IOperationalStrategy operation, float duration)
        {
            StatType = statType;
            Operation = operation;
            if (duration <= 0) return;

            timer = new CountdownTimer(duration);
            timer.OnTimerStop += () => MarkedForRemoval = true;
            timer.Start();
        }
        public void Tick(float deltaTime) => timer?.Tick(deltaTime);
        public void Handle(Querry querry)
        {
            querry.Value = Operation.Calculate(querry.Value);
        }
        public void Dispose()
        {
            OnDispose.Invoke(this);
        }
    }

}