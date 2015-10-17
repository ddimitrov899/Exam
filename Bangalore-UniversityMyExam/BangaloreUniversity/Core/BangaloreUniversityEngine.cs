namespace BangaloreUniversity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BangaloreUniversity.Data;
    using BangaloreUniversity.Infrastructure;
    using BangaloreUniversity.Interfaces;
    using BangaloreUniversity.Models;

    public class BangaloreUniversityEngine : IEngene
    {
        public void Run()
        {
            var bangaloreUniversityDate = new BangaloreUniversityDate();
            User user = null;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                var route = new Route(line);
                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                    type => type.Name == route.ControllerName);

                var controller = Activator.CreateInstance(controllerType, bangaloreUniversityDate, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] parameters = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(p =>
            {
                if (p.ParameterType == typeof(int))
                {
                    return int.Parse(route.Parameters[p.Name]);
                }
                else
                {
                    return route.Parameters[p.Name];
                }
            }).ToArray();
        }
    }
}