﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExodusGym_API.Model;
using ExodusGym_BL;
using ExodusGym_BL.Exceptions;
using ExodusGym_DAL;
using ExodusGym_DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExodusGym_API.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly ClientLogic _clientLogic;
        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //clientLogic = new ClientLogic(_unitOfWork);
        }
    }
}