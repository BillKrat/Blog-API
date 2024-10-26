using Framework.Shared.Dto;

namespace Framework.Shared.Interfaces
{
    public interface IDalFacade : IDal
    {
        List<DataDto> GetList(EventArgs e);
    }
}
