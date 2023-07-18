using Biblioteca.Application.Contract;
using Biblioteca.Application.Core;
using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Exceptiones;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Repositories;
using Microsoft.Extensions.Logging;
using Biblioteca.Application.Extentios;

namespace Biblioteca.Application.Service
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IprestamosRepository prestamoRepositorie;
        private readonly ILogger<PrestamoService> logger;

        public PrestamoService(IprestamosRepository prestamoRepositorie, ILogger<PrestamoService> logger)
        {
            this.prestamoRepositorie = prestamoRepositorie;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.prestamoRepositorie.GetPrestamos();
            }
            catch (PrestamoException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                this.logger.LogError($"{result.Message}");

            }
            return result;

        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.prestamoRepositorie.GetPrestamoById(id);
            }
            catch (PrestamoException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "error";
                this.logger.LogError($"{result.Message}", ex.ToString());


            }

            return result;
        }

        public ServiceResult Remove(PrestamoRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.prestamoRepositorie.remove(new Prestamo()
                {
                    IdPrestamo = model.IdPrestamo,
                    IdEstadoPrestamo = model.IdEstadoPrestamo,
                    Deleted = model.Delete,
                    FechaDevolucion = model.ChangeDate

                });

                result.Message = "Departamento eliminado Correctamente";
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "error";
                this.logger.LogError($"{result.Message}", ex.ToString());


            }

            return result;
        }

        public ServiceResult Save(PrestamoAddDto model)
        {
            ServiceResult result = new ServiceResult();
            

            if (string.IsNullOrEmpty(model.Codigo))
            {
                result.Message = "el codigo es requerido";
                result.Success = false;
                return result;
            }

            if (model.Codigo.Length > 10)
            {
                result.Message = "el codigo no cumple con lo que se esperaba";
                result.Success = false;
                return result;
            }

            if (Convert.ToBoolean( model.IdEstadoPrestamo) )
            {
                result.Message = "el estado del prestamo es obligatorio";
                result.Success = false;
                return result;
            }

            try
            {
                var prestamo = model.ConvertDtoAddToEntity();

                this.prestamoRepositorie.Add(prestamo);
                result.Message = "prestamo resgistrado";
            }catch (Exception ex)
            {
                result.Success=false;
                result.Message="error";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(PrestamoUpdateDto model)
        {
            ServiceResult result = new ServiceResult();


            if (string.IsNullOrEmpty(model.Codigo))
            {
                result.Message = "el codigo es requerido";
                result.Success = false;
                return result;
            }

            if (model.Codigo.Length > 10)
            {
                result.Message = "el codigo no cumple con lo que se esperaba";
                result.Success = false;
                return result;
            }

            if (Convert.ToBoolean(model.IdEstadoPrestamo))
            {
                result.Message = "el estado del prestamo es obligatorio";
                result.Success = false;
                return result;
            }

            try
            {
                var prestamo = model.ConvertDtoUpdateToEntity();

                this.prestamoRepositorie.update(prestamo);
                result.Message = "Prestamo actualizado";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "error";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        
    }
}
