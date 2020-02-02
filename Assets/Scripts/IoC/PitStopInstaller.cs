using Assets.Scripts.Events;
using Assets.Scripts.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.IoC
{
	public class PitStopInstaller : MonoInstaller
	{
		public PlayerInput input;
		public GameObject slug;
		public GameObject nuke;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<Event>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<ShipPhaseEvent>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<ShipCreatedEvent>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<DamageEnemyEvent>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<IncrementDeathCount>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<LogEvent>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<AddPoints>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<ToggleDoor>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<DoorUpdated>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<OxygenCritical>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<ShakeCamera>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<SlugKilled>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<SlugSpawned>>().AsSingle();
			Container.BindFactory<Nuke, Nuke.NukeFactory>().FromComponentInNewPrefab(nuke);
			Container.BindFactory<Slug, Slug.SlugFactory>().FromComponentInNewPrefab(slug);
			Container.BindInterfacesAndSelfTo<Subject<NextWave>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<PlayerDead>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<NukeExplodes>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<ShipEnteringDock>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<ShipExitingDock>>().AsSingle();
		}
	}
}
