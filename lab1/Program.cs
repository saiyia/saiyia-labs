
Console.Write("Введите длину массива: ");
var checker = int.TryParse(Console.ReadLine(), out var n);
if (!checker || n <= 0)
{
    Console.WriteLine("Введено неверное значение");
    return;
}

// ПЕРЕМЕННЫЕ
var array = new int[n];
var random = new Random();
var first = -100;
var second = -100;

// ЗАПОЛНЕНИЕ МАССИВА
for (var i = 0; i < n; i++)
{
    array[i] = random.Next(-50, 50);
    Console.Write(array[i] + " ");
    if (array[i] < 0 && first == -100)
    {
        first = array[i];
        continue;
    }

    if (array[i] < 0 && second == -100)
        second = array[i];
}

Console.WriteLine("\nНомер первого отрицательного элемента: " + Array.IndexOf(array, first));
Console.WriteLine("Номер второго отрицательного элемента: " + Array.IndexOf(array, second));

var result = array.Where(k => Math.Abs(k) <= 1).Concat(array.Where(k => Math.Abs(k) > 1)).ToArray();

Console.WriteLine("Преобразованный массив: ");
for (var i = 0; i < n; i++)
{
    Console.Write(result[i] + " ");
}

Console.WriteLine();

// ---- ЧАСТЬ 2 ----

Console.Write("Введите количество строк массива: ");
checker = int.TryParse(Console.ReadLine(), out var rows);
if (!checker || rows <= 0)
{
    Console.WriteLine("Введено неверное значение");
    return;
}

Console.Write("Введите количество столбцов массива: ");
checker = int.TryParse(Console.ReadLine(), out var cols);
if (!checker || cols <= 0)
{
    Console.WriteLine("Введено неверное значение");
    return;
}

// ЗАПОЛНЕНИЕ МАССИВА
var matrix = new int[rows, cols];
Array.Clear(array);
for (var i = 0; i < rows; i++)
{
    for (var j = 0; j < cols; j++)
    {
        matrix[i, j] = random.Next(-50, 50);
        Console.Write(matrix[i, j] + " ");
    }

    Console.WriteLine();
}

// ОБНУЛЕНИЕ ЗНАЧЕНИЙ
var sum = 0;
array = new int[cols];

// ВЫЧИСЛЕНИЕ СУММЫ ЭЛЕМЕНТОВ
for (var i = 0; i < cols; i++)
{
    var tempSum = 0;
    var flag = false;
    for (var j = 0; j < rows; j++)
    {
        tempSum += matrix[j, i];
        if (matrix[j, i] < 0)
            flag = true;
        if (matrix[j, i] < 0 && matrix[j, i] % 2 != 0)
            array[i] += Math.Abs(matrix[j, i]);
    }

    if (flag)
        sum += tempSum;
}

Console.WriteLine("Сумма элементов в столбцах с хотя бы одним отрицательным элементом: " + sum);

sum = cols - 1;
// ПРОХОД ПО НУЛЯМ
for (int i=0; i<cols;i++)
{
    if (array[i] == 0)
    {
        array[i] = -sum;
        sum--;
    }
}
sum = 0;

// МАССИВ ИНДЕКСОВ
for (var i = 0; i < cols; i++)
{
    foreach (var j in array)
    {
        if (j > sum)
            sum = j;
    }
    if (sum>0)
        array[Array.IndexOf(array, sum)] = i * -1;
    sum = 0;
}

Console.WriteLine();
// массив индексов норм
for (var i = 0; i < cols; i++)
{
    array[i] *= -1;
}


var matrix2 = new int[rows, cols];
for (int i = 0; i < cols; i++)
{
    for (int j = 0; j < rows; j++)
    {
        matrix2[j, i] = matrix[j, Array.IndexOf(array, i)];
    }
}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write(matrix2[i,j] + " ");
    }
    Console.WriteLine();
}
