# Objetivo

## Proposta 

O 'novo' sistema de cadastro de jogadores do UOL precisa de uma nova cara! Isso porque a área de lazer da empresa definiu que todo jogador deverá ter um codinome. A proposta foi um sucesso e muitos candidatos se inscreveram, por isso a área de lazer acabou restringindo os codinomes em duas listas distintas: "Os Vingadores" e "A Liga da Justiça".

Seu desafio é elaborar um sistema em Java capaz de:

1. Permitir o cadastro de jogadores de acordo com os codinomes contidos nos links de referência vingadores.json e liga_da_justica.xml
2. Apresentar um cadastro contendo nome, e-mail e telefone do jogador (sendo que nome e e-mail são obrigatórios)
3. Persistir a informação cadastrada em um banco de dados em memória, como HSQLDB ou arquivo
4. Obter, a qualquer momento, a lista de todos os jogadores cadastrados com seus respectivos codinomes e também a informação de qual lista o codinome foi extraído
5. Impedir a utilização de um mesmo codinome para diferentes usuários (a menos que o codinome seja para listas diferentes)
6. Incluir o codinome escolhido dentro das listas Os Vingadores ou A Liga da Justiça
7. Obrigatoriamente, ler a informação do codinome em arquivos na internet (links abaixo). Atenção: não vale guardar a informação do codinome localmente (em um arquivo, em uma classe, em um banco de dados etc.)

## Arquitetura de referência

![alt text](https://raw.githubusercontent.com/uolhost/test-backEnd-Java/master/referencias/arquitetura.png)

## Links dos arquivos de referência
https://raw.githubusercontent.com/uolhost/test-backEnd-Java/master/referencias/liga_da_justica.xml
https://raw.githubusercontent.com/uolhost/test-backEnd-Java/master/referencias/vingadores.json

### Casos de uso

+ Cadastro com sucesso:
	1. O usuário 'Felipe' cadastra seu nome, e-mail e telefone, e escolhe a lista vingadores.json
	2. O sistema recebe o cadastro e verifica se há codinomes disponíveis na lista vingadores.json
	3. O sistema encontra um codinome livre e o escolhe
	4. O sistema persiste nome, e-mail, telefone, codinome e arquivo de referência em um banco de dados em memória ou em um arquivo
	5. O sistema informa que o usuário foi cadastrado corretamente e mostra uma imagem de sucesso
	
+ Lista escolhida não tem codinomes disponíveis:
	1. O usuário 'João' cadastra seu nome, e-mail e telefone, e escolhe a lista liga_da_justica.xml
	2. O sistema recebe o cadastro e verifica se há codinomes disponíveis na lista liga_da_justica.xml
	3. O sistema não encontra um codinome livre
	4. O sistema informa que aquela lista não possui mais usuários disponíveis

+ Relatório de usuários cadastrados:
	1. O usuário 'Luís' clica em “Visualizar relatório de jogadores”
	2. O sistema consulta o banco de dados em memória ou em arquivo
	3. O sistema apresenta todos os usuários cadastrados. Cada linha tem as informações: nome, e-mail, telefone, codinome e arquivo referência
	
## Regras
1. Você poderá utilizar o Java em qualquer versão :)
2. Você poderá utilizar quaisquer frameworks da linguagem Java :)
3. Para persistir as informações, você poderá utilizar um banco de dados em memória gerenciado por você ou utilizar um banco, como HSQLDB.
4. Você também pode optar por gravar em arquivo.
5. Não vale utilizar o codinome de um mesmo arquivo mais de uma vez.
6. Detalhes como criação de testes unitários, ordenação da lista de cadastrados ou filtro da lista são opcionais. Mas, se você fizer iremos apreciar! =)

## Tecnologias

#### Backend

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white)![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white) 

#### Frontend

![Angular](https://img.shields.io/badge/angular-%23DD0031.svg?style=for-the-badge&logo=angular&logoColor=white) ![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white)![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white) 

## Solução proposta

Ao realizar este projeto pude rever e fixar diversos conceitos que são utilizados no meu trabalho, e nos meus estudos diários como: 

- Reforçar os fundamentos do C#;
- Reforçar os fundamentos da Orientação a objetos;
- Entender melhor o Entity Framework e como ele trabalha;
- Injeção de dependência;
- Fluxo do desenvolvimento de uma API utilizando o Pattern CQRS + Mediator;
- Containers (Docker);
- MySql;

Assim como o aprendizado de novos conceitos, como:

- Consumo de APIs;
- Background Service;
- Banco de dados em memória;
- Scope Factory;
- Funções assíncronas;

# Funcionamento

## Endpoints

Consome a lista de Vingadores disponibilizada:

```` 
/vingadores/externo
````

![Consumo Api](C:\Users\gabriel.santos\Downloads\ezgif.com-gif-maker.gif)

Consome a lista da Liga da Justiça disponibilizada:

```` 
/liga/externo
````

![Consome liga](C:\Users\gabriel.santos\Downloads\ezgif.com-gif-maker (1).gif)
