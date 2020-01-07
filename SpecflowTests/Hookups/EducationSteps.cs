using System;
using TechTalk.SpecFlow;
using SpecflowPages.Pages.Profile_Tab;
using SpecflowPages.Helpers;

namespace SpecflowTests.Hookups
{
    [Binding]
    public class EducationSteps
    {
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            Education.clickOnEducationTab(CommonDriver.driver);
        }

        [Given(@"One or more Education is available")]
        public void GivenOneOrMoreEducationIsAvailable()
        {
            Education.checkIfEducationAvailable(CommonDriver.driver);
        }

        [When(@"I add a new education")]
        public void WhenIAddANewEducation()
        {
            Education.addNewEducation(CommonDriver.driver);
        }

        [When(@"I edit a education")]
        public void WhenIEditAEducation()
        {
            Education.editEducation(CommonDriver.driver);
        }

        [When(@"I delete education")]
        public void WhenIDeleteEducation()
        {
            Education.deleteEducation(CommonDriver.driver);
        }

        [When(@"I add a new education without data")]
        public void WhenIAddANewEducationWithoutData()
        {

        }

        [When(@"I add a new education with invalid data")]
        public void WhenIAddANewEducationWithInvalidData()
        {

        }

        [Then(@"that education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            Education.addEducationSuccess(CommonDriver.driver);
        }

        [Then(@"I should successfully see the updated education")]
        public void ThenIShouldSuccessfullySeeTheUpdatedEducation()
        {
            Education.updateEducationSuccess(CommonDriver.driver);
        }

        [Then(@"that particular education should be deleted successfully")]
        public void ThenThatParticularEducationShouldBeDeletedSuccessfully()
        {
            Education.deleteEducationSuccess(CommonDriver.driver);
        }

        [Then(@"that education should not be displayed on my listings")]
        public void ThenThatEducationShouldNotBeDisplayedOnMyListings()
        {

        }
    }
}
