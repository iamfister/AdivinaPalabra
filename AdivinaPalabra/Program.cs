string palabraSecreta = "programacion";
int intentosMaximos = 5;
int intentosRealizados = 0;
bool adivinado = false;

Console.WriteLine("¡Bienvenido al juego de adivinar la palabra!");
Console.WriteLine("Tienes que adivinar una palabra.");

while (!adivinado && intentosRealizados < intentosMaximos)
{
    Console.Write("Introduce tu intento: ");
    string intento = Console.ReadLine();

    if (intento?.ToLower() == palabraSecreta)
    {
        adivinado = true;
        Console.WriteLine("¡Felicidades! ¡Has adivinado la palabra!");
    }
    else
    {
        intentosRealizados++;
        Console.WriteLine("Intento incorrecto. Te quedan " + (intentosMaximos - intentosRealizados) + " intentos.");
    }
}

if (!adivinado)
{
    Console.WriteLine("¡Has agotado todos tus intentos! La palabra secreta era: " + palabraSecreta);
}
