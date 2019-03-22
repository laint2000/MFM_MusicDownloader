using MfmTop20.App_Start.Testing;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;

namespace MfmTop20.App_Start
{
    class NinjectKernel
    {
        internal static StandardKernel CreateKernel(string[] args)
        {
            NinjectModule module = CreateNinjectModule(args);

            var moduleParameter = module ?? new RegisterModule();
            return new StandardKernel(moduleParameter);
        }

        private static NinjectModule CreateNinjectModule(string[] args)
        {
            var arguments = new Queue<string>(args);

            while (arguments.Count > 0)
            {
                var param = arguments.Dequeue().ToUpper();

                switch (param)
                {
                    case "-TEST": return new RegisterModule_FakeHttp();
                    case "-TEST_ERRORS": return new RegisterModule_FakeHttpWithErrors();
                }
            }

            return null;
        }
    }
}