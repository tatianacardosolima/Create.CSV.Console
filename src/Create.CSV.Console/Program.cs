
// Caminho do arquivo a ser criado
using static System.Runtime.InteropServices.JavaScript.JSType;

string empresa = "XPTO";
DateTime start_month = new DateTime(2024, 08, 01);
DateTime end_month = new DateTime(2024, 08, 31);
string filePath = $@"C:\_DEV\GitHubPortifolio\Create.CSV.Console\src\Create.CSV.Console\csv\{empresa}-{start_month:dd-MM-yyyy}.csv";

// Conteúdo a ser escrito no arquivo
List<string> linhas = new List<string>();

linhas.Add("Tipo de Relatório: Medidas Consolidadas; ; ; ; ; ; ; ; ; ;");
linhas.Add("Tipo de Agente: Conectante | Nome: MAGAZINE LUIZA S/A; ; ; ; ; ; ; ; ; ;");
linhas.Add($"Periodo Solicitado de {start_month:dd/MM/yyyy 00:00} até {end_month:dd/MM/yyyy 00:00}; ; ; ; ; ; ; ; ; ;");
linhas.Add("Ponto de Medição; Data de Consolidação; Hora de Consolidação; Tipo de Energia; Ativa Geração; Ativa Consumo; Reativa Geração; Reativa Consumo; Qt Intervalos Faltantes; Situação da Medida; Motivo da Situação");

try
{
    for (DateTime dataAtual = start_month; dataAtual <= end_month; dataAtual = dataAtual.AddDays(1))
    {
        for (var x = 1; x <= 24; x++)
        {
            linhas.Add($"{empresa};{dataAtual:dd/MM/yyyy};{x};Liquida;0;3123;0;0;0;Hora Completa Consistente;Consistido");
        }
        
    }
    // Verifica se o diretório existe, caso contrário, cria
    string directory = Path.GetDirectoryName(filePath);
    if (!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);
    }

    // Cria e escreve o arquivo texto
    File.WriteAllLines(filePath, linhas);

    Console.WriteLine($"Arquivo '{filePath}' gerado com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}