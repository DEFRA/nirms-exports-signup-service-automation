using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using BoDi;
using Defra.GC.UI.Tests.Configuration;
using TechTalk.SpecFlow;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;

namespace Defra.GC.UI.Tests.Hooks
{
    [Binding]
    public class PageHooks
    {

        private readonly IObjectContainer _objectContainer;

        public PageHooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario(Order = (int)HookRunOrder.Pages)]
        public void BeforeScenario()
        {
            BindAllPages();
        }
        private void BindAllPages()
        {
            // Objects
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UserObject, IUserObject>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UrlBuilder, IUrlBuilder>());

            // Pages 
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignInPage, ISignInPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactEmailAddressPage, IBusinessContactEmailAddressPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactNamePage, IBusinessContactNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactPositionPage, IBusinessContactPositionPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactTelephoneNumberPage, IBusinessContactTelephoneNumberPage>());
        }


        private TU GetBaseWithContainer<T, TU>() where T : TU =>
        (TU)Activator.CreateInstance(typeof(T), _objectContainer);
    }
}
