using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessNamePage
    {
        public void ClickOnRegisteredAddres();

        public void ClickOnSaveAndContinue();

        public void EnterBusinessName(string businessname);

        public void EnterInvalidAddress();

        public void ClickOnEligiblity();

        public void SelectCountry();

        public void EntertheAddress();

        public string SelectWithoutCountryAndVerifyMessage();

        public bool VerifyErrorMessageOnBusinessNamePage(string errorMessage);

        public void ClickonBusiness();

        public void EnterInvalidBusinessName();

        public string ValidateInvalidErrorMessage();

        public string WithoutBusinessNameValidation();

        public void WithoutBusinessName();

        public void ClickonBusinessBacklink();

        public void ClickonSaveContinuelaterlink();

        public string VerifyUserinTaskListPage();

        public List<string> ErrorValidation();

        public bool VerifyBusinessNameStatus(string status);
    }
}