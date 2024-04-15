using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComposicaoBanco
{
    public class Banco
    {
        public List<Poupanca> ContasPoupanca { get; set; }
        public List<ContaCorrente> ContasCorrente { get; set; }

        public Banco()
        {
            
        }

        public void IniciarBanco()
        {
            this.ContasPoupanca = new List<Poupanca>();
            this.ContasCorrente = new List<ContaCorrente>();

            System.Console.WriteLine("Contas");
            ContaCorrente c1 = new ContaCorrente(50, 50);
            ContasCorrente.Add(c1);
            ContaCorrente c2 = new ContaCorrente(150, 150);
            ContasCorrente.Add(c2);
            ContaCorrente c3 = new ContaCorrente(250, 250);
            ContasCorrente.Add(c3);
            ContaCorrente c4 = new ContaCorrente(350, 350);
            ContasCorrente.Add(c4);

            // Abrir algumas contas poupança
            Poupanca p1 = new Poupanca(100);
            ContasPoupanca.Add(p1);
            Poupanca p2 = new Poupanca(200);
            ContasPoupanca.Add(p2);
            Poupanca p3 = new Poupanca(300);
            ContasPoupanca.Add(p3);
            Poupanca p4 = new Poupanca(400);
            ContasPoupanca.Add(p4);

            MostrarAtributos();
        }

        public void AbrirConta(double saldo, double limiteCheque)
        {
            ContaCorrente conta = new ContaCorrente(saldo, limiteCheque);
            ContasCorrente.Add(conta);
        }

        public void AbrirPoupanca(double saldo)
        {
            Poupanca poupanca = new Poupanca(saldo);
            ContasPoupanca.Add(poupanca);
        }

        public void DecretarFalencia()
        {
            ContasPoupanca = null;
            ContasCorrente = null;
        }

        public void MostrarContasCorrente()
        {
            foreach (ContaCorrente conta in ContasCorrente)
            {
                conta.GerarExtrato();
            }
        }

        public void MostrarContasPoupanca()
        {
            foreach (Poupanca poupanca in ContasPoupanca)
            {
                poupanca.MostrarAtributos();
            }
        }

        public double CalcularSaldoContasCorrente(){
            double saldo = 0;
            foreach (ContaCorrente conta in ContasCorrente)
            {
                saldo += conta.Saldo;
            }

            return saldo;
        }

        public double CalcularSaldoContasPoupanca()
        {
            double saldo = 0;
            foreach (Poupanca poupanca in ContasPoupanca)
            {
                saldo += poupanca.Saldo;
            }
            return saldo;
        }

        public void MostrarAtributos(){

            if(ContasCorrente == null || ContasPoupanca == null)
            {
                System.Console.WriteLine("Banco em estado de Falência");
            }
            else{
                System.Console.WriteLine("Banco - Estado Vigente: ");
                MostrarContasCorrente();
                double saldoContas = CalcularSaldoContasCorrente();
                System.Console.WriteLine($"Saldo das Contas Corrente: {saldoContas:c}");
                MostrarContasPoupanca();
                double saldoPoupancas = CalcularSaldoContasPoupanca();
                System.Console.WriteLine($"Saldo das Contas Poupança: {saldoPoupancas:c}");
                double saldoTotal = saldoContas + saldoPoupancas;
                System.Console.WriteLine($"Saldo Total: {saldoTotal:c}\n");
            }
        }
    }
}