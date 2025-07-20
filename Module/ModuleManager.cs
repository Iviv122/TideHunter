using System.Collections.Generic;
using Base;
using UnityEngine;
using VContainer.Unity;

namespace Modules
{
    public class ModuleManager : IInitializable, ITickable
    {
        List<Module> modules = new();

        public ModuleManager(SOModuleList list)
        {
            Debug.Log("Module Manager created");
            foreach (var item in list.modules)
            {
                modules.Add(item);
            }
        }
        public void PowerOff(Building building)
        {
            foreach (var item in modules)
            {
                item.BlackOut(building);
            }
        }
        void IInitializable.Initialize()
        {
            foreach (var item in modules)
            {
                item.Start();
            }
        }
        void ITickable.Tick()
        {
            {
                foreach (var item in modules)
                {
                    item.Tick(Time.deltaTime);
                }
            }
        }
    }
}
