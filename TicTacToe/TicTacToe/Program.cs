using System;

/// <summary>
/// Нарисовать текущее игровое поле
/// </summary>
void DrawField(int[] playersMove)
{
    const string fieldSide = "-------------";
    const string fieldLeftRow = "| ";
    const string fieldRightRow = " |";
    const string fieldMiddleRow = " | ";
    Console.WriteLine(fieldSide);
    for (int i = 0; i < 9; i+=3)
    {
        
        Console.Write(fieldLeftRow);
        IsEmptyCell(playersMove[i]);
        Console.Write(fieldMiddleRow);
        IsEmptyCell(playersMove[i+1]);
        Console.Write(fieldMiddleRow);
        IsEmptyCell(playersMove[i+2]);
        Console.WriteLine(fieldRightRow);
    }
    Console.WriteLine(fieldSide + "\n");
}

const int moveX = 10;
const int moveO = 11;
void IsEmptyCell(int cell)
{
    if (cell == moveX)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("X");
        Console.ResetColor();
    }

    else if (cell == moveO)
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
    if (playersMoves[0] == playersMoves[1])
    {
        if (playersMoves[0] == playersMoves[2])
        {
            return true;
        }
    }
    else if (playersMoves[0] == playersMoves[3])
    {
        if (playersMoves[0] == playersMoves[6])
        {
            return true;
        }
    }
    else if (playersMoves[0] == playersMoves[4])
    {
        if (playersMoves[0] == playersMoves[8])
        {
            return true;
        }
    }
    else if (playersMoves[3] == playersMoves[4])
    {
        if (playersMoves[3] == playersMoves[5])
        {
            return true;
        }
    }
    else if (playersMoves[6] == playersMoves[7])
    {
        if (playersMoves[6] == playersMoves[8])
        {
            return true;
        }
    }
    else if (playersMoves[1] == playersMoves[4])
    {
        if (playersMoves[1] == playersMoves[7])
        {
            return true;
        }
    }
    else if (playersMoves[2] == playersMoves[5])
    {
        if (playersMoves[2] == playersMoves[8])
        {
            return true;
        }
    }
    else if (playersMoves[2] == playersMoves[4])
    {
        if (playersMoves[2] == playersMoves[6])
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
    const char turnX = 'X';
    const char turnO = 'O';
    char turn = 'V';
    while (turn != turnO && turn != turnX)
    {
        Console.Write("Кто ходит первым? [X/O] ");
        turn = Console.ReadKey().KeyChar;
        if (turn != turnX && turn != turnO)
        {
            Console.WriteLine();
            Console.WriteLine("Введите X или O!");
        }
    }
    Console.WriteLine();
    
    bool winner = false;
    int count = 0;
    while (winner == false)
    {
        DrawField(playersMoves);
        Console.Write("Ход " + turn + ": ");
        int answer = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        if (answer >= 1 && answer <= 9 && (playersMoves[answer - 1] != moveX) && (playersMoves[answer - 1] != moveO))
        {
            if (turn == turnX)
            {
                playersMoves[answer - 1] = moveX;
                turn = turnO;
                count++;
            }
            else if (turn == turnO)
            {
                playersMoves[answer - 1] = moveO;
                turn = turnX;
                count++;
            }
            if (count >= 5)
            {
                winner = IsWinner(playersMoves);
            }
        }
        else
        {
            Console.WriteLine("Введите номер незаполненной ячейки от 1 до 9.\n");
        }
        
        if (winner)
        {
            if (turn == turnX)
            {
                turn = turnO;
            }
            else if (turn == turnO)
            {
                turn = turnX;
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


char newGame = 'Y';
while (newGame == 'Y')
{
    Console.Write("Хотите сыграть партию? [Y/N] ");
    newGame = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (newGame == 'N')
        break;
    if (newGame == 'Y')
    {
        int[] playersMoves = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        StartGame(playersMoves);
    }
    else
    {
        Console.WriteLine("Ответьте Y - да или N - нет.");
        newGame = 'Y';
    }
    
}
