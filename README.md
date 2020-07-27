[![Codacy Badge](https://api.codacy.com/project/badge/Grade/cbf25798498b45ae87d5730315a51ab6)](https://www.codacy.com/manual/nitinsapru01/PowerBI?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=saprunitin/PowerBI&amp;utm_campaign=Badge_Grade)

# PowerBI Service Worker 
Provides a .NET based solution to interact with PowerBI REST APIs for helping developers monitor, manage &amp; administer their PowerBI reports.

<b>PowerBI Worker:</b>
<p>It provides a solution in terms of a .NET console application which has the capability of interacting with the PowerBI REST APIs using AAD
authentication mechanism.</p>

The overall flow of this application is:
<ul>
  <li><b>Authenticate:</b> This application authenticates user on behalf of an AAD application which has to be register in the tenant in which the PowerBI service also belongs to.</li>
  <li><b>Invoke PowerBI Service:</b> PowerBI service is nothing but a set of RESTFul APIs which are exposed by the PowerBI team @ Microsoft for providing developer support to resources which are lying in the PowerBI eco-system. The developers can easily monitor, manage & administer the reports, dashboards, datasets & workspaces which are in PowerBI using these services. <a href="https://docs.microsoft.com/en-us/rest/api/power-bi/">MSDN Documenation of PowerBI REST API's</a></li>
  <li><b>Model JSON data into objects:</b> The return type from all of the API endpoints provided by PowerBI service is of JSON type, which then needs to be converted into a standard object oriented model for further processing.</li>
</ul>

<p>Documentation in progress.....</p>
