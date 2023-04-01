﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimatesWallet.Application.DTOS;
using PrimatesWallet.Application.Exceptions;
using PrimatesWallet.Application.Helpers;
using PrimatesWallet.Application.Interfaces;
using PrimatesWallet.Core.Models;
using System.Net;

namespace PrimatesWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TransactionsController : ControllerBase
    {
        //Se deja preparado el controlador de Transacciones con la DI de servicios
        //Se deja pendiente el desarrollo de los endpoints asignados.
        private readonly ITransactionService transactionService;
        private readonly IUserContextService UserContextService;


        public TransactionsController(ITransactionService transaction, IUserContextService userContextService)

        {
            transactionService = transaction;
            UserContextService = userContextService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var userId = UserContextService.GetCurrentUser(); //buscamos el id del usuario que se logeo
                var transactions = await transactionService.GetAllByUser(userId); //buscamos las transacciones solo de ese user

                var response = new BaseResponse<IEnumerable<TransactionDTO>>(ReplyMessage.MESSAGE_QUERY, transactions, (int)HttpStatusCode.OK);
                return Ok(response);
            }
            catch (AppException ex)
            {
                var response = new BaseResponse<object>(ex.Message, null, (int)ex.StatusCode);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                var response = new BaseResponse<object>(ex.Message, null, (int)HttpStatusCode.InternalServerError);
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            Transaction transaction = await transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No transaction found by id{id}");
            }
            return StatusCode(StatusCodes.Status200OK, transaction);
        }

        [HttpDelete("{transactionId}")]
        [Authorize]
        public async Task<IActionResult> DeleteTransaction (int transactionId)
        {
            var requestedUser = UserContextService.GetCurrentUser();
            var response = await transactionService.DeleteTransaction(transactionId, requestedUser);
            if( !response ) { return NotFound(); }
            return Ok($"Transaction {transactionId} deleted.");
        }


    }
}