using System;
using TechTalk.SpecFlow;
using SpecflowPages.Pages.Profile_Tab;
using SpecflowPages.Helpers;

namespace SpecflowTests.Hookups
{
    [Binding]
    public class DescriptionSteps
    {
        [Given(@"I clicked on the Description tab under Profile page")]
        public void GivenIClickedOnTheDescriptionTabUnderProfilePage()
        {
            Description.clickOnDescription(CommonDriver.driver);
        }
        
        [When(@"I save a short summary")]
        public void WhenISaveAShortSummary()
        {
            Description.saveDescription(CommonDriver.driver);
        }
        
        [When(@"I add a new Description")]
        public void WhenIAddANewDescription()
        {
            
        }
        
        [When(@"I click on cancel button")]
        public void WhenIClickOnCancelButton()
        {
            
        }
        
        [When(@"I save without a short description")]
        public void WhenISaveWithoutAShortDescription()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I save a very long description")]
        public void WhenISaveAVeryLongDescription()
        {
            
        }
        
        [When(@"I save a edited description")]
        public void WhenISaveAEditedDescription()
        {
            
        }
        
        [Then(@"that short summary should be displayed on my listings")]
        public void ThenThatShortSummaryShouldBeDisplayedOnMyListings()
        {
            Description.savedSuccess(CommonDriver.driver);
        }
        
        [Then(@"Error message should be displayed to ask to enter a description")]
        public void ThenErrorMessageShouldBeDisplayedToAskToEnterADescription()
        {
            
        }
        
        [Then(@"that long description should not be accepted")]
        public void ThenThatLongDescriptionShouldNotBeAccepted()
        {
            
        }
        
        [Then(@"that description should be successfully updated")]
        public void ThenThatDescriptionShouldBeSuccessfullyUpdated()
        {
           
        }
    }
}
