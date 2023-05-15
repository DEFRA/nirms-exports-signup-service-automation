using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.GC.UI.Tests.Pages
{
    public interface ISignInPage
    {
        public bool IsPageLoaded();
        public bool IsSignedIn(string userName, string password);
        public void ClickSignedOut();
        public bool IsSignedOut();
    }
}
