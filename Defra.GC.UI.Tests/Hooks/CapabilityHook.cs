﻿using Defra.GC.UI.Tests.Capabilities;
using BoDi;
using Defra.GC.UI.Tests.Configuration;
using TechTalk.SpecFlow;

namespace Defra.GC.UI.Tests.Hooks
{
    [Binding]
    public class CapabilityHook
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public CapabilityHook(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = (int)HookRunOrder.Capability)]
        public void BeforeScenario()
        {
            var seleniumGrid = ConfigSetup.BaseConfiguration.UiFrameworkConfiguration.SeleniumGrid;

            if (seleniumGrid.Contains("browserstack", StringComparison.InvariantCultureIgnoreCase))
                _objectContainer.RegisterInstanceAs(LoadCapabilityClass<BrowserStackCapability, IDriverOptions>());
            else
                _objectContainer.RegisterInstanceAs(LoadCapabilityClass<ChromeCapability, IDriverOptions>());
        }

        private TU LoadCapabilityClass<T, TU>() where T : TU =>
            (TU)Activator.CreateInstance(typeof(T), ConfigSetup.BaseConfiguration, _scenarioContext);
    }

}
