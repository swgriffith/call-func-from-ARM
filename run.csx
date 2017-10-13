using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string network = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "network", true) == 0)
        .Value;

    string subnetDivisor = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "subnetdivisor", true) == 0)
        .Value;

    string subnetIndex = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "subnetindex", true) == 0)
        .Value;                

     // prepare the template 
     var template = @"{ 
   ""$schema"": ""https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#"", 
   ""contentVersion"": ""1.0.0.0"", ""parameters"": {}, ""variables"": {}, ""resources"": [], 
   ""outputs"": {[OUTPUTS]} 
   }"; 

   var addrPrefixMsg = @"""addrPrefix" + @""": { ""type"": ""string"", ""value"": """ + "100.110.60.0/25" + @""" }";
   //var addrPrefixMsg = "test";

    var result = template.Replace("[OUTPUTS]", addrPrefixMsg);

    

    // return the response 
    return new HttpResponseMessage() { 
     Content = new System.Net.Http.StringContent( 
         result, 
         System.Text.Encoding.UTF8, 
         "application/json" 
     )
    };
}


