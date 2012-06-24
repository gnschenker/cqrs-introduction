using System.Linq;

namespace CqrsIntroduction
{
    public static class RedirectToWhen
    {
        public static void Invoke(object self, ICommand<IIdentity> command)
        {
            self.GetType()
                .GetMethods()
                .Where(m => m.Name == "When")
                .Single(m => m.GetParameters()[0].ParameterType == command.GetType())
                .Invoke(self, new object[] { command });
        }
    }
}
