namespace WhoCanHelpMe.Web.Controllers.About.Mappers
{
    #region Using Directives

    using System.Collections.Generic;

    using AutoMapper;
    using Cms.Pages;
    using Contracts;

    using Domain;

    using Framework.Mapper;

    using Shared.Mappers.Contracts;

    using ViewModels;

    #endregion

    public class AboutPageViewModelMapper : BasePageViewModelMapper<AboutPage, IList<NewsItem>, AboutPageViewModel>,
                                            IAboutPageViewModelMapper
    {
        private readonly INewsItemViewModelMapper newsItemViewModelMapper;

        public AboutPageViewModelMapper(
            IPageViewModelBuilder pageViewModelBuilder,
            INewsItemViewModelMapper newsItemViewModelMapper)
            : base(pageViewModelBuilder)
        {
            this.newsItemViewModelMapper = newsItemViewModelMapper;
        }

        protected override void CreateMap()
        {
            Mapper.CreateMap<AboutPage, AboutPageViewModel>();
            Mapper.CreateMap<IList<NewsItem>, AboutPageViewModel>().ConvertUsing(list => this.DoMapping(list));
        }

        private AboutPageViewModel DoMapping(IList<NewsItem> input)
        {
            return new AboutPageViewModel
                {
                    NewsItems = input.MapAllUsing(this.newsItemViewModelMapper)
                };
        }
    }
}