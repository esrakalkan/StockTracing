using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StockTracing.Business.ApiRequestClassses;
using StockTracing.Business.ServicesClasses;
using StockTracing.DataAccess.ApiClasses;
using StockTracing.DataAccess.DataBaseClasses;

namespace StockTracing.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private StockDbContext _dbContext;
        private readonly AppSettings _appSettings;

        public CategoryController(
            StockDbContext dbContext,
            IOptions<AppSettings> appSettings
            )
        {
           this. _dbContext = dbContext;
            this._appSettings = appSettings.Value;
        }
        [HttpGet("categories")]
        public async Task<ApiResponse> GetCategories()  //istekler birbirini beklemeden çalışması için
        {
            try
            {
                var categories = await _dbContext.categories
                    .Where(r => !r.deleted && r.type == 0)
                    .OrderBy(r => r.name)
                    .ToListAsync();

                return ApiResponseErrorType.OK.CreateResponse(categories);
            }
            catch(Exception e)
            {
                return (e.InnerException ?? e).Message.CreateResponse();   //?? or gibi davranıyor
            }

        }

        [HttpPost("categoryList")]
        public async Task<ApiResponse> GEtCategoryList(Pagination request = null)
        {
            try
            {
                request = request ?? new Pagination
                {
                    Page = request.Page,
                    RowsPerPage = request.RowsPerPage
                };

                var categoryList = _dbContext.categories
                    .Join(_dbContext.categories, c => c.Id, sc => sc.parentId, (c, sc) => new { c, sc })
                    .Join(_dbContext.users, nc => nc.sc.editedBy, u => u.Id, (nc, u) => new { nc, u })
                    .Where(r => !r.u.deleted && !r.nc.sc.deleted && !r.nc.c.deleted)
                    .OrderBy(r => r.nc.c.name)
                    .Select(r => new
                    {
                        categoryId = r.nc.c.Id,
                        subCategory = r.nc.c.Id,
                        categoryName = r.nc.c.name,
                        lastUpdate = r.nc.c.lastUpdate,
                        editedBy = r.u.displayName
                    });

                var count = await categoryList.CountAsync();
                var pagination = new PaginationResponse
                {
                    Page = request.Page,
                    pagecount = (int)Math.Ceiling(count * 0.1 / request.RowsPerPage),
                    rowCount = count,
                    RowsPerPage = request.RowsPerPage
                };
                var response = await categoryList
                    .Skip(request.RowsPerPage * (request.Page - 1))
                    .Take(request.RowsPerPage)
                    .ToListAsync();

                return pagination.CreateResponse(response);

            }
            catch (Exception e)
            {
                return (e.InnerException ?? e).Message.CreateResponse();   //?? or gibi davranıyor
            }
        }

        public async Task<ApiResponse> GetSUbCategories()  //istekler birbirini beklemeden çalışması için
        {
            try
            {
                var subCategories = await _dbContext.categories
                    .Where(r => !r.deleted && r.type == 0)
                    .OrderBy(r => r.name)
                    .ToListAsync();

                return ApiResponseErrorType.OK.CreateResponse(subCategories);
            }
            catch (Exception e)
            {
                return (e.InnerException ?? e).Message.CreateResponse();   //?? or gibi davranıyor
            }

        }
        [HttpGet("subCategoryList")]
        public async Task<ApiResponse> GetsubCategoryList(Pagination request = null)
        {
            try
            {
                
                var subCategoryList = await _dbContext.categories
                    .Join(_dbContext.categories, c => c.Id, sc => sc.parentId, (c, sc) => new { c, sc })
                    .Join(_dbContext.users, nc => nc.sc.editedBy, u => u.Id, (nc, u) => new { nc, u })
                    .Where(r => !r.u.deleted && !r.nc.sc.deleted && !r.nc.c.deleted)
                    .OrderBy(r => r.nc.c.name)
                    .Select(r => new
                    {
                        categoryId = r.nc.c.Id,
                        subCategory = r.nc.c.Id,
                        categoryName = r.nc.c.name,
                        lastUpdate = r.nc.c.lastUpdate,
                        editedBy = r.u.displayName
                    }).ToListAsync();

                return ApiResponseErrorType.OK.CreateResponse(subCategoryList);

            }
            catch (Exception e)
            {
                return (e.InnerException ?? e).Message.CreateResponse();   //?? or gibi davranıyor
            }
        }

        public async Task<ApiResponse> GetSubCategories()  //istekler birbirini beklemeden çalışması için
        {
            try
            {
                var subCategories = await _dbContext.categories
                    .Where(r => !r.deleted && r.type == 0)
                    .OrderBy(r => r.name)
                    .ToListAsync();

                return ApiResponseErrorType.OK.CreateResponse(subCategories);
            }
            catch (Exception e)
            {
                return (e.InnerException ?? e).Message.CreateResponse();   //?? or gibi davranıyor
            }

        }

        [HttpPost("saveCategory")]
        public async Task<ApiResponse> SaveCategory(ApiCategoryRequest request)
        {
            try
            {
                return ApiResponseErrorType.OK.CreateResponse();
            }
            catch (Exception e)
            {
                return (e.InnerException ?? e).Message.CreateResponse();
            }
        }

    }
}
