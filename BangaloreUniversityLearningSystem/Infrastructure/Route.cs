namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Interfaces;

    public class Route : IRoute
    {
        private string actionName;

        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
            this.ActionName = this.actionName;
        }

        public IDictionary<string, string> Parameters { get; set; }

        public string ActionName
        {
            get
            {
                return this.actionName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                this.actionName = value;
            }
        }

        public string ControllerName { get; set; }

        private void Parse(string routeUrl)
        {
            string[] parts = routeUrl.Split(
                new[] { "/", "?" },
                StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                throw new InvalidOperationException("The provided route is invalid.");
            }

            this.ControllerName = parts[0] + "Controller";
            this.ActionName = parts[1];
            if (parts.Length >= 3)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = parts[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    string[] nameValue = pair.Split('=');
                    this.Parameters.Add(WebUtility.UrlDecode(nameValue[0]), WebUtility.UrlDecode(nameValue[1]));
                }
            }
        }
    }
}