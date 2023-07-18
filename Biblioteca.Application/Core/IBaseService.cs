
namespace Biblioteca.Application.Core
{
    public interface  IBaseService<TDtoAdd, TDtoMod, TDtoRem>
    {
        ServiceResult Get();
        ServiceResult GetById(int id);
        ServiceResult Save(TDtoAdd model);
        public abstract ServiceResult Update(TDtoMod model);
        ServiceResult Remove(TDtoRem model);
    }
}
