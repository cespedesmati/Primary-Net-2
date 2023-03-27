﻿using Microsoft.AspNetCore.Mvc;
using PrimatesWallet.Application.Interfaces;

namespace PrimatesWallet.Api.Controllers
{
    [Route("api/FixedDeposit")]
    [ApiController]
    public class FixedTermDepositController : ControllerBase
    {
        private readonly IFixedTermDepositService _fixedTermDeposit;

        public FixedTermDepositController(IFixedTermDepositService fixedTermDeposit)
        {
            _fixedTermDeposit = fixedTermDeposit;
        }

    }
}