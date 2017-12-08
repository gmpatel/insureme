﻿using Insureme.Core.v1.Entities.Dipn;
using Insureme.Core.v1.Helpers;
using Insureme.Core.v1.Objects.Exceptions;
using Insureme.Core.v1.Objects.Requests.Dipn;
using Insureme.Core.v1.Objects.Responses.Common;
using Insureme.DataAccess.Interfaces;
using Insureme.WebApis.Filters.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Insureme.WebApis.Controllers.v1.Dipn
{
    [RoutePrefix("api/dipn/v1/register")]
    [KeyAuthorization]
    public class RegisterController : ApiController
    {
        private readonly IDataService dataService;

        public RegisterController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [TokenAuthorization("*")]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(RegisterAppRequest request)
        {
            try
            {
                var ip = Request.GetClientIp();
                var result = dataService.DipnRegisterApp(request.Id, request.Name, request.Type, ip);

                return new HttpActionResult<GenericResponse<AppEntity>>(
                    HttpStatusCode.OK,
                    new GenericResponse<AppEntity>
                    {
                        Result = result
                    }
                );
            }
            catch (GeneralException exception)
            {
                return new HttpActionResult<GenericResponse<AppEntity>>(
                    HttpStatusCode.OK,
                    new GenericResponse<AppEntity>
                    {
                        Error = new Error
                        {
                            ResponseCode = HttpStatusCode.OK,
                            Code = exception.Code,
                            Message = exception.Message
                        }
                    }
                );
            }
            catch (Exception exception)
            {
                return new HttpActionResult<GenericResponse<AppEntity>>(
                    HttpStatusCode.InternalServerError,
                    new GenericResponse<AppEntity>
                    {
                        Error = new Error
                        {
                            ResponseCode = HttpStatusCode.InternalServerError,
                            Message = exception.Message
                        }
                    }
                );
            }
        }
    }
}