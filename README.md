# Hotel Prime — App Hotel | Agenda 13

Aplicativo acadêmico de simulação de hospedagem, desenvolvido com **C# + XAML + .NET MAUI 10**, preparado para **Visual Studio Community 2026** no **Windows**.

**Desenvolvedor:** Leonardo Nunes de Souza  
**Curso:** Técnico em Desenvolvimento de Sistemas  
**Disciplina:** Programação Mobile I  
**Atividade:** Agenda 13 — Imagens e Componentes Diversos de Interface Gráfica  
**Ano:** 2026

## O que foi implementado

- Interface personalizada com azul-marinho, dourado, cartões e imagem ilustrativa local.
- **Stepper** para número de adultos e crianças, com exibição através de **BindingContext**.
- **Picker** de suítes preenchido com objetos da classe `Suite` (não fica vazio).
- **DatePicker** para check-in e check-out.
- Cálculo automático do valor da estadia e prévia do total na tela inicial.
- Validações de data, seleção e capacidade máxima de hóspedes.
- **Tela de resumo** da simulação, com dados transmitidos via `BindingContext`.
- **Nova tela Sobre** com desenvolvedor, ano, curso, tecnologias e versão.
- Navegação de ida/volta entre as telas.

## Importante: preços ilustrativos

Este projeto é uma **simulação acadêmica** e **não efetua reservas reais**. Os valores abaixo foram definidos para demonstrar o cálculo; a apostila da Agenda 13 não fornece uma tabela de preços obrigatória.

| Suíte | Diária | Hóspedes |
| --- | ---: | ---: |
| Essencial | R$ 240,00 | 2 |
| Conforto | R$ 360,00 | 4 |
| Premium | R$ 520,00 | 6 |

**Fórmula:** total = quantidade de noites × valor da diária.  
**Exemplo:** Conforto, 3 noites → R$ 1.080,00.

## Executar no Visual Studio 2026

1. Extraia o ZIP do projeto para uma pasta local (por exemplo `Documentos/Projetos/HotelPrime`). **Não execute a solução dentro do ZIP**.
2. Abra `MauiAppHotel.sln` com o **Visual Studio 2026**.
3. Confirme que a carga de trabalho **Desenvolvimento de .NET Multi-Platform App UI** está instalada, assim como o **.NET 10**.
4. Na barra superior selecione **Debug | Any CPU | Windows Machine**.
5. Recomenda-se **Ctrl + F5** (Iniciar sem Depuração), opção que funcionou no projeto da conversa. `F5` também pode funcionar, usando o perfil incluído em `Properties/launchSettings.json`.
6. Se a IDE pedir para restaurar NuGet, aceite e depois use **Compilar → Recompilar Solução**.
7. Na página inicial, clique em **SOBRE ↗** para verificar a tela solicitada na entrega.

### Se não inicializar

- Confira se o projeto selecionado é `MauiAppHotel` e o destino é **Windows Machine**.
- Confira `MauiAppHotel/Properties/launchSettings.json`: `commandName` deve ser `Project`.
- Confira `MauiAppHotel/MauiAppHotel.csproj`: `<WindowsPackageType>None</WindowsPackageType>` dentro de `PropertyGroup`.
- Não volte o projeto para `net8.0` e não acrescente Android/iOS sem necessidade: esta entrega foi preparada apenas para Windows/.NET 10.
- Consulte a lista de erros ou a saída da compilação antes de alterar configurações.

## Passo a passo de uso

1. A tela principal mostra os controles de hóspedes, suíte e datas.
2. Experimente **2 adultos**, **0 crianças**, **Suíte Conforto** e um período de **3 noites**.
3. Confira o total estimado e clique em **AVANÇAR PARA O RESUMO**.
4. Na tela de resultado, confira o valor e use **FAZER OUTRA SIMULAÇÃO** para voltar.
5. Na tela inicial clique em **SOBRE ↗**, confira desenvolvedor e ano, e use **VOLTAR AO APP**.

## Entregar ao professor

O enunciado pede **(a) link do projeto no GitHub** e **(b) pasta compactada contendo capturas de tela reais da tela Sobre executando**.

1. Abra a tela **Sobre** no aplicativo **em execução**.
2. Pressione **Win + Shift + S** para capturar a janela. Salve como `01_Tela_Sobre.png` dentro da pasta `Entrega/Capturas_Tela_Sobre`.
3. Opcionalmente, capture uma segunda imagem mostrando a navegação para a tela Sobre.
4. No Explorador de Arquivos, clique com o botão direito na pasta `Capturas_Tela_Sobre` e selecione **Enviar para → Pasta compactada** (Windows 10).
5. Publique os arquivos deste projeto em um repositório GitHub seu, por exemplo **HotelPrime-Agenda13**. Não envie as pastas `bin`, `obj` e `.vs`.
6. Entregue o link de seu repositório e o ZIP com as **capturas reais**.

**Atenção:** capturas de tela e link do GitHub devem ser produzidos no seu computador/conta. Este pacote contém todo o código-fonte e uma pasta preparada para receber as capturas, mas não finge que o aplicativo foi executado neste ambiente.

## Estrutura do projeto

```text
MauiAppHotel.sln
MauiAppHotel/
  App.xaml / App.xaml.cs
  MauiProgram.cs
  MauiAppHotel.csproj
  Models/
    Suite.cs
    Reserva.cs
  Views/
    ContratacaoHospedagem.xaml / .xaml.cs
    HospedagemContratada.xaml / .xaml.cs
    Sobre.xaml / .xaml.cs
  Platforms/Windows/
  Properties/launchSettings.json
  Resources/AppIcon, Splash, Images
Entrega/Capturas_Tela_Sobre/
```

## Base didática

A Agenda 13 trabalha com componentes visuais, `Picker`, `Stepper`, `DatePicker`, imagens e `BindingContext`. O projeto foi recriado e ampliado em relação ao layout inicial do App Hotel apresentado na apostila, com uma personalização visual própria, tela de resumo e a tela **Sobre** exigida na atividade.
