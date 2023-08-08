﻿
using System.Data.SqlClient;

namespace Defra.GC.UI.Tests.Configuration
{
    public class BaseConfiguration
    {
        public TestConfiguration TestConfiguration { get; set; }
        public UiFrameworkConfiguration UiFrameworkConfiguration { get; set; }
        public BrowserStackConfiguration BrowserStackConfiguration { get; set; }
        public BackendSetupConfig BackendSetupConfig { get; set; }
        public SqlConnection ApplicationCon { get; set; }
        public AppConnectionString AppConnectionString { get; set; }

    }
}
