namespace WhoCanHelpMe.Web.Controllers.About.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Home.ViewModels;

    using Shared.ViewModels;

    #endregion

    public class AboutPageViewModel : PageViewModel
    {
        public AboutPageViewModel()
        {
            this.NewsItems = new List<NewsItemViewModel>();
        }

        public string Heading { get; set; }

        public string BodyText { get; set; }

        public IList<NewsItemViewModel> NewsItems { get; set; }
    }
}