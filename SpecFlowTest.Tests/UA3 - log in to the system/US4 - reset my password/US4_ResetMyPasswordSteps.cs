using System;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Tests.UA3___log_in_to_the_system.US4___reset_my_password
{
    [Binding]
    public class US4_ResetMyPasswordSteps
    {
        [Given(@"I have forgotten my password")]
public void GivenIHaveForgottenMyPassword()
{
    ScenarioContext.Current.Pending();
}

        [When(@"I press the Reset Password button")]
public void WhenIPressTheResetPasswordButton()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"I should receive an email with a new password")]
public void ThenIShouldReceiveAnEmailWithANewPassword()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"my password in the database should be updated")]
public void ThenMyPasswordInTheDatabaseShouldBeUpdated()
{
    ScenarioContext.Current.Pending();
}
    }
}
