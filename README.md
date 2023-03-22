# Credit Suisse Test - Trade

Teste feito por William Mazzilli
Foi utilizado o Clean Architecture para a organização dos arquivos, o SOLID para o organização do código.

## Organização dos projetos
Foram criados 5 projetos para atender a solicitação, Sendo 2 essenciais para o projeto, as outras são complementares

 - **App** - Esta camada contém a lógica específica da aplicação e utiliza as entidades de domínio para implementar as regras de negocio.
 - **Domain** - Esta camada contém as entidades de domínio da aplicação.
 - **Api** - Esta camada disponibiliza a camada de aplicação para ser utilizada usando RestApi, e cuida das implementações refentes apenas a API.
 - **App.Tests** - Contem os testes unitários do App.
 - Benchmark - Apenas para os testes de performasse específicos da aplicação.

## Application
A classe TradeCategorizer classifica o risco de cada Trade.
Ela Recebe 2 parâmetros, o primeiro o valor de referencia para o calculo do risco e o segundo as classificações. Hoje a regra implementada aceita 3 tipos de risco, mas da maneira que foi feita, se necessária novas implementações, ja estaria pronta para receber mais ou menos classificações.


