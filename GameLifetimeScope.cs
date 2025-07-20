using Modules;
using VContainer;
using VContainer.Unity;
using UnityEngine;
public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] SOModuleList moduleList;
    [SerializeField] Radar radar;
    protected override void Configure(IContainerBuilder builder)
    {
        // Content
        builder.Register<Base.Building>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<World.GameTimer>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<World.Win>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<ModuleManager>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

        builder.RegisterInstance(moduleList);
        builder.RegisterInstance(radar);
        // UI
        builder.RegisterComponentInHierarchy<UI.Clock>();
        builder.RegisterComponentInHierarchy<UI.SimpleTermoMeter>();
        builder.RegisterComponentInHierarchy<UI.PowerProductionMeter>();
        builder.RegisterComponentInHierarchy<UI.BatteryChargeMeter>();
        builder.RegisterComponentInHierarchy<UI.GeneratorFuelPercent>();

        // In Game
        builder.RegisterComponentInHierarchy<Hand>();
        builder.RegisterComponentInHierarchy<Events.PowerSwitch>();
        builder.RegisterComponentInHierarchy<Interact.ItemPickUp>();
        builder.RegisterComponentInHierarchy<Events.ConsumeItem>();

    }
}
