using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SportApp.Api.Controllers;

public class BaseApiController : ControllerBase
{
    //protected readonly ILoggerManager _logger;
    protected readonly IMapper _mapper;

    public BaseApiController(IMapper mapper)
    {
        //_logger = logger;
        _mapper = mapper;
    }
}