using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using page_framework;
using NUnit.Framework;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace Sample.Features.Pages
{
    public class LoginPage: IPage
    {

        public void Visit()
        {
            Driver.GetInstance().GoTo("http://localhost:1300");
            Assert.IsTrue(IsOn(), "We are not on the Login page.");
        }

        public bool IsOn()
        {
            return Driver.GetInstance().TableCell(Find.ByClass("Title")).Text == "Login";
        }

        private TextField UsernameField { get { return Driver.GetInstance().TextField(Find.ByName(new Regex(@"\$txtUserName"))); } }
        public string Username { get { return UsernameField.Text; } set { UsernameField.TypeFast(value); } }

        public Image ContinueButton { get { return Driver.GetInstance().Image(Find.ByName(new Regex(@"\$btnContinue"))); } }

        public void Login(string username)
        {
            Username = username;
            ContinueButton.Click();
        }

        public bool IsLoggedIn()
        {
            return Driver.GetInstance().ContainsText("Logout") == false;
        }

    }
}

