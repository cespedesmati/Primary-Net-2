﻿using PrimatesWallet.Application.DTOS;
using PrimatesWallet.Application.Exceptions;
using PrimatesWallet.Application.Helpers;
using PrimatesWallet.Application.Interfaces;
using PrimatesWallet.Application.Mapping.User;
using PrimatesWallet.Core.Interfaces;
using PrimatesWallet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrimatesWallet.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await unitOfWork.UserRepository.GetById(id);
                return user is null ?
                    throw new AppException(ReplyMessage.MESSAGE_QUERY_EMPTY, HttpStatusCode.NotFound)
                    : user; //OBS: Falta mapping para DTO (configuracion en equipo)

                //si no existe el usuario lanzamos un exception personalizada
                //en otra parte del codigo la atrapamos y le damos un formato
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UserResponseDTO>> GetUsers(int page, int pageSize)
        {
            var users = await unitOfWork.UserRepository.GetAll(page, pageSize)
                 ?? throw new AppException(ReplyMessage.MESSAGE_QUERY_EMPTY, HttpStatusCode.NotFound);

            var usersDTO = users.Select(x => 
                new UserResponseDTOBuilder()
                .WithUserId(x.UserId)
                .WithFirstName(x.First_Name)
                .WithLastName(x.Last_Name)
                .WithEmail(x.Email)
                .WithPoints(x.Points)
                .WithRolId(x.Rol_Id)
                .Build()).ToList();

            return usersDTO;
        }

        public async Task<int> TotalPageUsers(int pageSize)
        {
            var totalUsers = await unitOfWork.UserRepository.GetCount();
            //contamos el total de usuarios y calculamos cuantas paginas hay en total
            return (int)Math.Ceiling((double)totalUsers / pageSize);
        }
    }
}
