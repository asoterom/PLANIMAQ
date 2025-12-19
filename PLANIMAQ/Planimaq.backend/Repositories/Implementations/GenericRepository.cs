using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planimaq.backend.Data;
using Planimaq.backend.Helpers;
using Planimaq.backend.Repositories.Interfaces;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        
        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }
        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Message = "Registro no encontrado"
                };
            }
            
            try
            {
                _entity.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                };

            }
            catch
            {

                return new ActionResponse<T>
                {
                    Message = "No se puede borrar porque tiene registros relacionados."
                };
            }
        }

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Message = "Registro no encontrado"
                };
            }

            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = row
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await _entity.ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        { 
            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }

        }


        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();
            return new ActionResponse<IEnumerable<T>> { 
                WasSuccess = true, 
                Result = await queryable
                .Paginate(pagination)
                .ToListAsync() 
            };
        }
        public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) 
        { 
            var queryable = _entity.AsQueryable(); 
            double count = await queryable.CountAsync(); 
            return new ActionResponse<int> { 
                WasSuccess = true, 
                Result = (int)count 
            }; 
        }




        //private ActionResponse<T> DbUpdateExceptionActionResponse()
        //{
        //    return new ActionResponse<T>
        //    {
        //        Message = "Ya existe el registro."
        //    };

        //}
        private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T>
        {
            Message = "Ya existe el registro."
        };

        private ActionResponse<T> ExceptionActionResponse(Exception exception) => new ActionResponse<T>
        {
            Message = exception.Message
        };



    }
}
