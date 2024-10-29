namespace Shared.DTO
{
    public class ErrorViewModel
    {
        public string fieldName {  get; set; }
        public string message { get; set; }
        public ErrorViewModel(string fieldName, string message)
        {
            this.fieldName = fieldName;
            this.message = message;
        }
    }
}
