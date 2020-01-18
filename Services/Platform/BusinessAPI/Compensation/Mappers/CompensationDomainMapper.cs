using AutoMapper;

namespace Xyz.Web.Business.Compensation.Mappers
{
    public class CompensationDomainMapper
    {
        public static readonly CompensationDomainMapper Instance = new CompensationDomainMapper();

        public IMapper Mapper
        {
            get => throw new System.NotImplementedException();
        }
    }
}