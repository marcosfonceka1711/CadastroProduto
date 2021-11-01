Antes da execução do projeto é necessário acertar a conexão com o banco de dados Mysql utilizado via Entity Framework.
A configuração do banco está na clase Startup.cs na linha 30, na ordem:
Server = IP ou endereço do servidor de banco de dados MySQL;
DataBase = None do banco de dados (schema);
Uid=Nome do usuário que tem acesso ao banco de dados;
Pwd=Senha do usuário;
Port=Porta do Servidor de banco;
--
Foi utilizado o padrão de mapeamentos (data mapping), assim é possível customizar o nome da tabela, dos campos, definir particularidades dos campos e popular a tabela com valores iniciais.
Foi utilizado o padrão Repository para implementar a persistência de forma dinâmica e o objeto da classe de repositório de produtos foi injetado para que receba instânciado na Controller via injeção de dependência (mesmo não estando em uso por estar consumindo a API, achei interessante deixar ele por injeção para demonstrar que é possível e viável).
--
Tentativa de uso do Refit mas na hora de receber a Interface por injeção de dependência, ela apresenta um erro interno que não consegui capturar. A alterarnativa foi utilizar o client RestSharp.
--
A API faz validação independente porém achei melhor usualmente falando, validar no front via JS para não consumir rotas da API desnecessariamente.
--
A tabela de pesquisa é uma partial view para não renderizar a página toda, e a recuperação dessa partial está sendo feito via Ajax. Requisições de exclusão e gravação/alteração são via JS também.
--
Usando o _ViewImports pra using do projeto e TagHelpers, assim não é preciso ficar colocando using dentro de cada view.
--
A pesquisa faz a busca pela descrição e ordena o resultado de acordo com o que está selecionado nas opções:
- Nome: ordena resultado por nome
- Estoque positivo: retorna somente produtos com estoque maior que zero que contém a descrição usada no parâmetro de pesquisa
- Estoque negativo: retorna somente produtos com estoque menor/igual a zero que contém a descrição usada no parâmetro de pesquisa.
--
Botão excluir fica dentro da alteração, onde é possível visualizar um item cadastrado, alterar e excluir (botão excluir aparece exclusivamente em modo de alteração).
--
Como implementação futura:
* pretendo fazer a separação da camada de API em outra solution;
* pretendo fazer o Refit funcionar;
* criar um aplicativo Android nativo consumindo a API para reforço de aprendizado na linguagem;
* criar um aplicativo  IOS/Swift nativo consumindo a API para conhecimento da programação IOS;
* criar um aplicativo React Native nativo consumindo a API para conhecimento da programação React Native.



