﻿
using PrimatesWallet.Application.DTOS;
using PrimatesWallet.Core.Models;

namespace PrimatesWallet.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAccountById(int id);
        Task<IEnumerable<Account>> GetAccountsList();
        Task<TransferDetailDTO> Transfer(decimal amount, int remitentId, string recieverEmail, string concept = "Some");
        Task<bool> ValidateAccount(int userId, int accountId);
    }
}
