using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public int ResultCode;
        public List<string> Messages { get; set; }
        public T ReturnObject { get; set; }
        public string ErrorCode { get; set; }

        public Result()
        {
            Success = false;
            Messages = new List<string>();
        }

        public Result(Result result)
        {
            this.Success = result.Success;
            this.Messages = result.Messages;
        }

    }

    public class Result
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }

        public Result()
        {
            Success = false;
            Messages = new List<string>();
        }

        public Result(bool initial)
        {
            Success = initial;
            Messages = new List<string>();
        }
    }

    public class TResult<T>
    {
        public bool Success { get { return Messages.Count == 0; } }
        public List<string> Messages { get; set; }
        public T ReturnObject { get; set; }

        public TResult()
        {
            Messages = new List<string>();
        }
    }
}
