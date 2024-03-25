using System.Reflection.Metadata.Ecma335;

namespace EmployeeHRManagementSystem.Model
{
    public class ResModels
    {
        public int StatusCode { get; set; }
        public bool Success {  get; set; } = true;
        public required dynamic Data { get; set; }
        public required dynamic Message {  get; set; }

    }
}
