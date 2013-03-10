using System.Web.Mvc;

namespace RadaCode.Ella.Areas.Factory
{
    public class FactoryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Factory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FactoryArea",
                "Factory/{controller}/{action}/",
                new { controller="AdminGenerator", action = "Default"}
            );
        }
    }
}
