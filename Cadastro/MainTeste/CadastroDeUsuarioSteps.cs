using System;
using System.Threading;
using Cadastro.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Cadastro
{
    [Binding]
    public class CadastroDeUsuarioSteps
    {
        // Declarando IWebDriver e Chamando classes para instanciar objeto.
        IWebDriver browser;
        PreenchimentoPage validacao;
        MensagemSucesso mensagemValidacao;

        // Tag para executar o método antes do cenário.
        [BeforeScenario]

        // Método de inicialização do navegador Chrome.
        public void Init()
        {
            this.browser = new ChromeDriver(); // Abrir aba.
            validacao = new PreenchimentoPage(browser); // Criar uma instancia de preenchimento.
            mensagemValidacao = new MensagemSucesso(browser); // Criar uma instancia para validar a mensagem.
        }
        [Given(@"que estou na pagina de cadastro")]
        public void DadoQueEstouNaPaginaDeCadastro()
        {
            // Função que inicia no navegador a URL informada.
            validacao.acesso("https://automacaocombatista.herokuapp.com/users/new");
        }
        
        [When(@"preencher somente nome eemail como campo obrigátorio")]
        public void QuandoPreencherSomenteNomeEemailComoCampoObrigatorio(Table table)
        {
            // Preenchimento de valores com base nos dados da .feature 
            validacao.preencherDados(table.Rows[0][0].ToString(), table.Rows[0][1].ToString());
        }
        
        [When(@"clicar em criar")]
        public void QuandoClicarEmCriar()
        {
            // Chamada da função para Criar o cadastrado com base no valor da URL. 
            validacao.botaoCriar("commit");
            Thread.Sleep(1000);
        }
        
        [Then(@"visualizo a mensagem: (.*) errors proibiu que este usuário fosse salvo:")]
        public void EntaoVisualizoAMensagemErrorsProibiuQueEsteUsuarioFosseSalvo(int p0)
        {
            // Validação de mensagem.
            // Neste caso a validação não será possível pois o site não retorna a mensagem esperada referente a um erro encontrado
            // Para validar o codigo basta seguir os dados conforme aparece na conclusão do site
            //mensagemValidacao.mensagemSucesso("Usuário Criado com sucesso", "notice");
            mensagemValidacao.mensagemSucesso("2 errors proibiu que este usuário fosse salvo", "error_explanation");
        }
        // Método para fechar e limpar a memória depois de executar o cenário.
        [AfterScenario]
        public void Close()
        {
            this.browser.Close();
            this.browser.Dispose();
        }
    }
}
