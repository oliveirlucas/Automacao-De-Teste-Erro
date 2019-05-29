using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Cadastro.PageObject
{
    public class PreenchimentoPage
    {
        private IWebDriver browser;

        // Instanciando o objt.
        public PreenchimentoPage(IWebDriver browser)
        {
            this.browser = browser;
        }
    
        // Recebendo a URL e informando ao navegador.
        public PreenchimentoPage acesso(String url)
        {
            browser.Navigate().GoToUrl(url);
            return this;
        }

        // Recebendo os dados de preenchimento e inserido nos campos.
        public PreenchimentoPage preencherDados(String nome, String email)
        {
            browser.FindElement(By.Id("user_name")).SendKeys(nome);
            browser.FindElement(By.Id("user_email")).SendKeys(email);
            
            return this;
        }
        
        // Recebendo parametro do botao criar e executando ação de Click.
        public PreenchimentoPage botaoCriar(String param)
        {
            browser.FindElement(By.Name(param)).Click();
            return this;
        }
    }
}
