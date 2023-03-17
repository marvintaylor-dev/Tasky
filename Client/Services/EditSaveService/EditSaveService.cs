
namespace Tasky.Client.Services.EditSaveService
{
    public class EditSaveService : IEditSaveService
    {
        public event Action OnClick;

        public void TaskDataUpdated()
        {
            Console.WriteLine("Update Called");
            OnClick?.Invoke();
        }
    }
}
