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

        public void EnterBusinessAddress(string add1, string town, string postcode);

        public void ClickOnSaveAndContinue();

        public string ValidateInvalidErrorMessage();

        public void ClickonBusinessBacklink();

        public string VerifyUserinTaskListPage();

        public bool VerifyAddressStatus(string status);

        public List<string> ErrorValidation();
        public void EditBusinessAddress(string businessAddr, string businessTown, string addrPostcode);
    }
}