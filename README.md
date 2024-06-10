# FiapTeste
Segue Teste Para .NET full stack


# 1 Passo
Ao Baixar os arquivos do sistema, ir na pasta "sqlserver", dentro desta pasta 
abrir o "InitSemDocker.sql" e executar as instrucoes sql para criar o banco de dados
e suas tabelas.


# 2 Passo -  Apos Rodar as intrucoes do banco Acessar o arquivo appsettings.json da Api. 
este arquivo esta locando em /src/WebApi/appsettings.json
ao abrir o appsettings.json Existe um tag 'DBConnection'
esta tag e a string de conheção que o sistema ira usar como paramentro para conectar no banco
altere para essa string conforme a sua necessidade


# 3 Passo - com isso feito agora devemos executar 2 comando para rodar a webApi.
agora navegue ate o diretorio /src/WebApi/
ao entrar dentro do diretorio  execute os seguintes comandos dentro do CLI ou Prompt
   # 1 - dotnet restore
   # 2 - dotnet Run

O primeiro comando ira restaurar as depdencias do projeto e o segundo ira rodar a API
para verificar se esta funcionando no pronto automaticamente o sistema ira mostrar
que uma porta localhost:5093 esta online. Tente acessar http://localhost:5093/api/ListaAluno
Ps o numero da porta pode mudar. na linha de comando o sistema diz qual porta esta rodando

# 4 Passo - Os próximos passos são basicamente os mesmos, porém na nossa aplicação front-end.
navegue ate o diretorio /src/FrontEnd.Fiap
ao entrar dentro do diretorio  execute os seguintes comandos dentro do CLI ou Prompt
   # 1 - dotnet restore
   # 2 - dotnet Run
   
verificar qual qual porta o sistema ira rodar e acessar pode estar na porta 
http://localhost:5152, na linha de comando o sistema diz qual esta rodando


# REQUESITOS DO SISTEMA

* .NET 8 SDK
* SQLSERVER
  

