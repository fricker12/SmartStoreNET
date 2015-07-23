﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SmartStore.Core.Domain.Stores;
using SmartStore.Core.Events;
using SmartStore.Services.Stores;

namespace SmartStore.Services.Tasks
{
    public class ChangeTaskSweeperBaseUrlConsumer :
        IConsumer<EntityInserted<Store>>,
        IConsumer<EntityUpdated<Store>>,
        IConsumer<EntityDeleted<Store>>
    {
        private readonly ITaskSweeper _taskSweeper;
        private readonly IStoreService _storeService;
        private readonly HttpContextBase _httpContext;

        public ChangeTaskSweeperBaseUrlConsumer(ITaskSweeper taskSweeper, IStoreService storeService, HttpContextBase httpContext)
        {
            this._taskSweeper = taskSweeper;
            this._storeService = storeService;
            this._httpContext = httpContext;
        }

        public void HandleEvent(EntityInserted<Store> eventMessage)
        {
            _taskSweeper.SetBaseUrl(_storeService, _httpContext);
        }

        public void HandleEvent(EntityUpdated<Store> eventMessage)
        {
            _taskSweeper.SetBaseUrl(_storeService, _httpContext);
        }

        public void HandleEvent(EntityDeleted<Store> eventMessage)
        {
            _taskSweeper.SetBaseUrl(_storeService, _httpContext);
        }
    }
}