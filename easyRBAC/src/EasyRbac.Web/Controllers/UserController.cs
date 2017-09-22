﻿// Copyright (c) GZNB. All rights reserved.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EasyRbac.Application.User;
using EasyRbac.Dto;
using EasyRbac.Dto.User;
using Microsoft.AspNetCore.Mvc;
using EasyRbac.Dto.Exceptions;

namespace EasyRbac.Web.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserControllerService _userService;

        public UserController(IUserControllerService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public Task CreateUser([FromBody]CreateUserDto dto)
        {
           return this._userService.AddUser(dto);
        }
       
        [HttpPut("{userId:long}/pwd")]
        public Task ChangePassword(long userId,[FromBody]ChangePwd dto)
        {
            return this._userService.ChangePwd(userId, dto);
        }

        [HttpDelete("{userId}")]
        public Task DisableUser(long userId)
        {
            return this._userService.DisableUser(userId);
        }

        [HttpGet("{userId}")]
        public Task<UserInfoDto> GetUserInfo(long userId)
        {
            return this._userService.GetUserInfo(userId);
        }

        [HttpPut("resource/{userId}/{appId}")]
        public Task ChangeResources(long userId, long appId,[FromBody]List<string> resouceIdList)
        {
            return this._userService.ChangeResouces(userId, appId, resouceIdList);
        }

        [HttpGet("resource/{userId}/{appId}")]
        public Task<Dictionary<string, List<string>>> GetUserResourceIds(long userId, long appId)
        {
            return this._userService.GetUserResourceIds(userId, appId);
        }

        [HttpGet]
        public Task<PagingList<UserInfoDto>> SearchUsers(string userName,int pageIndex,int pageSize)
        {
            return this._userService.SearchUser(userName, pageIndex, pageSize);
        }
    }
}