using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComposicaoBanco
{
    public class ContaCorrente
    {
        public double Saldo { get; set; }
    
        private double limiteChequeEspecial;
        public double LimiteChequeEspecial
        {
            get { return limiteChequeEspecial; }
            set { 
                if(value < 0)
                {
                    System.Console.WriteLine("Limite de cheque especial negativo!");
                }
                else{
                    limiteChequeEspecial = value;
                }
            }
        }
        

        public ContaCorrente(double saldo, double limiteCheque)
        {
            Saldo = saldo;
            LimiteChequeEspecial = limiteCheque;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                return true;
            }
            else
            {
                double resto = Math.Abs(Saldo - valor);
                if(LimiteChequeEspecial >= resto)
                {
                    Saldo -= valor;
                    return true;
                }
                else
                    return false;
            }
        }

        public void GerarExtrato()
        {
            Console.WriteLine("Extrato da conta");
            Console.WriteLine("\tSaldo: " + Saldo);
            Console.WriteLine("\tLimite do Cheque Especial: " + LimiteChequeEspecial);
        }
    }
}
