using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.Hookups
{
    [Binding]
    public class AddServiceSteps
    {
        [Given(@"I am on Profile Details Page")]
        public void GivenIAmOnProfileDetailsPage()
        {
            
        }
        
        [Given(@"Empty Service form is listed")]
        public void GivenEmptyServiceFormIsListed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have filled the form with the valid data")]
        public void GivenIHaveFilledTheFormWithTheValidData()
        {
            
        }

        [Given(@"There are one or more service list on ManageList page")]
        public void GivenThereAreOneOrMoreServiceListOnManageListPage()
        {
            
        }


        [When(@"I have clicked on the Share Skill button")]
        public void WhenIHaveClickedOnTheShareSkillButton()
        {
            
        }
        
        [When(@"I have clicked on Save button")]
        public void WhenIHaveClickedOnSaveButton()
        {
            
        }

        [When(@"I have clicked one of the service")]
        public void WhenIHaveClickedOneOfTheService()
        {
            
        }


        [Then(@"I should successfully naviaged to Service Listing Form")]
        public void ThenIShouldSuccessfullyNaviagedToServiceListingForm()
        {
            
        }
        
        [Then(@"I should successfully created a Service to share")]
        public void ThenIShouldSuccessfullyCreatedAServiceToShare()
        {
            
        }

        [Then(@"I should successfully see the Service list with Seller's Profile pic and Name")]
        public void ThenIShouldSuccessfullySeeTheServiceListWithSellerSProfilePicAndName()
        {
            
        }

    }
}
