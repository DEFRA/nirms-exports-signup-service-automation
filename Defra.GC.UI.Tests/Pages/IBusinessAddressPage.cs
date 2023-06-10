using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessAddressPage
    {
        public void ClickOnRegisteredAddres();

        public void EntertheAddressmanually(string add1, string town, string postcode);

        public void ClickOnEligiblity();

        public string ValidateInvalidErrorMessage();

        public void ClickonBusinessBacklink();

        public string VerifyUserinTaskListPage();

        public string VerifyAddressStatus();

        public List<string> ErrorValidation();

        //public void ClickSignedOut();

        //public bool IsSignedOut();
    }
}