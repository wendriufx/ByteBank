﻿using static _06_ByteBank.Program;

namespace _06_ByteBank
{

    public enum Acoes
    {
        Sacar = 1,
        Depositar = 2,
        TransferirEntrada = 3,
        TransferirSaida = 4
    }

    public class ContaCorrente
    {
        public Cliente titular;
        public int IDCC;
        public int IDCliente;
        public int Agencia;
        public int Numero;
        public double Saldo = 100;

        public Acoes acao;

        public bool Sacar(double valor)
        {
            if (this.Saldo < valor)
            {
                return false;
            }

            this.Saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (this.Saldo < valor)
            {
                return false;
            }

            this.Saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}