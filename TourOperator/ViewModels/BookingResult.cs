using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourOperator.ViewModels
{
    public class BookingResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
