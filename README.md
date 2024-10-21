# Gerenciamento de Trens
# Dotnet C#

## :computer: O Projeto

Desenvolver uma API com Dotnet e C#, em que seja possível realizar um CRUD de Trens e de Veículos.

Cada Trem pode ter ou não um ou vários Veículos, e um Veículo pode ter ou não um ou vários Trens.

Tanto Veiculo quanto Trem deve estar associado a um usuário.

Foi utilizador um banco de dados local SQL Server para armazenamento de dados e testes.

### :gear: Funcionalidades

Nesta primeira versão, estão disponíveis as seguintes funcionalidades:

- :white_check_mark: **CRUD Trens**: Adicionar, atualizar, listar e remover Trens.

- :white_check_mark: **CRUD Veículos**: Adicionar, atualizar, listar e remover Veículos.

- :white_check_mark: **CRUD Usuários**: Adicionar, atualizar, listar e remover Veículos.

- :white_check_mark: **Authorization / Authentication**: Uso de token para acesso a API e controle de funções baseado no tipo do usuário (admin/user).

### :bookmark_tabs: Conceitos abordados

- Construção de uma API sem a utilização da API Minima do CSharp.

- Utilização do `Swagger` para documentar a API.

- Relacionamentos um para um e muitos para muitos.

- Abordagem da construção de APIs utilizando Controllers e DTOs.

- Utilização do JWT.

- Autorização e autenticação.

### :label: Notas

- O desenvolvimento deste projeto é para fins de complementação de estudos portanto, há melhorias e funções a serem implementadas para melhorar o código.

## :rocket: Tecnologias

-  [Swagger](https://swagger.io/docs/)
-  [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
-  [Dotnet](https://dotnet.microsoft.com/pt-br/)
