using System.ComponentModel;

namespace Modules
{
    public class ModuleFactory
    {
        public Module GetModule(ModuleType type)
        {
            switch (type)
            {
                case ModuleType.Battery:
                    return new Battery();
                case ModuleType.Cooler:
                    return new Cooler();
                case ModuleType.Generator:
                    return new Generator();
                case ModuleType.Lights:
                    return new Lights();
                case ModuleType.Radar:
                    return new Radar();
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
    public enum ModuleType
    {
        Battery,
        Cooler,
        Generator,
        Lights,
        Radar
    }
}