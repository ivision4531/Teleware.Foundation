using Teleware.Foundation.Exceptions;

namespace Playground.Web.Controllers
{
    public class Exp : ClientNoticeableException
    {
        public Exp(string m) : base(m)
        {
        }
    }

    public class Exp2 : HttpClientNoticeableException
    {
        public Exp2(string m, int c) : base(m, c)
        {
        }
    }
}