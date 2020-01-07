using System;
using TechTalk.SpecFlow;
using SpecflowPages.Helpers;
using SpecflowPages.Pages.Profile_Tab;

namespace SpecflowTests.Hookups
{
    [Binding]
    public class LanguageSteps
    {
        [Given(@"I clicked on the language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            Language.clickOnLangTab(CommonDriver.driver);
        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            Language.addNewLang(CommonDriver.driver);
        }


        [Given(@"One or more language is available")]
        public void GivenOneOrMoreLanguageIsAvailable()
        {
            Language.checkIfLangAvailable(CommonDriver.driver);
        }


        [When(@"I edit a lanaguage")]
        public void WhenIEditALanaguage()
        {
            Language.editLanguage(CommonDriver.driver);
        }

        [When(@"I delete a lanaguage")]
        public void WhenIDeleteALanaguage()
        {
            Language.deleteLanguage(CommonDriver.driver);

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            Language.addLangSuccess(CommonDriver.driver);
        }


        [Then(@"I should successfully see the updated lanaguage")]
        public void ThenIShouldSuccessfullySeeTheUpdatedLanaguage()
        {
            Language.updateLangSuccess(CommonDriver.driver);
        }

        [Then(@"that particular language should be deleted successfully")]
        public void ThenThatParticularLanguageShouldBeDeletedSuccessfully()
        {
            Language.deleteLangSuccess(CommonDriver.driver);
        }
    }
}
