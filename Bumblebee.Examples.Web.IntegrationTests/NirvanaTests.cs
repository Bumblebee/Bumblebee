using System;
using System.Linq;
using Bumblebee.Examples.Web.IntegrationTests.Infrastructure;
using Bumblebee.Examples.Web.Pages.Nirvana;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using NUnit.Framework;

namespace Bumblebee.Examples.Web.IntegrationTests
{
    [TestFixture]
    public class NirvanaTests
    {
        private const string Url = "https://www.nirvanahq.com/account/login";
        private const string ValidUsername = "bumblebee@meinershagen.net";
        private const string Password = "P@ssw0rd";

        [Test]
        public void given_valid_logged_in_user_when_adding_task_should_add_task()
        {
            Threaded<Session>
                .With<LocalChromeEnvironment>()
                .NavigateTo<LoggedOutPage>(Url)
                .Username.EnterText(ValidUsername)
                .Password.EnterText(Password)
                .Login.Click<UpgradePromptPage>()
                .NotNow.Click();

            var taskInfo = new {Name = string.Format("Task {0}", Guid.NewGuid()), Note = "This is a note."};

            Threaded<Session>
                .CurrentBlock<LoggedInPage>()
                .ToolBar
                .NewTask.Click()
                .Name.EnterText(taskInfo.Name)
                .Note.EnterText(taskInfo.Note)
                .Save.Click()
                .TaskLists.First(list => list.Name == "Actions")
                .TaskRows.First(row => row.Name == taskInfo.Name)
                .Verify("that row should exist", row => row != null)
                .Delete();

            Threaded<Session>
                .End();
        }
    }
}
