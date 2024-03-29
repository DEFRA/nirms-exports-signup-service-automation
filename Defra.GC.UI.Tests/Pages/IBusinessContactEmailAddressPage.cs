﻿namespace Defra.Trade.ReMos.AssuranceService.Tests.Pages
{
    public interface IBusinessContactEmailAddressPage
    {
        public void ClickOnContactEmailAddressLink();
        public void ClickOnSaveAndContinue();
        public void EnterEmailAddress(string emailAddress);
        public bool VerifyErrorMessageOnContactEmailAddressPage(string errorMessage);
    }
}
