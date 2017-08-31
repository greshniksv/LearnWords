using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWords.Models
{
    public class JsonResponse
    {
        private const string Success = "Success";
        private const string Error = "Error";

        public string Status { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }

        public JsonResponse(bool success): this(success, string.Empty)
        {
        }

        public JsonResponse(bool success, string description)
        {
            if (success)
            {
                Status = Success;
                Code = 0;
                Description = description;
            }
            else
            {
                Status = Error;
                Code = 1;
                Description = description;
            }
        }
    }
}