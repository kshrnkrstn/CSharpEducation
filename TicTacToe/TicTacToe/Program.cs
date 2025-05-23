using System;

/// <summary>
/// Нарисовать текущее игровое поле
/// </summary>
void DrawField(int[] playersMove)
{
    Console.WriteLine("-------------");
    Console.Write("| "); IsEmptyCell(playersMove[0]);Console.Write(" | "); IsEmptyCell(playersMove[1]);
    Console.Write(" | "); IsEmptyCell(playersMove[2]); Console.WriteLine(" |");
    Console.Write("| "); IsEmptyCell(playersMove[3]);Console.Write(" | "); IsEmptyCell(playersMove[4]);
    Console.Write(" | "); IsEmptyCell(playersMove[5]); Console.WriteLine(" |");
    Console.Write("| "); IsEmptyCell(playersMove[6]);Console.Write(" | "); IsEmptyCell(playersMove[7]);
    Console.Write(" | "); IsEmptyCell(playersMove[8]); Console.WriteLine(" |");
    Console.WriteLine("-------------\n");
}
void IsEmptyCell(int cell)
{
    if (cell == 10) //ход X
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("X");
        Console.ResetColor();
    }

    else if (cell == 11) //ход O
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("O");
        Console.ResetColor();
    }

    else
    {
        Console.Write(cell); //пустая ячейка
    }
}

/// <summary>
/// Проверка на наличие победителя
/// (победные комбинации)
/// </summary>
bool IsWinner(int[] playersMoves)
{
    if (playersMove[0] == playersMove[1])
    {
        if (playersMove[0] == playersMove[2])
        {
            return true;
        }
    }
    else if (playersMove[0] == playersMove[3])
    {
        if (playersMove[0] == playersMove[6])
        {
            return true;
        }
    }
    else if (playersMove[0] == playersMove[4])
    {
        if (playersMove[0] == playersMove[8])
        {
            return true;
        }
    }
    else if (playersMove[3] == playersMove[4])
    {
        if (playersMove[3] == playersMove[5])
        {
            return true;
        }
    }
    else if (playersMove[6] == playersMove[7])
    {
        if (playersMove[6] == playersMove[8])
        {
            return true;
        }
    }
    else if (playersMove[1] == playersMove[4])
    {
        if (playersMove[1] == playersMove[7])
        {
            return true;
        }
    }
    else if (playersMove[2] == playersMove[5])
    {
        if (playersMove[2] == playersMove[8])
        {
            return true;
        }
    }
    else if (playersMove[2] == playersMove[4])
    {
        if (playersMove[2] == playersMove[6])
        {
            return true;
        }
    }

    return false;
}

/// <summary>
/// Функция воспроизведения одного тура игры
/// </summary>
void StartGame(int[] playersMoves)
{
    
    char turn = 'v';
    while (turn != 'x' && turn != 'o' && turn != 'O' && turn != 'X')
    {
        Console.Write("Кто ходит первым? [x/o] ");
        turn = Console.ReadKey().KeyChar;
        if (turn != 'x' && turn != 'o' && turn != 'X' && turn != 'O')
        {
            Console.WriteLine();
            Console.WriteLine("Ответьте корректно!");
        }
    }
    Console.WriteLine();
    
    bool winner = false;
    int count = 0;
    while (winner == false)
    {
        DrawField(playersMoves);
        Console.Write("Ход " + char.ToUpper(turn) + ": ");
        int answer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        if (answer >= 1 && answer <= 9 && (playersMoves[answer - 1] != 10) && (playersMoves[answer - 1] != 11))
        {
            if (turn == 'X' || turn == 'x')
            {
                playersMoves[answer - 1] = 10;
                turn = 'O';
                count++;
            }
            else if (turn == 'O' || turn == 'o')
            {
                playersMoves[answer - 1] = 11;
                turn = 'X';
                count++;
            }
            if (count >= 5)
            {
                winner = IsWinner(playersMoves);
            }
        }
        else
        {
            Console.WriteLine("Введите корректное значение (или не заполненное поле)!\n");
        }
        
        if (winner)
        {
            if (turn == 'X')
            {
                turn = 'O';
            }
            else if (turn == 'O')
            {
                turn = 'X';
            }
            Console.WriteLine($"Победитель {turn}!");
            break;
        }

        if (count == 9 && winner == false)
        {
            Console.WriteLine("Ничья!");
        }
    }
}


char newGame = 'y';
while (newGame == 'y')
{
    Console.Write("Хотите сыграть партию? [y/n] ");
    newGame = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (newGame == 'n')
        break;
    if (newGame == 'y')
    {
        int[] playersMoves = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        StartGame(playersMoves);
    }
    else
    {
        Console.WriteLine("Ответьте корректно!");
        newGame = 'y';
    }
    
}
