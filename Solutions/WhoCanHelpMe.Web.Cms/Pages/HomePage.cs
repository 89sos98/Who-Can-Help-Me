namespace WhoCanHelpMe.Web.Cms.Pages
{
    #region Using Directives

    using N2;
    using N2.Details;
    using N2.Installation;
    using N2.Integrity;
    using WhoCanHelpMe.Web.Cms;

    #endregion

    /// <summary>
    /// The home page definition.
    /// </summary>
    [PageDefinition("Home Page",
        Description = "A home page template.",
        SortOrder = 440,
        InstallerVisibility = InstallerHint.PreferredRootPage | InstallerHint.PreferredStartPage,
        IconUrl = "~/n2/resources/icons/page_world.png")]
    [WithEditableTitle("Title", 5, Focus = true, ContainerName = Tabs.Content)]
    [RestrictParents(typeof(SiteRoot))]
    public class HomePage : AbstractPage
    {
        /// <summary>
        /// Gets or sets Heading.
        /// </summary>
        [EditableTextBox("Heading", 20, ContainerName = Tabs.Content, HelpText = "Set the main heading for the page.")]
        public string Heading
        {
            get { return (string)GetDetail("Heading"); }
            set { SetDetail("Heading", value); }
        }

        /// <summary>
        /// Gets or sets Heading.
        /// </summary>
        [EditableTextBox("SubHeading", 20, ContainerName = Tabs.Content, HelpText = "Set the sub heading for the page.")]
        public string SubHeading
        {
            get { return (string)GetDetail("SubHeading"); }
            set { SetDetail("SubHeading", value); }
        }

        /// <summary>
        /// Gets or sets BodyText.
        /// </summary>
        [EditableFreeTextArea("Body Text", 100, ContainerName = Tabs.Content, HelpText = "Set the body text for the page")]
        public string BodyText
        {
            get { return (string)GetDetail("BodyText"); }
            set { SetDetail("BodyText", value); }
        }
    }
}