namespace WhoCanHelpMe.Web.Cms.Pages
{
    using N2;
    using N2.Details;
    using N2.Installation;

    [PageDefinition("About Page",
        Description = "An about page template.",
        SortOrder = 440,
        InstallerVisibility = InstallerHint.NeverRootOrStartPage,
        IconUrl = "~/n2/resources/icons/page_word.png")]
    [WithEditableTitle("Title", 5, Focus = true, ContainerName = Tabs.Content)]
    [WithEditableName("Name", 10, ContainerName = Tabs.Content)]
    public class AboutPage : AbstractPage
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