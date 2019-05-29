using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Cadastro.PageObject
{
    class MensagemSucesso
    {
        private IWebDriver browser;

        // Instanciando o objt.
        public MensagemSucesso(IWebDriver browser)
        {
            this.browser = browser;
        }

        // Validado mensagem recebida através de igualdade.
        public void mensagemSucesso(String msg, String param)
        {
            Assert.AreEqual(msg, browser.FindElement(By.Id(param)).Text);
        }

    }
}
