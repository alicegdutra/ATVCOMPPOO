using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComposicaoBanco
{
    public class Poupanca
    {
        private double saldo;
        public double Saldo
        {
            get { return saldo; }
            set {
                if(saldo >= 0) 
                    saldo = value;
                else
                    System.Console.WriteLine("Saldo negativo na poupança!");
                }
        }

        public Poupanca(double saldo)
        {
            Saldo = saldo;
        }

        public void Depositar(double valor)
        {
            if(valor>0)
                saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if(saldo >= valor)
            {
                saldo -= valor;
                return true;
            }
            return false;
        }
        public void GerarRendimento(){
            saldo += 0.05*saldo;
        }

        public void MostrarAtributos(){
            System.Console.WriteLine("Saldo Poupança: "+saldo);
        }
    }
}
