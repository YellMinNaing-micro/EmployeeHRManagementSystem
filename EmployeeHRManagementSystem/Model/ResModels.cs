using System.Reflection.Metadata.Ecma335;

namespace EmployeeHRManagementSystem.Model
{
    public class ResModels
    {
        public required int StatusCode { get; set; }
        public required bool Success {  get; set; } = false;
        public  dynamic? Data { get; set; }
        public  dynamic? Message {  get; set; }

    }
}
