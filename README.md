# Gerenciamento de Trens
# Dotnet C#

## :computer: O Projeto

Desenvolver uma API com Dotnet e C#, em que seja poss�vel realizar um CRUD de Trens e de Ve�culos.

Cada Trem pode ter ou n�o um ou v�rios Ve�culos, e um Ve�culo pode ter ou n�o um ou v�rios Trens.

Tanto Veiculo quanto Trem deve estar associado a um usu�rio.

Foi utilizador um banco de dados local SQL Server para armazenamento de dados e testes.

### :gear: Funcionalidades

Nesta primeira vers�o, est�o dispon�veis as seguintes funcionalidades:

- :white_check_mark: **CRUD Trens**: Adicionar, atualizar, listar e remover Trens.

- :white_check_mark: **CRUD Ve�culos**: Adicionar, atualizar, listar e remover Ve�culos.

- :white_check_mark: **CRUD Usu�rios**: Adicionar, atualizar, listar e remover Ve�culos.

- :white_check_mark: **Authorization / Authentication**: Uso de token para acesso a API e controle de fun��es baseado no tipo do usu�rio (admin/user).

### :bookmark_tabs: Conceitos abordados

- Constru��o de uma API sem a utiliza��o da API Minima do CSharp.

- Utiliza��o do `Swagger` para documentar a API.

- Relacionamentos um para um e muitos para muitos.

- Abordagem da constru��o de APIs utilizando Controllers e DTOs.

- Utiliza��o do JWT.

- Autoriza��o e autentica��o.

### :label: Notas

- O desenvolvimento deste projeto � para fins de complementa��o de estudos portanto, h� melhorias e fun��es a serem implementadas para melhorar o c�digo.

## :rocket: Tecnologias

-  [Swagger](https://swagger.io/docs/)
-  [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
-  [Dotnet](https://dotnet.microsoft.com/pt-br/)
