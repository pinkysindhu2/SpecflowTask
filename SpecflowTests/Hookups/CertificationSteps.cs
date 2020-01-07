using System;
using TechTalk.SpecFlow;
using SpecflowPages.Helpers;
using SpecflowPages.Pages.Profile_Tab;

namespace SpecflowTests.Hookups
{
    [Binding]
    public class CertificationSteps
    {
        [Given(@"I clicked on the Certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            Certification.clickOnCertificationTab(CommonDriver.driver);
        }

        [Given(@"One or more Certification is available")]
        public void GivenOneOrMoreCertificationIsAvailable()
        {
            Certification.clickOnCertificationTab(CommonDriver.driver);
        }

        [Given(@"my certfication has been added successfully after login and logout")]
        public void GivenMyCertficationHasBeenAddedSuccessfullyAfterLoginAndLogout()
        {

        }

        [When(@"I add a new certification")]
        public void WhenIAddANewCertification()
        {
            Certification.addNewCertification(CommonDriver.driver);
        }

        [When(@"I edit a certification")]
        public void WhenIEditACertification()
        {
            Certification.editCertification(CommonDriver.driver);
        }

        [When(@"I delete a certification")]
        public void WhenIDeleteACertification()
        {
            Certification.deleteCertification(CommonDriver.driver);
        }


        [When(@"I add a new certification without data")]
        public void WhenIAddANewCertificationWithoutData()
        {

        }

        [When(@"I add a new certification with invalid data")]
        public void WhenIAddANewCertificationWithInvalidData()
        {

        }

        [Then(@"that certification should be successfully displayed on my listings")]
        public void ThenThatCertificationShouldBeSuccessfullyDisplayedOnMyListings()
        {
            Certification.addCertificationSuccess(CommonDriver.driver);
        }

        [Then(@"I should successfully see the updated certification")]
        public void ThenIShouldSuccessfullySeeTheUpdatedCertification()
        {
            Certification.updateCertificationSuccess(CommonDriver.driver);
        }

        [Then(@"that particular certification should be deleted successfully")]
        public void ThenThatParticularCertificationShouldBeDeletedSuccessfully()
        {
            Certification.deleteCertificationSuccess(CommonDriver.driver);
        }

        [Then(@"that certification should not be displayed on my listings")]
        public void ThenThatCertificationShouldNotBeDisplayedOnMyListings()
        {

        }
    }
}
