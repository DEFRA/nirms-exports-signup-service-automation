using Defra.Trade.ReMos.AssuranceService.Tests.Tools;
using BoDi;
using Defra.GC.UI.Tests.Configuration;
using TechTalk.SpecFlow;
using Defra.Trade.ReMos.AssuranceService.Tests.Data.Users;
using Defra.Trade.ReMos.AssuranceService.Tests.Pages;
using Defra.Trade.ReMos.AssuranceService.Tests.Steps;
using Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods;

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
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<DataHelperConnections, IDataHelperConnections>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UserObject, IUserObject>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UrlBuilder, IUrlBuilder>());

            // Pages
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignInPage, ISignInPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactEmailAddressPage, IBusinessContactEmailAddressPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactNamePage, IBusinessContactNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactPositionPage, IBusinessContactPositionPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessContactTelephoneNumberPage, IBusinessContactTelephoneNumberPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationPage, IApplicationPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessAddressPage, IBusinessAddressPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessNamePage, IBusinessNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PointOfDepartureEstablishmentPage, IPointOfDepartureEstablishmentPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PointOfDestinationEstablishmentPage, IPointOfDestinationEstablishmentPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<BusinessEligibilityPage, IBusinessEligibilityPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<TaskListPage, ITaskListPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<AuthorisedSignatoryPage, IAuthorisedSignatoryPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<CheckYourAnswersPage, ICheckYourAnswersPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<AuthorisedSignatoryNamePage, IAuthorisedSignatoryNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<AuthorisedSignatoryPositionPage, IAuthorisedSignatoryPositionPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<AuthorisedSignatoryEmailAddressPage, IAuthorisedSignatoryEmailAddressPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<TermsAndConditionsPage, ITermsAndConditionsPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ReceiveNotificationPage, IReceiveNotificationPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ManageAccountPage, IManageAccountPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<FooterPage, IFooterPage>());
        }

        private TU GetBaseWithContainer<T, TU>() where T : TU =>
        (TU)Activator.CreateInstance(typeof(T), _objectContainer);
    }
}