using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using BoDi;
using Defra.GC.UI.Tests.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class WebDriverHookTests
    {
        private ObjectContainer _container = null!;
        private ScenarioContext _context = null!;
        private WebDriverHook _hook = null!;

        [SetUp]
        public void SetUp()
        {
            _container = new ObjectContainer();
            _container.RegisterInstanceAs(new ScenarioInfo("Driver setup failure", string.Empty,
                Array.Empty<string>(), new OrderedDictionary()));
            _container.RegisterInstanceAs<ITestObjectResolver>(new TestObjectResolver());
            _context = _container.Resolve<ScenarioContext>();
            _hook = new WebDriverHook(_context, _container, new TestOutputHelper());
            typeof(ScenarioContext).GetProperty(nameof(ScenarioContext.TestError))!
                .SetValue(_context, new WebDriverException("Session creation failed"));
        }

        [TearDown]
        public void TearDown() => _container.Dispose();

        [Test]
        public void SetupFailureDoesNotCauseATeardownError()
        {
            Assert.DoesNotThrow(() => _hook.AfterScenario());
        }

        [Test]
        public void QuitsBrowserEvenWhenScreenshotFails()
        {
            var driver = DispatchProxy.Create<IWebDriver, ScreenshotFailureDriver>();
            var proxy = (ScreenshotFailureDriver)driver;
            _hook.Driver = driver;

            Assert.Throws<WebDriverException>(() => _hook.AfterScenario());
            Assert.That(proxy.QuitCalled, Is.True);
            Assert.That(_hook.Driver, Is.Null);
        }

        [Test]
        public async Task RemoteSessionFailureRetainsServerError()
        {
            using var server = new TcpListener(IPAddress.Loopback, 0);
            server.Start();
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var endpoint = (IPEndPoint)server.LocalEndpoint;
            var responseTask = Task.Run(async () =>
            {
                using var client = await server.AcceptTcpClientAsync(timeout.Token);
                await using var stream = client.GetStream();
                using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
                var contentLength = 0;
                string? line;
                while (!string.IsNullOrEmpty(line = await reader.ReadLineAsync(timeout.Token)))
                {
                    if (line.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
                        contentLength = int.Parse(line.Substring("Content-Length:".Length).Trim());
                }
                var body = new char[contentLength];
                await reader.ReadBlockAsync(body.AsMemory(), timeout.Token);
                const string json = """{"value":{"error":"session not created","message":"Test grid rejected the session","stacktrace":""}}""";
                var response = Encoding.UTF8.GetBytes(
                    $"HTTP/1.1 500 Internal Server Error\r\nContent-Type: application/json\r\nContent-Length: {Encoding.UTF8.GetByteCount(json)}\r\nConnection: close\r\n\r\n{json}");
                await stream.WriteAsync(response, timeout.Token);
            }, timeout.Token);

            try
            {
                var exception = Assert.Throws<InvalidOperationException>(() =>
                    WebDriverHook.CreateDriver(new ChromeOptions(), $"http://127.0.0.1:{endpoint.Port}/"));

                Assert.That(exception!.Message, Does.Contain("Test grid rejected the session"));
                await responseTask;
            }
            finally
            {
                timeout.Cancel();
                server.Stop();
            }
        }

        public class ScreenshotFailureDriver : DispatchProxy, ITakesScreenshot
        {
            public bool QuitCalled { get; private set; }

            public Screenshot GetScreenshot() => throw new WebDriverException("Screenshot failed");

            protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
            {
                if (targetMethod?.Name == nameof(IWebDriver.Quit))
                {
                    QuitCalled = true;
                    return null;
                }
                throw new NotSupportedException(targetMethod?.Name);
            }
        }

        private class TestOutputHelper : ISpecFlowOutputHelper
        {
            public void WriteLine(string message) => TestContext.WriteLine(message);
            public void WriteLine(string format, params object[] args) => TestContext.WriteLine(format, args);
            public void AddAttachment(string filePath) => TestContext.AddTestAttachment(filePath);
        }
    }
}
