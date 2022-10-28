using System.Collections;

/// <summary>
/// Класс реализующий логику игры
/// </summary>
public sealed class LogicGame
{
/// <param name="_fieldSize"> Размер поля </param>
/// <param name="_trueField"> Двумерный массив содержащий поле с выйгрышной комбинацией </param>
/// <param name="_fieldWithCount"> Двумерный массив содержащий случайно сгенерированное поле </param>
/// <param name="_mas"> Одномерный массив содержащий цифры случайно сгенерированного поля </param>
    private readonly int _fieldSize = 3;
    private readonly string[,] _trueField;
    private readonly string[,] _fieldWithCount;
    private readonly int[] _mas;

/// <summary>
/// Конструктор класса LogicGame
/// </summary>
    public LogicGame(int size)
    {
        _fieldSize = size;
        _trueField = new string[_fieldSize + 2, _fieldSize + 2];
        _fieldWithCount = new string[_fieldSize + 2, _fieldSize + 2];
        _mas = new int[_fieldSize * _fieldSize];
    }

/// <summary>
/// Конструктор класса LogicGame для модульных тестов
/// </summary>
    public LogicGame(string[,] masTest)
    {
        _trueField = new string[_fieldSize + 2, _fieldSize + 2];
        _fieldWithCount = new string[masTest.GetLength(0), masTest.GetLength(1)];
        for (int i = 0; i < masTest.GetLength(0); i++)
            for (int j = 0; j < masTest.GetLength(1); j++)
            {
                _fieldWithCount[i, j] = masTest[i, j];
            }
    }

/// <summary>
/// Конструктор класса LogicGame для модульных тестов
/// </summary>
    public LogicGame(int[] masTest2)
    {
        _fieldSize = 4;
        _mas = new int[masTest2.Length];
        for (int i = 0; i < masTest2.Length; i++)
        {
            _mas[i] = masTest2[i];
        }
    }

/// <summary>
/// Функция отвечающая за инициализацию логики
/// </summary>
    public void StartLogic()
    {
///<param name="flag"> Переменная типа bool, индикатор </param>
        var flag = false;
        FillTheTrueField();

        do
        {
            FillTheField();
            if (SolvabilityCheck())
            {
                flag = true;
            }
        } while (!flag);
    }

/// <summary>
/// Функция отвечающая за заполнение двумерного массива выйгрышной комбинацией
/// </summary>
    public void FillTheTrueField()
    {
///<param name="count"> Переменная типа int, счетчик </param>
        var count = 1;

        for (int i = 0; i < _trueField.GetLength(0); i++)
        {
            for (int j = 0; j < _trueField.GetLength(0); j++)
            {
                _trueField[i, j] = "0";
            }
        }

        for (int i = 1; i < _trueField.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < _trueField.GetLength(0) - 1; j++)
            {
                if (count == _fieldSize * _fieldSize) _trueField[i, j] = " ";
                else _trueField[i, j] = count++.ToString();
            }
        }
    }

/// <summary>
/// Функция отвечающая за заполнение двумерного массива случайными числами
/// </summary>
    public void FillTheField()
    {
///<param name="list"> Переменная типа list, хранит разные числа </param>
///<param name="count"> Переменная типа int, счетчик </param>
///<param name="random"> Объект класса Random, который генерирует случайное число </param>
        var list = new List<int>();
        var count = 0;
        var random = new Random();

        for (int i = 0; i < _trueField.GetLength(0); i++)
        {
            for (int j = 0; j < _trueField.GetLength(0); j++)
            {
                _fieldWithCount[i, j] = "0";
            }
        }

        for (int i = 1; i < _fieldWithCount.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < _fieldWithCount.GetLength(0) - 1; j++)
            {
///<param name="flag"> Переменная типа bool, индикатор </param>
                var flag = false;
                do
                {
///<param name="rnd"> Переменная которая хранит случайное число </param>
                    var rnd = random.Next(1, (_fieldSize * _fieldSize) + 1);

                    if (list.Contains(rnd)) continue;

                    list.Add(rnd);
                    flag = true;
                    _mas[count] = rnd;

                    _fieldWithCount[i, j] = rnd.ToString();
                    if (rnd == _fieldSize * _fieldSize) _mas[count] = 0;

                    count += 1;

                    if (rnd != _fieldSize * _fieldSize) continue;
                    _fieldWithCount[i, j] = " ";
                } while (!flag);
            }
        }
    }

/// <summary>
/// Функция проверяющая поле на решаемость
/// </summary>
/// <returns> Если поле решаемое - возвращает True, иначе False </returns>
    public Boolean SolvabilityCheck()
    {
///<param name="inv"> Переменная типа int, счетчик </param>
        var inv = 0;

        for (int i = 0; i < _fieldSize * _fieldSize; ++i)
        {
            if (_mas[i] != 0)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (_mas[j] != 0 && _mas[j] > _mas[i]) ++inv;
                }
            }
        }

        for (int i = 0; i < _fieldSize * _fieldSize; ++i)
        {
            if (_mas[i] == 0) inv += 1 + i / _fieldSize;
        }

        if (inv % 2 == 1) return false;
        return true;
    }

/// <summary>
/// Функция которая сверяет текущую комбинацию с выйгрышной
/// </summary>
/// <returns> Если комбинация выйгрышная - возвращает True, иначе False </returns>
    public Boolean FieldValidation()
    {
///<param name="count"> Переменная типа int, счетчик </param>
        var count = 0;
        for (int i = 1; i < _trueField.GetLength(0) - 1; i++)
            for (int j = 1; j < _trueField.GetLength(0) - 1; j++)
            {
                if (_trueField[i, j].Equals(_fieldWithCount[i, j])) count++;
            }
        return count == (_fieldSize * _fieldSize);
    }

/// <summary>
/// Функция которая возвращает значение выигрышного поля под индексами a, b
/// </summary>
/// <param name="a"> Переменная тип int, индекс </param>
/// <param name="b"> Переменная тип int, индекс </param>
/// <returns> Возвращает строку со значением поля под индексами a, b </returns>
    public String GetTrueFieldValue(int a, int b)
    {
        return _trueField[a + 1, b + 1];
    }

/// <summary>
/// Функция которая возвращает значение текущего поля под индексами a, b
/// </summary>
/// <param name="a"> Переменная тип int, индекс </param>
/// <param name="b"> Переменная тип int, индекс </param>
/// <returns> Возвращает строку со значением поля под индексами a, b </returns>
    public String GetCellWithNumber(int a, int b)
    {
        return _fieldWithCount[a + 1, b + 1];
    }

/// <summary>
/// Функция которая назначает значение текущего поля под индексами a, b
/// </summary>
/// <param name="a"> Переменная тип int, индекс </param>
/// <param name="b"> Переменная тип int, индекс </param>
    public void SetCellWithNumber(int a, int b, String number)
    {
        _fieldWithCount[a + 1, b + 1] = number;
    }
}