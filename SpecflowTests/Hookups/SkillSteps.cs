using System;
using TechTalk.SpecFlow;
using SpecflowPages.Helpers;
using SpecflowPages.Pages.Profile_Tab;

namespace SpecflowTests.Hookups
{
    [Binding]
    public class SkillSteps
    {
        [Given(@"I clicked on the Skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            Skill.clickOnSkillTab(CommonDriver.driver);
        }

        [Given(@"One or more Skill is available")]
        public void GivenOneOrMoreSkillIsAvailable()
        {
            Skill.checkIfSkillAvailable(CommonDriver.driver);
        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            Skill.addNewSkill(CommonDriver.driver);
        }

        [When(@"I edit a skill")]
        public void WhenIEditASkill()
        {
            Skill.editSkill(CommonDriver.driver);
        }

        [When(@"I delete skill")]
        public void WhenIDeleteSkill()
        {
            Skill.deleteSkill(CommonDriver.driver);
        }

        [When(@"I add a new skill without data")]
        public void WhenIAddANewSkillWithoutData()
        {

        }

        [When(@"I add a new skill with invalid data")]
        public void WhenIAddANewSkillWithInvalidData()
        {

        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            Skill.addSkillSuccess(CommonDriver.driver);
        }

        [Then(@"I should successfully see the updated skill")]
        public void ThenIShouldSuccessfullySeeTheUpdatedSkill()
        {
            Skill.updateSkillSuccess(CommonDriver.driver);
        }

        [Then(@"that particular skill should be deleted successfully")]
        public void ThenThatParticularSkillShouldBeDeletedSuccessfully()
        {
            Skill.deleteSkillSuccess(CommonDriver.driver);
        }

        [Then(@"that skill should not be displayed on my listings")]
        public void ThenThatSkillShouldNotBeDisplayedOnMyListings()
        {

        }
    }
}
