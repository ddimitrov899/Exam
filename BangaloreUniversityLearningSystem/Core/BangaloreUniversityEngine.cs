using System;
using System.Linq;
using System.Reflection;
using Data;
using BangaloreUniversityLearningSystem.Infrastructure;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem.Core
{
    public class BangaloreUniversityEngine : IEngen
    {
        public void Run()
        {
            var bangaloreUniversityDate = new BangaloreUniversityDate();
            User user = null;
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }
                var route = new Route(url);
                var controllerType =
                    Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(type => type.Name == route.ControllerName);
                var ctrl = Activator.CreateInstance(controllerType, bangaloreUniversityDate, user) as Controller;
                var act = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, act);
                try
                {
                    var view = act.Invoke(ctrl, @params) as IView;
                    Console.WriteLine(view.Display());
                    user = ctrl.User;
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
                if (p.ParameterType == typeof (int)) return int.Parse(route.Parameters[p.Name]);
                else return route.Parameters[p.Name];
            }).ToArray();
        }
    }
}