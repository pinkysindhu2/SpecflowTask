using System;
using TechTalk.SpecFlow;
using SpecflowPages.Pages.Skill_Search;
using SpecflowPages.Helpers;

namespace SpecflowTests.Hookups
{
    [Binding]
    public class SkillSearchSteps
    {

        [Given(@"Enter Cypress into Search bar on Home page")]
        public void GivenEnterCypressIntoSearchBarOnHomePage()
        {
            SkillSearch.typeIntoSearchBar(CommonDriver.driver);
        }

        [Given(@"I should successfully seen seller’s profile pic and name")]
        public void GivenIShouldSuccessfullySeenSellerSProfilePicAndName()
        {
            SkillSearch.sellerInfoOnCard(CommonDriver.driver);
        }

        [Given(@"I have clicked on the one of the Listed Services")]
        public void GivenIHaveClickedOnTheOneOfTheListedServices()
        {
            SkillSearch.clickOnListedService(CommonDriver.driver);
        }

        [Given(@"Seller’s profile info is on right hand side of Service Listing Page")]
        public void GivenSellerSProfileInfoIsOnRightHandSideOfServiceListingPage()
        {
            SkillSearch.isSellerInfoOnServiceListingPg(CommonDriver.driver);
        }

        [When(@"I have clicked on Search button")]
        public void WhenIHaveClickedOnSearchButton()
        {
            SkillSearch.clickOnSearchIcon(CommonDriver.driver);
        }

        [When(@"I have clicked on either of seller’s pic or name")]
        public void WhenIHaveClickedOnEitherOfSellerSPicOrName()
        {
            SkillSearch.clickOnSellerInfoOnRsltPg(CommonDriver.driver);
        }

        [When(@"I have clicked on Seller's profile")]
        public void WhenIHaveClickedOnSellerSProfile()
        {
            SkillSearch.clickOnSellerOnServiceListingPg(CommonDriver.driver);
        }

        [Then(@"I should see services regarding my search")]
        public void ThenIShouldSeeServicesRegardingMySearch()
        {
            SkillSearch.searchSuccess(CommonDriver.driver);
        }

        [Then(@"I should successfully see Seller’s profile in more detailed way")]
        public void ThenIShouldSuccessfullySeeSellerSProfileInMoreDetailedWay()
        {
            SkillSearch.detailedSellerInfo(CommonDriver.driver);
        }
    }
}
