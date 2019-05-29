#language: pt

Funcionalidade: Cadastro de Usuário
    Sendo um usuário do site
    Posso acessar o site de Automação
    Para realizar cadastros de um novo usuário


Cenario: Cadastro com sucesso
Dado que estou na pagina de cadastro
Quando preencher somente nome e email como campo obrigátorio
|Nome|Email|
|Fernanda|fernanda12456@gmail.com.br|
E clicar em criar
Então visualizo a mensagem: 2 errors proibiu que este usuário fosse salvo:
