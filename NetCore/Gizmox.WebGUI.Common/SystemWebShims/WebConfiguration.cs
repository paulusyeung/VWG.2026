using System;
using System.Collections.Generic;
using System.Web.SessionState;

namespace System.Web.Configuration
{
    public class SessionStateSection
    {
        public SessionStateMode Mode { get; set; } = SessionStateMode.InProc;
    }

    public class CustomError
    {
        public string StatusCode { get; set; } = string.Empty;
        public string Redirect { get; set; } = string.Empty;
    }

    public sealed class CustomErrorCollection : List<CustomError>
    {
        public CustomError? this[string statusCode]
        {
            get
            {
                foreach (CustomError item in this)
                {
                    if (string.Equals(item.StatusCode, statusCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
                return null;
            }
        }
    }

    public class CustomErrorsSection
    {
        public string DefaultRedirect { get; set; } = string.Empty;
        public CustomErrorCollection Errors { get; } = new CustomErrorCollection();
    }
}
