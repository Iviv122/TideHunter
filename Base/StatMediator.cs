using System;
using System.Collections.Generic;
using System.Linq;
namespace Base
{
    public class StatsMediator
    {
        readonly public List<StatModifier> listModifiers = new();
        public event Action OnModifierAdd;
        public event Action OnModifierRemove;
        public void AddModifier(StatModifier modifier)
        {
            listModifiers.Add(modifier);
            modifier.MarkedForRemoval = false;

            modifier.OnDispose += _ =>
            {
                listModifiers.Remove(modifier);
                OnModifierRemove?.Invoke();
            };
            OnModifierAdd?.Invoke();
        }
        public void PerformQuerry(Querry query)
        {
            foreach (StatModifier mod in listModifiers)
            {
                if (mod.StatType == query.StatType)
                {
                    mod.Handle(query);
                }
            }
        }
        public void Tick(float deltaTime)
        {
            foreach (StatModifier mod in listModifiers)
            {
                mod.Tick(deltaTime);
            }

            foreach (StatModifier mod in listModifiers.Where(modifier => modifier.MarkedForRemoval).ToList())
            {
                mod.Dispose();
            }
        }

    }

}