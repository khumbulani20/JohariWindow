using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthSenderOptions
    {
        private readonly string user = "Johari window"; // The name you that will show up in your email

        //obtained from sendgrid
        private readonly string key = "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";
        public string SendGridUser { get { return user; } }
        public string SendGridKey { get { return key; } }
    }
}


