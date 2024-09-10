using System;
using System.Threading;

class JogoDaVida
{
    static int rows = 20;
    static int cols = 40;
    static bool[,] grid = new bool[rows, cols];
    static Random rand = new Random();

    static void Main()
    {
        // Inicializar grade com valores aleatórios
        InicializarGrade();
        
        while (true)
        {
            Console.Clear();
            ExibirGrade();
            AtualizarGrade();
            Thread.Sleep(500); // Pausa entre as gerações
        }
    }

    // Inicializa a grade com células vivas aleatórias
    static void InicializarGrade()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = rand.Next(2) == 0;
            }
        }
    }

    // Exibe a grade no console
    static void ExibirGrade()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(grid[i, j] ? "O" : ".");
            }
            Console.WriteLine();
        }
    }

    // Atualiza a grade de acordo com as regras do Jogo da Vida
    static void AtualizarGrade()
    {
        bool[,] novaGrade = new bool[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int vizinhosVivos = ContarVizinhosVivos(i, j);
                
                // Aplicar as regras
                if (grid[i, j])
                {
                    novaGrade[i, j] = vizinhosVivos == 2 || vizinhosVivos == 3;
                }
                else
                {
                    novaGrade[i, j] = vizinhosVivos == 3;
                }
            }
        }

        grid = novaGrade;
    }

    // Conta os vizinhos vivos de uma célula
    static int ContarVizinhosVivos(int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                int nx = (x + i + rows) % rows;
                int ny = (y + j + cols) % cols;
                if (grid[nx, ny]) count++;
            }
        }

        return count;
    }
}
