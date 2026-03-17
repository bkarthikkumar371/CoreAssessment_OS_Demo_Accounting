# CoreAssessment_OS_Demo_Accounting
Demo projects demonstrating Blazor and APIs in .NET Core in Accounting Domain

    A demo project for <strong>microservices-based accounting sample system</strong> built using
    Blazor Web Assembly for front-end and .Net 10 APIs for back-end functionalities.
</p>

<hr />

<h4>Features</h4>

<ul>
    <li><b>Customers</b> – Read-only customer listing with name-based filtering</li>
    <li><b>Invoices</b> – View invoices, filter by status, update status and create invoices</li>
    <li><b>Invoices by Customer</b> – All the above invoice functionalities grouped by filterable customers</li>
    <li>⚡ Parallel API Calls used for Invoices by Customer section</li>
</ul>

<hr />

<h4>Architecture Highlights</h4>

<ul>
    <li> Clean Architecture </li>
    <li> InMemory sample data persisted in the Infrastructure Layer</li>
    <li> Client side - Standalone Blazor Web Assembly</li>
    <li> Main API (MVC Controllers)- Primary Server Web API connects Clients to other APIs</li>
    <li> Implements GET, POST and PATCH API calls</li>
    <li> Other APIs (minimal APIs): Customer Service & Invoice Service</li>
    <li> Uses CORS for development environment - except Main API since Aspire was using different ports for client</li>
    
</ul>

<h4>Features Not implemented</h4>

<ul>
    <li> Database & EF </li>
    <li> Authentication & Authorization</li>
    <li> Event-driven architecture </li>
    <li> Unit tests</li>
    <li> Logging </li>
    <li> Exception Handling</li>
    <li> Production setting configurations</li>
    <li> OpenTelemetry </li>
</ul>

<hr/>

<h4>Build Steps</h4>

Clone the respository

Open the solution file in VS or VS Code.

Under Presentation folder, build and run all the projects in it preferrable without debug mode.

<ul>
  <li>AccountingSystemDemo.Api.CustomerService</li>
  <li>AccountingSystemDemo.Api.InvoiceService</li>
  <li>AccountingSystemDemo.Api.MainService</li>
  <li>AccountingSystemDemo.Web.Client</li>
</ul>

These steps open up the Home Page of the Blazor WASM application.

-KARTHIK KUMAR
