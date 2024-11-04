# README - Aplicação de Gerenciamento de Ativos de TI

## Descrição do Projeto
Este projeto é uma aplicação web desenvolvida em ASP.NET Core com Entity Framework Code First, destinada ao gerenciamento de ativos de TI em uma empresa. A aplicação permite que os usuários cadastrem-se, façam login utilizando suas credenciais ou através de autenticação social com Facebook e Google. Os usuários podem registrar ativos, visualizar dashboards e gerenciar informações relacionadas a equipamentos de tecnologia.

## Entidades
A aplicação possui as seguintes entidades, cada uma com seus respectivos relacionamentos:

### Ativo
- **Propriedades**: Id, Nome, Descrição, Fabricante, Modelo, Número de Série, Data de Aquisição, Valor, Localização, Status, ResponsávelId, DepartamentoId, FornecedorId.
- **Relacionamentos**:
  - Muitos-para-um com Departamento
  - Muitos-para-um com Fornecedor
  - Muitos-para-um com Funcionario

### Departamento
- **Propriedades**: Id, Nome, Descrição.
- **Relacionamentos**:
  - Um para muitos com Funcionario
  - Um para muitos com Ativo

### Funcionario
- **Propriedades**: Id, Nome, Cargo, DepartamentoId, Email, Senha.
- **Relacionamentos**:
  - Muitos-para-um com Departamento
  - Um para muitos com Ativo

### Fornecedor
- **Propriedades**: Id, Nome, Contato, Endereço.
- **Relacionamentos**:
  - Um para muitos com Ativo
  - Um para muitos com Garantia

### Garantia
- **Propriedades**: Id, DataInicio, DataFim, FornecedorId, AtivoId.
- **Relacionamentos**:
  - Um para um com Ativo
  - Muitos-para-um com Fornecedor

### Licenca
- **Propriedades**: Id, Nome, Tipo, NumeroSerie, DataAquisicao, DataExpiracao, Software, AtivoId.
- **Relacionamentos**:
  - Muitos-para-um com Ativo

### Manutencao
- **Propriedades**: Id, Data, Descrição, Custo, AtivoId.
- **Relacionamentos**:
  - Muitos-para-um com Ativo

## Validações
A aplicação implementa as seguintes validações:
- **Validação de Campos Obrigatórios**: Todos os campos obrigatórios devem ser preenchidos.
- **Formato de Datas**: Datas devem estar no formato correto (por exemplo, dd/MM/yyyy).
- **Datas Não Estão no Futuro**: A data de aquisição e outras datas não podem ser no futuro.
- **Validação de Unicidade do Departamento**: Não pode haver departamentos com o mesmo nome.
- **Validação de Tamanho de Caracteres**: Limitações de caracteres para campos específicos (ex: Nome, Descrição).

## Telas da Aplicação
A aplicação possui duas telas públicas:
- **Registro**: Para novos usuários se cadastrarem.
- **Dashboard**: Para visualizar informações sobre os ativos.

Outras telas exigem que o usuário esteja logado.

## Passos para Execução

### Pré-requisitos
- .NET SDK instalado
- Banco de dados (SQL Server ou similar)

### Configuração do Ambiente
1. Clone o repositório
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd <NOME_DA_PASTA>
2. Restaure os pacotes NuGet
   ```bash
   dotnet restore 
4. Atualize a string de conexão No arquivo appsettings.json, atualize a string de conexão para o seu banco de dados:
   "ConnectionStrings": { "DefaultConnection": "Server=<SEU_SERVIDOR>;Database=<NOME_DO_BANCO>;User Id=<SEU_USUARIO>;Password=<SUA_SENHA>;"}
5. Execute as Migrations Para criar o banco de dados e as tabelas, execute:
   dotnet ef database update
7. Inicie a aplicação

## Acesso à Aplicação
### Acesse a aplicação em seu navegador através do seguinte URL:

##Autenticação
Os usuários podem se cadastrar utilizando um formulário de registro ou fazer login utilizando o Facebook ou Google. As opções de login estão disponíveis na tela de login da aplicação.
