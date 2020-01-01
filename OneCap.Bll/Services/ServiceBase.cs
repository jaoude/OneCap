using AutoMapper;
using Microsoft.Extensions.Logging;
using OneCap.Dal.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneCap.Bll.Services
{
    public class ServiceBase : IServiceBase
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly ILogger<ServiceBase> _logger;

        public ServiceBase(IUnitOfWork uow, IMapper mapper, ILogger<ServiceBase> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
