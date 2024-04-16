using System.Text;

var palabrasSugeridas = new List<string>
{
    "programacion", 
    "dotnet", 
    "csharp", 
    "trnetwork", 
    "javascript",
    "gintama",
    "ingenieria",
    "konosuba"
};

int intentosMaximos = 5;
int intentosRealizados = 0;
bool adivinado = false;

Console.WriteLine("¡Bienvenido al juego de adivinar la palabra!");

var palabraSecreta = ObtenerPalabraSecreta(palabrasSugeridas,
    out var palabraSecretaParaUsuario,
    out var caracteresSecretos);

Console.WriteLine($"Tienes que adivinar la siguiente palabra {palabraSecretaParaUsuario}.");

string auxPalabraSecreta = palabraSecretaParaUsuario.ToString();

while (!adivinado && intentosRealizados < intentosMaximos)
{
    Console.Write("Introduce tu intento: ");
    var intento = Console.ReadLine();

    if (string.IsNullOrEmpty(intento))
    {
        intentosRealizados++;
        Console.WriteLine("Intento incorrecto. Te quedan " + (intentosMaximos - intentosRealizados) + " intentos.");
        continue;
    }

    intento = intento.Trim().ToLower();

    if (intento.Length > palabraSecreta.Length)
    {
        intentosRealizados++;
        Console.WriteLine("Intento incorrecto. Te quedan " + (intentosMaximos - intentosRealizados) + " intentos.");
        continue;
    }

    if (intento == palabraSecreta)
    {
        adivinado = true;
        Console.WriteLine("¡Felicidades! ¡Has adivinado la palabra!");
    }
    else
    {
        if (intento.Length > 1)
        {
            intentosRealizados++;
            Console.WriteLine("Intento incorrecto. Te quedan " + (intentosMaximos - intentosRealizados) + " intentos.");
            continue;
        }
        
        if (caracteresSecretos.Any(p => p.Value == intento[0]))
        {
            var obtenerCaracterSecreto = 
                caracteresSecretos.FirstOrDefault(p => p.Value == intento[0]);

            var sb = new StringBuilder(auxPalabraSecreta)
            {
                [obtenerCaracterSecreto.Key] = obtenerCaracterSecreto.Value
            };

            auxPalabraSecreta = sb.ToString();

            Console.WriteLine(auxPalabraSecreta);

            if (auxPalabraSecreta == palabraSecreta)
            {
                adivinado = true;
                Console.WriteLine("¡Felicidades! ¡Has adivinado la palabra!");
            }
            
            continue;
        }
        
        intentosRealizados++;
        Console.WriteLine("Intento incorrecto. Te quedan " + (intentosMaximos - intentosRealizados) + " intentos.");
    }
}

if (!adivinado)
{
    Console.WriteLine("¡Has agotado todos tus intentos! La palabra secreta era: " + palabraSecreta);
}

return;

string ObtenerPalabraSecreta(
    IReadOnlyList<string> listaPalabrasSecretas, 
    out StringBuilder stringBuilder, 
    out Dictionary<int, char> caracteresSecretos)
{
    while (true)
    {
        caracteresSecretos = [];
        
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
                caracteresSecretos.Add(i, obtenerPalabraSecreta[i]);
                continue;
            }

            stringBuilder.Append(obtenerPalabraSecreta[i]);
        }

        if (numGuiones == 0)
        {
            continue;
        }

        int valorTotal = obtenerPalabraSecreta.Length;
        int porcentajeMaximoPermitido = 60;

        var resultadoPorcentajeMaximoPermitido = (valorTotal * porcentajeMaximoPermitido) / 100;

        if (numGuiones > resultadoPorcentajeMaximoPermitido)
        {
            continue;
        }

        return obtenerPalabraSecreta;
    }
}
