# README - Aplicação de Gerenciamento de Ativos de TI

## Descrição do Projeto
Este projeto é uma aplicação web desenvolvida em ASP.NET Core com Entity Framework Code First, destinada ao gerenciamento de ativos de TI em uma empresa. A aplicação permite que os usuários cadastrem-se, façam login utilizando suas credenciais ou através de autenticação social com Facebook e Google. Os usuários podem registrar ativos, visualizar dashboards e gerenciar informações relacionadas a equipamentos de tecnologia.

### Link para o projeto:
https://drive.google.com/file/d/18UiI2jOT6_WnHTGk8spS1DhKN071h75g/view?usp=drive_link -> inserido no domingo por não ter conseguido fazer o push do arquivo Startup.Auth.
Não consegui inserir o projeto no repositorio remoto no domingo por conta dos dados de autenticação, apenas na segunda 04/11.

## Entidades
A aplicação possui as seguintes entidades, cada uma com seus respectivos relacionamentos:

### Ativo
- **Relacionamentos**:
  - Muitos-para-um com Departamento
  - Muitos-para-um com Fornecedor
  - Muitos-para-um com Funcionario

### Departamento
- **Relacionamentos**:
  - Um para muitos com Funcionario
  - Um para muitos com Ativo

### Funcionario
- **Relacionamentos**:
  - Muitos-para-um com Departamento
  - Um para muitos com Ativo

### Fornecedor
- **Relacionamentos**:
  - Um para muitos com Ativo
  - Um para muitos com Garantia

### Garantia
- **Relacionamentos**:
  - Um para um com Ativo
  - Muitos-para-um com Fornecedor

### Licenca
- **Relacionamentos**:
  - Muitos-para-um com Ativo

### Manutencao
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
3. Atualize a string de conexão No arquivo appsettings.json, atualize a string de conexão para o seu banco de dados:
   ```bash
   "ConnectionStrings": { "DefaultConnection": "Server=<SEU_SERVIDOR>;Database=<NOME_DO_BANCO>;User Id=<SEU_USUARIO>;Password=<SUA_SENHA>;"}
4. Execute as Migrations Para criar o banco de dados e as tabelas, execute:
   ```bash
   dotnet ef database update
5. Insira os dados de autenticação(facebook e google) no arquivo Startup.Auth:
   ```bash
           app.UseFacebookAuthentication(
           appId: "1340030724025576",
           appSecret: "657fefa69af336377e8608012573bd57");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "262285794861-a4lbj64rougfr155437i576t2d6v5764.apps.googleusercontent.com",
                ClientSecret = "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",
                CallbackPath = new PathString("/signin-google")
            });
6. Inicie a aplicação

## Acesso à Aplicação
### Acesse a aplicação em seu navegador através do seguinte URL:

##Autenticação
Os usuários podem se cadastrar utilizando um formulário de registro ou fazer login utilizando o Facebook ou Google. As opções de login estão disponíveis na tela de login da aplicação.
