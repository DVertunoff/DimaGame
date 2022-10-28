using System.Collections;

public sealed class LogicGame
{
    private readonly int _fieldSize = 3;
    private readonly string[,] _trueField;
    private readonly string[,] _fieldWithCount;
    private readonly int[] _mas;

    public LogicGame(int size)
    {
        _fieldSize = size;
        _trueField = new string[_fieldSize + 2, _fieldSize + 2];
        _fieldWithCount = new string[_fieldSize + 2, _fieldSize + 2];
        _mas = new int[_fieldSize * _fieldSize];
    }

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

    public LogicGame(int[] masTest2)
    {
        _fieldSize = 4;
        _mas = new int[masTest2.Length];
        for (int i = 0; i < masTest2.Length; i++)
        {
            _mas[i] = masTest2[i];
        }
    }

    public void StartLogic()
    {
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

    public void FillTheTrueField()
    {
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

    public void FillTheField()
    {
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
                var flag = false;
                do
                {
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

    public Boolean SolvabilityCheck()
    {
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

    public Boolean FieldValidation()
    {
        var count = 0;
        for (int i = 1; i < _trueField.GetLength(0) - 1; i++)
            for (int j = 1; j < _trueField.GetLength(0) - 1; j++)
            {
                if (_trueField[i, j].Equals(_fieldWithCount[i, j])) count++;
            }
        return count == (_fieldSize * _fieldSize);
    }

    public String GetTrueFieldValue(int a, int b)
    {
        return _trueField[a + 1, b + 1];
    }

    public String GetCellWithNumber(int a, int b)
    {
        return _fieldWithCount[a + 1, b + 1];
    }

    public void SetCellWithNumber(int a, int b, String number)
    {
        _fieldWithCount[a + 1, b + 1] = number;
    }
}