using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalisadorDeSequenciasWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 1. Gerar Tabuada utilizando o ciclo FOR
        private void btnGerarTabuada_Click(object sender, RoutedEventArgs e)
        {
            lstResultados.Items.Clear(); // Limpa resultados anteriores

            if (int.TryParse(txtNumero.Text, out int num))
            {
                lstResultados.Items.Add($"=== TABUADA DO {num} ===");
                for (int i = 1; i <= 10; i++)
                {
                    int resultado = num * i;
                    lstResultados.Items.Add($"{num} x {i,2} = {resultado}");
                }
                lstResultados.Items.Add($"Total de elementos gerados: {lstResultados.Items.Count - 1}");
            }
            else
            {
                MessageBox.Show("Por favor, introduza um número inteiro válido.",
                                "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // 2. Analisar Array utilizando o ciclo FOREACH
        private void btnProcessarArray_Click(object sender, RoutedEventArgs e)
        {
            lstResultados.Items.Clear();

            // Declaração e inicialização de um Array estático de notas
            double[] notas = { 12.5, 8.0, 15.0, 18.5, 9.5, 14.0 };
            double soma = 0;
            int aprovados = 0;

            lstResultados.Items.Add("=== ANÁLISE DE NOTAS DA TURMA ===");

            foreach (double nota in notas)
            {
                string estado = nota >= 9.5 ? "Aprovado" : "Reprovado";
                if (nota >= 9.5) aprovados++;

                lstResultados.Items.Add($"Nota: {nota,4:F1}v  -->  Status: {estado}");
                soma += nota;
            }

            double media = soma / notas.Length;
            lstResultados.Items.Add("----------------------------------------");
            lstResultados.Items.Add($"Média da Turma: {media:F2} valores");
            lstResultados.Items.Add($"Total de Aprovados: {aprovados} de {notas.Length} alunos");
        }


        // 3. Limpar Lista
        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            lstResultados.Items.Clear();
        }

        // =========================================================================
        // Exercício 1: Somatório e contagem com ciclo WHILE
        // =========================================================================
        private void btnSomatorioWhile_Click(object sender, RoutedEventArgs e)
        {
            lstResultados.Items.Clear(); // Limpa resultados anteriores

            // Validação de entrada para garantir que lê o número N da caixa de texto
            if (int.TryParse(txtNumero.Text, out int n) && n > 0)
            {
                int soma = 0;
                int i = 1;

                // Executa o cálculo acumulado de 1 até N utilizando o ciclo while
                while (i <= n)
                {
                    soma += i;
                    i++;
                }

                // Apresenta o resultado final na ListBox
                lstResultados.Items.Add($"=== SOMATÓRIO (CICLO WHILE) ===");
                lstResultados.Items.Add($"Número N introduzido: {n}");
                lstResultados.Items.Add($"Cálculo: 1 + 2 + ... + {n}");
                lstResultados.Items.Add("----------------------------------------");
                lstResultados.Items.Add($"A soma de todos os inteiros é: {soma}");
            }
            else
            {
                MessageBox.Show("Por favor, introduza um número inteiro maior que 0 no campo 'Número limite/N'.",
                                "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // =========================================================================
        // Exercício 2: Pesquisa de valor Máximo num Array
        // =========================================================================
        private void btnMaximoArray_Click(object sender, RoutedEventArgs e)
        {
            lstResultados.Items.Clear();

            // Dado o array de valores decimais estipulado pelo enunciado
            double[] valores = { 14.5, 22.0, 9.8, 31.4, 18.2 };

            // Assume-se inicialmente que o primeiro elemento é o maior
            double maximo = valores[0];

            // Algoritmo utilizando o ciclo 'foreach' para determinar o maior valor
            foreach (double valor in valores)
            {
                if (valor > maximo)
                {
                    maximo = valor;
                }
            }

            // Exibe o resultado e a lista completa para conferência visual
            lstResultados.Items.Add($"=== PESQUISA DE VALOR MÁXIMO ===");
            lstResultados.Items.Add("Elementos analisados no Array: [ " + string.Join(" | ", valores) + " ]");
            lstResultados.Items.Add("----------------------------------------");
            lstResultados.Items.Add($"O valor máximo encontrado é: {maximo}");
        }

        // =========================================================================
        // Exercício 3 (Desafio): Filtragem e Formatação de Strings em WPF
        // =========================================================================
        private void btnFiltrarLetra_Click(object sender, RoutedEventArgs e)
        {
            lstResultados.Items.Clear();

            // Declaração do array de nomes de alunos fornecido
            string[] alunos = { "Ana", "Bruno", "Carla", "Daniel", "Beatriz", "Bernardo" };

            // Validação para garantir que o utilizador digitou uma letra de pesquisa
            string filtroText = txtLetraFiltro.Text.Trim();
            if (string.IsNullOrEmpty(filtroText))
            {
                MessageBox.Show("Por favor, introduza uma letra para efetuar a filtragem.",
                                "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Isolar o caracter introduzido em maiúscula para uma comparação uniforme
            char letraAlvo = char.ToUpper(filtroText[0]);
            int correspondencias = 0;

            lstResultados.Items.Add($"=== ALUNOS COMEÇADOS POR '{letraAlvo}' ===");

            // Ciclo 'foreach' para procurar os critérios exigidos
            foreach (string nome in alunos)
            {
                // Verifica se a string não está vazia e se inicia pela letra pretendida (ignora maiúsculas/minúsculas)
                if (!string.IsNullOrEmpty(nome) && char.ToUpper(nome[0]) == letraAlvo)
                {
                    lstResultados.Items.Add($"• {nome}");
                    correspondencias++;
                }
            }

            lstResultados.Items.Add("----------------------------------------");
            lstResultados.Items.Add($"Total de alunos encontrados: {correspondencias}");
        }
    }
}