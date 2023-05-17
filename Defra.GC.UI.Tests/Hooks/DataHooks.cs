﻿using BoDi;
using Defra.GC.UI.Test.Data.Configuration;
using Defra.GC.UI.Tests.Configuration;

using TechTalk.SpecFlow;

namespace Defra.GC.UI.Tests.Hooks
{
    [Binding]
    public class DataHooks
    {

        private readonly IObjectContainer _objectContainer;

        public DataHooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario(Order = (int)HookRunOrder.Data)]
        public void BeforeScenario()
        {
            BindAllPages();
        }

        private void BindAllPages()
        {
            // Data
            //_objectContainer.RegisterInstanceAs(GetBase<ApplicationData, IApplicationData>());
        }

        private TU GetBase<T, TU>() where T : TU =>
            (TU)Activator.CreateInstance(typeof(T));

    }

}
