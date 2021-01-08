﻿using System.Collections.Generic;
using System.Linq;
using TeduShop.Common.Constants;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    #region Interface

    public interface ICommonService
    {
        Footer GetFooter();

        IEnumerable<SystemConfig> GetSystemConfigsByMultiCodes(List<string> codes);

        IEnumerable<Slide> GetSlide();
    }

    #endregion Interface

    #region Implement

    public class CommonService : ICommonService
    {
        #region Properties

        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private ISystemConfigRepository _systemConfigRepository;
        private IUnitOfWork _unitOfWork;

        #endregion Properties

        #region Constructors

        public CommonService(IFooterRepository footerRepository, ISlideRepository slideRepository
            , ISystemConfigRepository systemConfigRepository, IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._slideRepository = slideRepository;
            this._systemConfigRepository = systemConfigRepository;
            this._unitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Methods

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == Constant.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlide()
        {
            return _slideRepository.GetMulti(x => x.Status == true);
        }

        public IEnumerable<SystemConfig> GetSystemConfigsByMultiCodes(List<string> codes)
        {
            return _systemConfigRepository.GetMulti(x => codes.Contains(x.Code));
        }

        #endregion Methods
    }

    #endregion Implement
}