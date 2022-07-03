using System;

namespace SiGEv.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
		public string Message { get; set; }
		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
