using System.Runtime.CompilerServices;

namespace AnaliseMetodoShumacher
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantidadeAmostragem = 0;
            string amostragens = string.Empty;

            Console.Write("Digite a quantidade de amostragens analisadas: ");
            quantidadeAmostragem = int.Parse(Console.ReadLine());

            Console.WriteLine();

            for(var i = 0; i < quantidadeAmostragem; i++)
            {
                Console.Write($@"{i + 1} - Resultado da análise (A, C, F): ");
                amostragens += Console.ReadLine().ToUpper()[0];
            }

            Console.WriteLine("\nValores inseridos\n");

            for(int i = 0; i < amostragens.Length; i++)
            {
                Console.WriteLine($@"{i + 1} - {amostragens[i]}");
            }

            Console.WriteLine();

            //PROTECAO PARA AMOSTRAGEM
            if(amostragens.Any(x => x != 'A' && x != 'C' && x != 'F'))
            {
                Console.Write("\nUm ou mais dados nao se encontram dentro dos parametros.\n");

                Finalizar();
                return;
            }

            //DECISOES DE CALIBRACAO

            var finalAmostragem = amostragens.Substring(amostragens.Length - 3);

            //TODOS ESTAO CORRETOS
            if (finalAmostragem.Contains("CCC"))
            {
                Console.WriteLine($@"Resultado: AP - Aumentar o periodo de calibracao.");
            }
            //ATE UM ERRO
            else if (finalAmostragem.Contains("ACC") || finalAmostragem.Contains("CAC") || finalAmostragem.Contains("CCA") || 
                finalAmostragem.Contains("FCC") || finalAmostragem.Contains("CFC") || finalAmostragem.Contains("CCF"))
            {
                Console.WriteLine($@"Resultado: MP - Manter o periodo de calibracao.");
            }
            //ATE DOIS ERROS
            else if (finalAmostragem.Contains("AAC") || finalAmostragem.Contains("ACA") || finalAmostragem.Contains("ACF") ||
                finalAmostragem.Contains("AFC") || finalAmostragem.Contains("CAA") || finalAmostragem.Contains("CAF") || 
                finalAmostragem.Contains("CFA") || finalAmostragem.Contains("CFF") || finalAmostragem.Contains("FAC") || 
                finalAmostragem.Contains("FCA") || finalAmostragem.Contains("FCF") || finalAmostragem.Contains("FFC"))
            {
                Console.WriteLine($@"Resultado: RP - Reduzir o periodo de calibracao.");
            }
            //TODOS ERRADOS
            else
            {
                Console.WriteLine($@"Resultado: RE - Reducao elevada no periodo de calibracao.");
            }

            Finalizar();
        }

        static void Finalizar()
        {
            Console.Write("\nAperte qualquer tecla para finalizar\n");
            Console.ReadKey();
        }
    }
}