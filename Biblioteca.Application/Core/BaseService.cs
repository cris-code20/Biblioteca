

namespace Biblioteca.Application.Core
{
    public abstract class BaseService<TMoelAdd, TModelMod, TModelRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetById(int id);
        public abstract ServiceResult Save(TModelMod model);
        public abstract ServiceResult Update(TModelMod model);
        public abstract ServiceResult Remove(TModelMod model);

    }
}
