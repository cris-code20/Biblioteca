
namespace Biblioteca.Application.Core
{
    public interface  IBaseService<TDtoAdd, TDtoMod, TDtoRem>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Save(TModelMod model);
        ServiceResult Update(TModelMod model);
        ServiceResult Remove(TModelMod model);
    }
}
