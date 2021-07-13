using System;
using System.Collections.Generic;

namespace csharpExpert.features
{
    public class IoC : IFeature
    {
        private static readonly bool debugMode = true;
        public void ShowFeature()
        {
            "IoC - inversion of control".WriteLine();
            Container c = new Container();
            
            c.Register<ILogger>(x=> debugMode ? new TerminalLogger() : new DataBaseLogger());
            c.Register<Worker>(x=> new Worker(x.Create<ILogger>()));

            var worker = c.Create<Worker>();
            worker.DoWork();            
        }
        
        public interface ILogger
        {
            void Log(string x);
        }
        public class TerminalLogger : ILogger
        {
            public void Log(string x) => Console.WriteLine($"logging \"{x}\" in the terminal");
        }

        public class DataBaseLogger : ILogger
        {
            public void Log(string x) => Console.WriteLine($"logging \"{x}\" in the database");
        }
        
        public class Worker
        {
            private readonly ILogger _logger;
        
            public Worker(ILogger logger)
            {
                _logger = logger;
            }

            public void DoWork()
            {
                for (int i = 0; i < 500; i++) ;
                _logger.Log("task 1: DONE.");
                for (int i = 0; i < 750; i++) ;
                _logger.Log("task 2: DONE.");
                for (int i = 0; i < 1000; i++) ;
                _logger.Log("task 3: DONE.");
                for (int i = 0; i < 1250; i++) ;
                _logger.Log("task 4: DONE.");
            }
        }
        
        // this is the IoC container
        public class Container
        {
            public Dictionary<Type, Func<Container, object>> Registrations
            {
                get;
            } = new();

            public void Register<T>(Func<Container, object> creator)
            {
                Registrations.Add(typeof(T), creator);
            }

            public T Create<T>()
            {
                return (T) Registrations[typeof(T)](this);
            }
        }
    }
}