using Assets.Scripts.Player;
using Zenject;

namespace Assets.Scripts.IoC
{
	public class PitStopInstaller : MonoInstaller
	{
		public PlayerInput input;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PlayerInput>().FromInstance(input).AsSingle();
		}
	}
}
