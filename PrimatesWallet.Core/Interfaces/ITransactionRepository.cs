﻿using PrimatesWallet.Core.Models;

namespace PrimatesWallet.Core.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        /// <summary>
        /// Retorna todas las transacciones de una cuenta específica, depósitos, transferencias realizadas o recibidas.
        /// </summary>
        /// <param name="id">El ID de la cuenta de la cual se quieren obtener las transacciones.</param>
        /// <returns>Una colección de objetos <c>Transaction</c> que representan las transacciones encontradas.</returns>
        /// <exception cref="AppException">Si no se encuentran transacciones asociadas a la cuenta especificada.</exception>
        Task<IEnumerable<Transaction>> GetAllByAccount(int id);
    }
}