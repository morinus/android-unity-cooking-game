using Zenject;


namespace TestAssignment
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallControllers();
        }

        private void InstallControllers()
        {

        }
    }
}