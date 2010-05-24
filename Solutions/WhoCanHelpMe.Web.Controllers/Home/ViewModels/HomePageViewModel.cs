namespace WhoCanHelpMe.Web.Controllers.Home.ViewModels
{
    #region Using Directives

    using System.Collections.Generic;

    using Shared.ViewModels;

    #endregion

    public class HomePageViewModel : PageViewModel
    {
        public HomePageViewModel()
        {
            this.NewsItems = new List<NewsItemViewModel>();
        }

        public string Heading { get; set; }
        
        public string SubHeading { get; set; }

        public string BodyText { get; set; }

        public IList<NewsItemViewModel> NewsItems { get; set; }
    }
}