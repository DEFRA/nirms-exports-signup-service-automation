using Defra.GC.UI.Tests.Configuration;
using Defra.Trade.ReMos.AssuranceService.Tests.Capabilities;
using NUnit.Framework;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Tests
{
    [TestFixture]
    public class BrowserStackCapabilityTests
    {
        [TestCase("Chrome", "chrome")]
        [TestCase("Edge", "MicrosoftEdge")]
        [TestCase("Firefox", "firefox")]
        [TestCase("Safari", "safari")]
        public void UsesW3CCapabilitiesForBrowserStack(string target, string browserName)
        {
            var capability = new BrowserStackCapability(CreateConfiguration(target), null!);
            var capabilities = capability.GetDriverOptions().ToCapabilities();
            var browserStack = (Dictionary<string, object>)capabilities.GetCapability("bstack:options");

            Assert.Multiple(() =>
            {
                Assert.That(capabilities.GetCapability("browserName"), Is.EqualTo(browserName));
                Assert.That(capabilities.GetCapability("browserVersion"), Is.EqualTo("latest"));
                Assert.That(capabilities.GetCapability("acceptInsecureCerts"), Is.True);
                Assert.That(browserStack["os"], Is.EqualTo("Windows"));
                Assert.That(browserStack["osVersion"], Is.EqualTo("11"));
                Assert.That(browserStack["userName"], Is.EqualTo("test-user"));
                Assert.That(browserStack["accessKey"], Is.EqualTo("test-key"));
                foreach (var legacyKey in new[] { "browser:", "browser_version:", "os:", "os_version:", "autoGrantPermission:", "acceptSslCerts" })
                    Assert.That(capabilities.GetCapability(legacyKey), Is.Null, legacyKey);
                Assert.That(browserStack.ContainsKey("acceptInsecureCerts"), Is.False);
            });
        }

        [Test]
        public void CanCreateCapabilitiesMoreThanOnce()
        {
            var capability = new BrowserStackCapability(CreateConfiguration("Chrome"), null!);
            capability.GetDriverOptions();

            Assert.DoesNotThrow(() => capability.GetDriverOptions());
        }

        [Test]
        public void ReportsUnsupportedBrowserTarget()
        {
            var capability = new BrowserStackCapability(CreateConfiguration("Unsupported"), null!);

            Assert.Throws<ArgumentException>(() => capability.GetDriverOptions());
        }

        private static BaseConfiguration CreateConfiguration(string target) => new()
        {
            UiFrameworkConfiguration = new UiFrameworkConfiguration { Target = target },
            TestConfiguration = new TestConfiguration
            {
                DeviceName = "Windows",
                BSOSVersion = "11",
                Project = "test-project",
                Build = "test-build"
            },
            BrowserStackConfiguration = new BrowserStackConfiguration
            {
                CloudDeviceUserName = "test-user",
                CloudDeviceUserKey = "test-key"
            }
        };
    }
}
