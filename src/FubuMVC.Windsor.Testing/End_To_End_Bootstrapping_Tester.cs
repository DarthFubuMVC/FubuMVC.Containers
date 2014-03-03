using FubuMVC.Core;
using FubuMVC.Katana;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Windsor.Testing
{
    [TestFixture]
    public class Windsor
    {
        [Test, Ignore("Does not work until the authorization changes in FubuMVC.Core 2.0")]
        public void can_run_a_request_end_to_end()
        {
            using (var server = FubuApplication.DefaultPolicies().Windsor().RunEmbedded())
            {
                server.Endpoints.Get<WindsorEndpoint>(x => x.get_windsor())
                    .ReadAsText()
                    .ShouldEqual("I'm running with Windsor");
            }
        }
    }

    public class WindsorEndpoint
    {
        public string get_windsor()
        {
            return "I'm running with Windsor";
        }
    }
}