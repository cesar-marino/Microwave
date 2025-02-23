# Desafio MICRO-ONDAS DIGITAL

O projeto foi desenvolvido para um processo seletivo.

A ideia inicial do projeto foi criar uma API que se comunicasse com um client realizando todas as tarefas necessárias para a simulação de funcionamento de um micro-ondas.
Para o desenvolvimento utilizei o Clean Architecture para melhor organização do código.

Foi criado um serviço em background, acionado via endpoint e realiza o processamento do micro-ondas.
Para notificar o processamento foi criado serviço de notificação em tempo real utilizando a biblioteca SignalR.

Criei de forma simples e manual o sistema de autenticação da API, contando somente com o cadastro de usuário e a autenticação.

A persistência do projeto é realizada utilizando o serviço em memória do EntityFramework, tornando necessário a criação de um novo usuário a cada inicialização do sistema.

Procurei manter a regra de negócio separada das outras camadas do projeto, e consistente realizando alguns testes unitários e de integração.

## Dificuldades
##### Front-end
A última tecnologia front-end que trabalhei foi o Flutter, e devido ao tempo que não utilizo tecnologias de front-end relacionadas ao C# senti dificuldades de implementas o client, focando somente na implementação da API.
Consegui testar a API por completo utilizando o Postman e também a área de documentação do Swagger que deixei pré-configurado para inicializar ao subir o projeto.

##### Verões utilizadas
Fui avisado sobre as versões, mas devido a ter versões mais recentes instaladas no meu computador não consegui fazer o downgrade para os requisitos desejados.
Utilizei .net framework 9.0.200 e o Visual Studio 2022.

## Conclusão
Mesmo não atendendo todos os requisitos desejados no teste, acredito que pude mostrar um pouco do meu conhecimento, fico à disposição para eventuais conversas e aguardo um retorno.
Obrigado!
