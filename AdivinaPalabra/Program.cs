using System.Text;

var palabrasSugeridas = new List<string>() { "programacion", "dotnet", "csharp", "trnetwork", "javascript" };

int intentosMaximos = 5;
int intentosRealizados = 0;
bool adivinado = false;

Console.WriteLine("¡Bienvenido al juego de adivinar la palabra!");

var palabraSecreta = ObtenerPalabraSecreta(palabrasSugeridas, out var palabraSecretaParaUsuario);

Console.WriteLine($"Tienes que adivinar la siguiente palabra {palabraSecretaParaUsuario}.");

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

string ObtenerPalabraSecreta(List<string> listaPalabrasSecretas, out StringBuilder stringBuilder)
{
    Random rnd = new Random();
    int randIndex = rnd.Next(listaPalabrasSecretas.Count);

    var obtenerPalabraSecreta = listaPalabrasSecretas[randIndex];

    stringBuilder = new StringBuilder();

    int numGuiones = 0;

    for (int i = 0; i < obtenerPalabraSecreta.Length; i++)
    {
        randIndex = rnd.Next(obtenerPalabraSecreta.Length);

        if (i == randIndex)
        {
            stringBuilder.Append('_');
            numGuiones++;
            continue;
        }
    
        stringBuilder.Append(obtenerPalabraSecreta[i]);
    }

    if (numGuiones == 0)
    {
        ObtenerPalabraSecreta(listaPalabrasSecretas, out stringBuilder);
    }

    int valorTotal = obtenerPalabraSecreta.Length;
    int porcentajeMaximoPermitido = 60;

    var resultadoPorcentajeMaximoPermitido  = (valorTotal * porcentajeMaximoPermitido) / 100;

    if (numGuiones > resultadoPorcentajeMaximoPermitido)
    {
        ObtenerPalabraSecreta(listaPalabrasSecretas, out stringBuilder);
    }

    return obtenerPalabraSecreta;
}
