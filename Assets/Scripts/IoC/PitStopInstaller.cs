using Assets.Scripts.Events;
using Assets.Scripts.Player;
using UniRx;
using Zenject;

namespace Assets.Scripts.IoC
{
	public class PitStopInstaller : MonoInstaller
	{
		public PlayerInput input;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<Event>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<IncrementDeathCount>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<LogEvent>>().AsSingle();
			Container.BindInterfacesAndSelfTo<Subject<AddPoints>>().AsSingle();
      Container.BindInterfacesAndSelfTo<Subject<ShipEvent>>().AsSingle();
		}
	}
}
