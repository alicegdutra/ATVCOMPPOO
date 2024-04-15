using ComposicaoBanco;

Banco banco = new Banco();
banco.IniciarBanco();

banco.AbrirConta(5000, 5000);
banco.AbrirConta(0, 3000);
banco.AbrirConta(0, 0);

banco.AbrirPoupanca(2000);
banco.AbrirPoupanca(0);
banco.AbrirPoupanca(600);

banco.MostrarAtributos();

foreach (Poupanca poupanca in banco.ContasPoupanca){
    poupanca.GerarRendimento();
}

banco.MostrarAtributos();

Random rand = new Random();
for(int i = 0; i < banco.ContasCorrente.Count; i++)
{
    int deposito = rand.Next(0, 1000);
    System.Console.WriteLine($"Depositando {deposito:c}");
    banco.ContasCorrente[i].Depositar(deposito);
    banco.ContasCorrente[i].GerarExtrato();
}

banco.MostrarAtributos();

for(int i = 0; i < banco.ContasCorrente.Count; i++)
{
    int saque = rand.Next(0, 1000);
    System.Console.WriteLine($"Sacando {saque:c}");
    if(banco.ContasCorrente[i].Sacar(saque))
        System.Console.WriteLine("Transação Realizada");
    else
        System.Console.WriteLine("Limite indisponível");
    banco.ContasCorrente[i].GerarExtrato();
}

banco.MostrarAtributos();

for(int i = 0; i < banco.ContasPoupanca.Count; i++)
{
    int deposito = rand.Next(0, 1000);
    System.Console.WriteLine($"Depositando {deposito:c}");
    banco.ContasPoupanca[i].Depositar(deposito);
    banco.ContasPoupanca[i].MostrarAtributos();
}

banco.MostrarAtributos();

banco.DecretarFalencia();

banco.MostrarAtributos();

