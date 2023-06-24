
using Microsoft.Extensions.Logging;
using Biblioteca.Application.Contract;
using Biblioteca.Application.Core;
using Biblioteca.Application.Dtos.Department;
using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Exceptions;
using Biblioteca.Infrastructure.Interfaces;
using System;

namespace Biblioteca.Application.Service
{

    public class LectorService : ILectorService 
    {
        private readonly ILectorRepository LectorRepository; 
        private readonly ILogger<LectorService> logger; 

        public LectorService(ILectorRepository LectorRepository, 
                                  ILogger<LectorService> logger)
        {
            this.LectorRepository = LectorRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.LectorRepository.GetLector();
            }
            catch (LectorException dex) 
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los lectores"; 
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.LectorRepository.GetLectorById(id); 
            }
            catch (LectorException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los lectores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(LectorRemoveDto model)
        {
            ServiceResult result = new ServiceResult()
            try
            {
                this.LectorRepository.Remove(new Lector)
                {
                    LectorId = model.LectorId,
                    Deleted = model.Deleted, 
                    DeletedDate = model.ChangeDate, 
                    UserDeleted = model.ChangeUser
                });
                result.Message = "Departamento eliminado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el departamento.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }

        public ServiceResult Save(LectorAddDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.Nombre))
            {
                result.Message = "El nombre del lector es requerido."; 
                result.Success = false;
                return result;
            }

            if (model.Nombre.Length > 50)
            {
                result.Message = "El nombre del lector tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (model.codigo.Length > 20)
            {
                result.Message = "El codigo tiene una longitud invalida";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Apellido)
            {
                result.Message = "El apellido del lector es requerido.";
                result.Success = false;
                return result;
            }

            if (model.Apellido.Length > 50)
            {
                result.Message = "El apellido del lector tiene la logitud invalida.";
                result.Success = false;
                return result;
            }


            if (string.IsNullOrEmpty(model.Correo))
            {
                result.Message = "El correo del lector es requerido.";
                result.Success = false;
                return result;
            }

            if (model.Correo.Length > 30)
            {
                result.Message = "El correo del lector tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Clave))
            {
                result.Message = "La clave del lector es requerido.";
                result.Success = false;
                return result;
            }

            if (model.Correo.Length > 20)
            {
                result.Message = "La clave del lector tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (!model.FechaCreacion.HasValue)
            {
                result.Message = "La fecha de creacion es requerida";
                result.Success = false;
                return result;
            }



            try
            {
                this.LectorRepository.Add(new Lector()
                {
                    Codigo = model.Codigo,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Correo = model.Correo,
                    Clave = model.Clave,
                    Estado = model.Estado,
                    FechaCreacion = model.FechaCreacion.ChangeDate
                }); ;

                result.Message = "Lector agregado correctamente.";
            }
            catch (DepartmentException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el Lector.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(LectorUpdateDto model)
        {
            ServiceResult result = new ServiceResult();



            this.LectorRepository.Update(new Lector()
            {
                Codigo = model.Codigo,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Correo = model.Correo,
                Clave = model.Clave,
                Estado = model.Estado,
                FechaCreacion = model.FechaCreacion.ChangeDate
            });


            return result;
        }
    }
}