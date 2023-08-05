using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca_web.Models;
using Biblioteca_web.Models.Reponses;

namespace Biblioteca_web.Servicess
{
    public interface IprestamoServicio
    {
        PrestamoDetailResponse GetCourse(int id);
        PrestamoListReponse GetCourses();
        PrestamoUpdateResponse Update(PrestamoUpdateDto prestamoUpdate);
        PrestamoSaveReponse Save(PrestamoDto prestamoAdd);

    }
}
