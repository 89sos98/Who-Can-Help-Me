SET IDENTITY_INSERT n2Item ON

INSERT INTO [dbo].[n2Item] ([ID], [Type], [Created], [Published], [Updated], [Expires], [Name], [ZoneName], [Title], [SortOrder], [Visible], [SavedBy], [State], [AncestralTrail], [VersionIndex], [VersionOfID], [ParentID]) 
VALUES	(1, N'SiteRoot', '20100118 15:48:59.000', '20100118 15:48:59.000', '20100118 15:48:59.000', NULL, N'root', NULL, N'Who Can Help Me?', 0, 1, N'admin', 1, N'/', 0, NULL, NULL)
,		(2, N'HomePage', '20100118 15:48:59.000', '20100118 15:48:59.000', '20100127 10:03:56.000', NULL, N'home', NULL, N'Home', 0, 1, N'admin', 16, N'/1/', 1, NULL, 1)
,		(3, N'AboutPage', '20100118 15:48:59.000', '20100118 15:48:59.000', '20100127 10:03:56.000', NULL, N'about', NULL, N'About', 0, 1, N'admin', 16, N'/1/2/', 1, NULL, 2)

SET IDENTITY_INSERT n2Item OFF


SET IDENTITY_INSERT n2Detail ON

INSERT INTO [dbo].[n2Detail] (ID, Type, ItemID, DetailCollectionID, Name, BoolValue, IntValue, LinkValue, DoubleValue, DateTimeValue, StringValue, Value)
VALUES						 (1, 'String', 2, NULL, 'Heading', NULL, NULL, NULL, NULL, NULL, 'What''s all this then?', NULL)
,							 (2, 'String', 2, NULL, 'SubHeading' ,NULL, NULL, NULL, NULL, NULL, 'Show off your ninja skills!', NULL)
,							 (3, 'String', 2, NULL, 'BodyText', NULL, NULL, NULL, NULL, NULL, '<p>This site is to help find people within the community who have the skills you need.</p>  <p>Keep your list of skills and expertise up to date by clicking the "You!" link on the menu.</p>', NULL)
,							 (4, 'String', 3, NULL, 'Heading', NULL, NULL, NULL, NULL, NULL, 'What is going on here?', NULL)
,							 (5, 'String', 3, NULL, 'BodyText', NULL, NULL, NULL, NULL, NULL, '<p>Who Can Help Me? allows you to create a profile of your skills, knowledge and experience so that other people within the community can seek your advice.</p> 
<h2>Who Can Help Me is Open Source</h2>
<p>Who Can Help Me? is a technology demo, using the following Open Source Frameworks & Tools:</p> 
<ul class="about_list"> 
	<li><a href="http://sharparchitecture.net/">Sharp Architecture</a></li>  
	<li><a href="http://www.asp.net/mvc/">ASP.NET MVC</a></li> 
	<li><a href="http://www.codeplex.com/MVCContrib/">ASP.NET MVC Contrib</a></li> 
	<li><a href="http://nhforge.org/">NHibernate</a> </li> 
	<li><a href="http://fluentnhibernate.org/">Fluent NHibernate</a></li> 
	<li><a href="http://www.castleproject.org/container/index.html">Castle Windsor</a></li> 
	<li><a href="http://automapper.codeplex.com/">AutoMapper</a> </li> 
	<li><a href="http://dotnetopenauth.net/">DotNetOpenAuth</a></li> 
	<li><a href="http://code.google.com/p/elmah/">ELMAH</a></li> 
	<li><a href="http://dotlesscss.com/">Less CSS for .NET</a></li> 
	<li><a href="http://github.com/machine/machine.specifications/">Machine.Specifications (MSpec) BDD Framework</a></li> 
	<li><a href="http://www.codeplex.com/MEF/">MEF</a></li> 
	<li><a href="http://www.postsharp.org/">PostSharp</a></li> 
	<li><a href="http://www.ayende.com/projects/rhino-mocks.aspx">RhinoMocks</a></li> 
	<li><a href="http://sparkviewengine.com/">Spark View Engine</a></li> 
	<li><a href="http://tweetsharp.com/">TweetSharp</a></li> 
	<li><a href="http://xval.codeplex.com/">xVal Validation Framework</a></li> 
</ul> 
<p>The source for Who Can Help Me? is available on Codeplex: <a href="http://whocanhelpme.codeplex.com">http://whocanhelpme.codeplex.com</a></p> 
<h2>The Development Team</h2> 
<p>Who Can Help Me? was developed by:</p> 
<ul class="about_list"> 
	<li><a href="http://howard.vanrooijen.co.uk/blog">Howard van Rooijen</a> - <a href="http://twitter.com/HowardvRooijen">@HowardvRooijen</a></li> 
	<li><a href="http://jonathangeorge.co.uk/">Jonathan George</a> - <a href="http://twitter.com/jon_george1">@jon_george1</a></li> 
	<li><a href="http://jamesbroo.me/">James Broome</a> - <a href="http://twitter.com/broomej">@broomej</a></li> 
</ul> 
<p>If you want to tweet about Who Can Help Me? please use the hashtag #wchm.</p>', NULL)

SET IDENTITY_INSERT n2Detail OFF


