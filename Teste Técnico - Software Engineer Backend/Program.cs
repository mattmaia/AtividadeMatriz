using System;

class Program
{
    // Questão 1: Implemente uma função que inverta as diagonais de uma matriz quadrada
    // Função que imprime a Matriz na console
    static void ImprimirMatriz(int[,] matriz)
    {
        int tamanho = matriz.GetLength(0);

        for (int i = 0; i < tamanho; i++)
        {
            Console.Write(" ");
            for (int j = 0; j < tamanho; j++)
            {
                Console.Write(matriz[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }
    
    // Função para inversão da ordem das diagonais
    static void InverterDiagonais(int[,] matriz)
    {
        int tamanho = matriz.GetLength(0);

        for (int i = 0; i < tamanho / 2 ; i++)
        {
            // Inverte a diagonal principal
            int temp = matriz[i, i];
            matriz[i, i] = matriz[tamanho - i - 1, tamanho - i - 1];
            matriz[tamanho - i - 1, tamanho - i - 1] = temp;

            // Inverte a diagonal secundária
            temp = matriz[i, tamanho - i - 1];
            matriz[i, tamanho - i - 1] = matriz[tamanho - i - 1, i];
            matriz[tamanho - i - 1, i] = temp;
        }
    }
    // Questão 2: implemente uma função que, dado uma matriz A e uma submatriz B (dimensões menores que A), esta função retorne quantas vezes esta submatriz B pode ser encontrada na matriz A.
    // Função que verifica e retorna o numero de vezes que a submatriz B pode ser encontrada na matriz A.
    public static int ContarSubmatriz(int[,] matrizA, int[,] submatrizB)
    {
        int count = 0;
        // Obtem o numero de linhas e colunas da Matriz A e da Submatriz B
        int rowsA = matrizA.GetLength(0);
        int colsA = matrizA.GetLength(1);
        int rowsB = submatrizB.GetLength(0);
        int colsB = submatrizB.GetLength(1);

        for (int i = 0; i <= rowsA - rowsB; i++) // Percorre todas as possíveis posições da matriz A
        {
            for (int j = 0; j <= colsA - colsB; j++)
            {
                // Função VerificarSubmatriz é chamada para verificar se a submatriz B é encontrada na posição atual. Se a funçao retornar true ela entra na condiçao.
                if (VerificarSubmatriz(matrizA, submatrizB, i, j)) 
                {
                    count++;
                }
            }
        }

        return count; // Retorna o valor do contador
    }


    // Função que verifica elemento por elemento se os valores da submatriz B correspondem aos valores da matriz A, dadas pelos indices iniciais startRow e startCol 
    public static bool VerificarSubmatriz(int[,] matrizA, int[,] submatrizB, int startRow, int startCol)
    {
        int rowsB = submatrizB.GetLength(0); // Obtem o numero de linhas da Submatriz B 
        int colsB = submatrizB.GetLength(1); // Obtem o numero de colunas da Submatriz B 

        for (int i = 0; i < rowsB; i++) // percorre a Submtariz B
        {
            for (int j = 0; j < colsB; j++)
            {
                if (matrizA[startRow + i, startCol + j] != submatrizB[i, j]) // verifica se o elemento correspondente na matriz A é diferente do elemento correspondente na submatriz B
                {
                    return false;
                }
            }
        }

        return true; 
    }

    static void Main(string[] args)
    {

        // Matriz quadrada 4x4
        int[,] matriz = {{ 1, 28, 13, 8 }, { 55, 2, 7, 90 }, { 25, 6, 3, 87 }, { 5, 28, 13, 4 } };

        // Matriz quadrada 4x4
        int[,] matrizA = {{ 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 1, 2, 12 }, { 1, 5, 6, 16 } };

        // Matriz quadrada 2x2
        int[,] submatrizB = {{ 1, 2 },{ 5, 6 }};

        Console.WriteLine("\nQuestão 1: Implemente uma função que inverta as diagonais de uma matriz quadrada"); // Questão 1
        Console.WriteLine("\nMatriz original:");
        ImprimirMatriz(matriz); // Chamando a função que imprime a Matriz

        InverterDiagonais(matriz); // Chamando a função que inverte as diagonais 
        Console.WriteLine("\nMatriz com as diagonais invertidas:");
        ImprimirMatriz(matriz);

        Console.WriteLine("\n\n---------------------------------------------------------------------------------------------------------\n");

        Console.WriteLine("Pressione qualquer tecla para ir para questão 2");
        Console.ReadKey();

        Console.WriteLine("\nQuestão 2: implemente uma função que, dado uma matriz A e uma submatriz B \n(dimensões menores que A), esta função retorne quantas vezes esta submatriz B \npode ser encontrada na matriz A."); // Questão 2
        Console.WriteLine("\nMatriz A:");
        ImprimirMatriz(matrizA); // Chamando a função para imprimir a Matriz A

        Console.WriteLine("\nSubMatriz B:");
        ImprimirMatriz(submatrizB); // Chamando a função para imprimir a Submatriz B


        int count = ContarSubmatriz(matrizA, submatrizB); // Função que irá contar quantas vezes a Submatriz B é encontrada dentro da Matriz A
        Console.WriteLine("O numero de vezes que a submatriz B pode ser encontrada na matriz A é: " + count);

    }
}
