﻿using Microsoft.EntityFrameworkCore;
using PrimatesWallet.Core.Interfaces;
using PrimatesWallet.Core.Models;
using System.Net;

namespace PrimatesWallet.Infrastructure.repositories
{
    public class FixedTermDepositRepository : GenericRepository<FixedTermDeposit>, IFixedTermDepositRepository
    {

        public FixedTermDepositRepository(ApplicationDbContext context) : base(context)
        {

        }


        public async Task<FixedTermDeposit> GetFixedTermDepositById(int userId, int fixedId)
        {
            // Selecciona un Plazo fijo espescífico para el usuario que lo requiere
            var accountDeposits = await _dbContext.Accounts.Where(x => x.UserId == userId).Include(x => x.FixedTermDeposit).FirstOrDefaultAsync();
            var fixedTermDeposit = accountDeposits.FixedTermDeposit.FirstOrDefault(x => x.Id == fixedId);
            return fixedTermDeposit;

        }

        public async Task<IEnumerable<FixedTermDeposit>> GetAll(int page, int pageSize)
        {
            //recuperamos en base de datos solo lo que necesitamos
            return await base._dbContext.FixedTermDeposits
                .Skip((page - 1) * pageSize) //saltamos lo anterior
                .Take(pageSize) //tomamos los 10 que necesitamos
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            //la cuenta se hace en base de datos para eficiencia
            return await base._dbContext.FixedTermDeposits.CountAsync();
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetClosedFixedTermDeposits()
        {
            var today = DateTime.Now.Date;

            return await base._dbContext.FixedTermDeposits.Where(f => f.Closing_Date.Date == today).Include(f => f.Account).ToListAsync();
        }
    }
}
