using Biblioteca.Application.Dtos.Lector;
using Biblioteca_web.Models.Responses;

namespace Biblioteca_web.Services
{
	public interface ILectorApiService
	{
		LectorDetailResponse GetLector(int id);
		LectorListResponse GetLectores();
		LectorUpdateResponse Update(LectorUpdateDto lectorUpdateDto);
		LectorSaveResponse Save(LectorAddDto lectorAddDto);

	}
}
