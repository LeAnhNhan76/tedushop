﻿using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    #region Interface

    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        void Update(ProductCategory productCategory);

        ProductCategory Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyword);

        IEnumerable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }

    #endregion Interface

    #region Implement

    public class ProductCategoryService : IProductCategoryService
    {
        #region Properties

        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        #endregion Properties

        #region Constructors

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Methods

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryRepository.Add(productCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return _productCategoryRepository.GetAll();
            }
            return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status == true && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
        }

        #endregion Methods
    }

    #endregion Implement
}