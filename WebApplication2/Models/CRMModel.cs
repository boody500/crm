using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Xml.Linq;
namespace WebApplication2.Models
{
    public class CRMModel
    {
        public void CreateContactExample(IOrganizationService service,User user)
        {
            
            var lateBoundAccount = new Entity("contact")
            {
                ["firstname"] = user.FirstName,
                ["lastname"] = user.LastName,
                //["gendercode"] = 1,
                //["familystatuscode"] = user.MartialStatus,
                ["jobtitle"] = user.JobTitle,

                ["emailaddress1"] = user.Email,
                ["adx_identity_newpassword"] = user.Password,
                ["mobilephone"] = user.MobilePhone,
                ["telephone1"] = user.BusinessPhone,

                ["address1_line1"] = user.Street,
                ["address1_city"] = user.City,
                ["address1_postalcode"] = user.Zip
            };

            var lateBoundAccountId = service.Create(lateBoundAccount);
            Debug.WriteLine("finallly");
            // Delete the accounts
            //service.Delete(Account.EntityLogicalName, earlyBoundAccountId);
            //service.Delete("account", lateBoundAccountId);
        }

        public Boolean QueryExpressionExample(IOrganizationService service,User user)
        {

            // Define the query
            QueryExpression query = new QueryExpression("contact")
            {
                TopCount = 1
            };
            // Add columns to query.ColumnSet
            //query.ColumnSet = new ColumnSet("emailaddress1");
            //query.ColumnSet = new ColumnSet("adx_identity_newpassword");
            query.ColumnSet.AddColumn("firstname");
            query.ColumnSet.AddColumn("lastname");
            query.ColumnSet.AddColumn("jobtitle");

            query.ColumnSet.AddColumn("emailaddress1");
            query.ColumnSet.AddColumn("adx_identity_newpassword");
            query.ColumnSet.AddColumn("mobilephone");
            query.ColumnSet.AddColumn("telephone1");

            query.ColumnSet.AddColumn("address1_line1");
            query.ColumnSet.AddColumn("address1_city");
            query.ColumnSet.AddColumn("address1_postalcode");
            query.ColumnSet.AddColumn("primarycontactid");

           



            // Add condition for records where email equals userEmail
            query.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, user.Email);
            query.Criteria.AddCondition("adx_identity_newpassword", ConditionOperator.Equal, user.Password);


            // Add conditions to query.Criteria

            // Add orders
            //query.AddOrder("name", OrderType.Ascending);

            // Send the request
            EntityCollection results = service.RetrieveMultiple(query);

            if(results.Entities.Count == 0) 
                return false;
            // Show the data
            foreach (Entity record in results.Entities)
            {
                Debug.WriteLine($"Email:{record.GetAttributeValue<string>("emailaddress1")}");
                Debug.WriteLine($"Password:{record.GetAttributeValue<string>("adx_identity_newpassword")}");

                if(user.Email != record.GetAttributeValue<string>("emailaddress1") || user.Password!= record.GetAttributeValue<string>("adx_identity_newpassword"))
                    return false;
                else
                {
                    user.FirstName = record.GetAttributeValue<string>("firstname");
                    user.LastName = record.GetAttributeValue<string>("lastname");
                    user.JobTitle = record.GetAttributeValue<string>("jobtitle");
                    user.MobilePhone = record.GetAttributeValue<string>("mobilephone");
                    user.BusinessPhone = record.GetAttributeValue<string>("telephone1");
                    user.Street = record.GetAttributeValue<string>("address1_line1");
                    user.City = record.GetAttributeValue<string>("address1_city");
                    user.Zip = record.GetAttributeValue<string>("address1_postalcode");
                    user.ID = record.GetAttributeValue<string>("primarycontactid");
                }
            }
            return true;

        }

        public List<Product> RetriveProducts(IOrganizationService service)
        {
            List<Product> products = new List<Product>();

            // Define the query
            QueryExpression query = new QueryExpression("product")
            {
                TopCount = 10
            };
            // Add columns to query.ColumnSet
            //query.ColumnSet = new ColumnSet("emailaddress1");
            //query.ColumnSet = new ColumnSet("adx_identity_newpassword");
            query.ColumnSet.AddColumn("name");
            query.ColumnSet.AddColumn("productnumber");
            query.ColumnSet.AddColumns("productid");
            //query.ColumnSet.AddColumn("jobtitle");

            






            // Add condition for records where email equals userEmail
            //query.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, user.Email);
            //query.Criteria.AddCondition("adx_identity_newpassword", ConditionOperator.Equal, user.Password);


            // Add conditions to query.Criteria

            // Add orders
            //query.AddOrder("name", OrderType.Ascending);

            // Send the request
            EntityCollection results = service.RetrieveMultiple(query);

            // Show the data
            foreach (Entity record in results.Entities)
            {
               

                string name = record.GetAttributeValue<string>("name");
                string id = record.GetAttributeValue<string>("productnumber");
                //var pid = record.Id;
                 
                

                products.Add(new Product { Name = name, Id = id });
              
            }
            return products;
        }

        public void CreateCaseExample(IOrganizationService service, User user,Cases cases)
        {

            var lateBoundAccount = new Entity("incident")
            {
                ["title"] = cases.Title,
                ["primarycontactid"] = user.ID,
                //["gendercode"] = 1,
                //["familystatuscode"] = user.MartialStatus,
                ["productid"] = cases.Pid,  // Lookup to Product entity

                ["description"] = cases.description


            }; 

            var lateBoundAccountId = service.Create(lateBoundAccount);
            Debug.WriteLine("case created");
            // Delete the accounts
            //service.Delete(Account.EntityLogicalName, earlyBoundAccountId);
            //service.Delete("account", lateBoundAccountId);
        }

    }
}
