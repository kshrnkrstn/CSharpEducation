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
        if (answer >= 1 && answer <= 9 && (playersMoves[answer - 1] != moveX) && (playersMoves[answer - 1] != moveO))
        {
            if (turn == 'X' || turn == 'x')
            {
                turn = 'O';
                playersMoves[answer - 1] = moveX;
                count++;
            }
            else if (turn == 'O' || turn == 'o')
            {
                turn = 'X';
                playersMoves[answer - 1] = moveO;
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
