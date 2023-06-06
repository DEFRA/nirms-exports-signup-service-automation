using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessPage
    {
        public void ClickOnRegisteredAddres();

        public void ClickOnSaveAndContinuebuttonWithoutAddress();

        public void EnterInvalidAddress();

        public void ClickOnEligiblity();

        public void SelectCountry();

        public void EntertheAddress();

        public string SelectWithoutCountryAndVerifyMessage();

        public void ClickonBusiness();

        public void EnterBusinessName();

        public void EnterInvalidBusinessName();

        public string ValidateInvalidErrorMessage();

        public string WithoutBusinessNameValidation();

        public void WithoutBusinessName();

        public void ClickonBusinessBacklink();

        public void ClickonSaveContinuelaterlink();

        public string VerifyUserinTaskListPage();

        public List<string> ErrorValidation();

        //public void ClickSignedOut();

        //public bool IsSignedOut();
    }
}