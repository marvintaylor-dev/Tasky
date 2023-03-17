namespace Tasky.Client.Services.EditSaveService
{
    public interface IEditSaveService
    {
        event Action OnClick;

        void TaskDataUpdated();
    }
}
