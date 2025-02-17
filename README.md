Explicações sobre o projeto.

Como se pode perceber o projeto está incompleto, mas tentarei explicar a linha de raciocínio e alguns motivos pelo ocorrido.

O maior erro foi iniciar o projeto diretamente pela API e não pelas especificações iniciais mais simples, devido a minha maior facilidade para trabalhar dessa forma.
A ideia inicial era criar um Background Service acionado pela API, podendo ser estartado e pausado conforme o status do serviço do micro-ondas.
Após cada interação do Background Service seria disparado via Hub, utilizando SingnalR, uma notificação para que a aplicação client pudesse receber a resposta e processar a entrega para o usuário.

Tive um bloqueio muito grande durante o desenvolvimento do projeto, passei por momentos complicados envolvendo a perca de familiares muito próximos.
Isso me acarretou uma dificuldade grande no raciocínio até de pequenas coisas, como, por exemplo, passar de 2 a 3 horas tentando fazer o Background Service funcionar somente por não injetar ele como singleton.

Por questão do tempo que ficou curto e da dificuldades em manter uma linha de raciocínio já comentadas acima, pude somente desenvolver um esboço da API com algumas regras de negócio.

Peço desculpas pelo inconveniente e caso ainda haja possibilidade de apresentar alguma coisa diferente, me coloco à disposição para conversarmos.
