using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Newtonsoft.Json.Linq;
namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/472da9cdba1e43e489767ba66c707e02/services/17157da031bc4d8ca1312cfb8795f44d/execute?api-version=2.0&details=true");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("content-length", "1008");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Host", "ussouthcentral.services.azureml.net");
            request.AddHeader("Postman-Token", "3bb783b8-6bba-4c96-8482-b6f7d5dab746,214f881f-ff8f-4d38-beec-0a51af13f27e");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.13.0");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer hozUeXqDongfwqv5snANUI7z3h9LuvwcvykX6kcVPLFpVSDBHJJEYW7+FbQAONOcDRTyhvAIhpfSZKtCQLWsFw==");
            request.AddParameter("undefined", "{\r\n  \"Inputs\": {\r\n    \"input1\": {\r\n      \"ColumnNames\": [\r\n        \"age\",\r\n        \"workclass\",\r\n        \"fnlwgt\",\r\n        \"education\",\r\n        \"education-num\",\r\n        \"marital-status\",\r\n        \"occupation\",\r\n        \"relationship\",\r\n        \"race\",\r\n        \"sex\",\r\n        \"capital-gain\",\r\n        \"capital-loss\",\r\n        \"hours-per-week\",\r\n        \"native-country\"\r\n      ],\r\n      \"Values\": [\r\n        [\r\n          \"" + TextBox1.Text + "\",\r\n          \"" + TextBox2.Text + "\",\r\n          \"" + TextBox3.Text + "\",\r\n          \"" + TextBox4.Text + "\",\r\n          \"" + TextBox5.Text + "\",\r\n          \"" + TextBox6.Text + "\",\r\n          \"" + TextBox7.Text + "\",\r\n          \"" + TextBox8.Text + "\",\r\n          \"" + TextBox9.Text + "\",\r\n          \"" + TextBox10.Text + "\",\r\n          \"" + TextBox11.Text + "\",\r\n          \"" + TextBox12.Text + "\",\r\n          \"" + TextBox13.Text + "\",\r\n          \"" + TextBox14.Text + "\"\r\n        ],\r\n        [\r\n          \"" + TextBox1.Text + "\",\r\n          \"" + TextBox2.Text + "\",\r\n          \"" + TextBox3.Text + "\",\r\n          \"" + TextBox4.Text + "\",\r\n          \"" + TextBox5.Text + "\",\r\n          \"" + TextBox6.Text + "\",\r\n          \"" + TextBox7.Text + "\",\r\n          \"" + TextBox8.Text + "\",\r\n          \"" + TextBox9.Text + "\",\r\n          \"" + TextBox10.Text + "\",\r\n          \"" + TextBox11.Text + "\",\r\n          \"" + TextBox12.Text + "\",\r\n          \"" + TextBox13.Text + "\",\r\n          \"" + TextBox14.Text + "\"\r\n        ]\r\n      ]\r\n    }\r\n  },\r\n  \"GlobalParameters\": {}\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //lblResults.Text = response.Content.ToString();

            //{"Results":{"output1":{"type":"table","value":{"ColumnNames":["Scored Labels","Scored Probabilities"],"ColumnTypes":["String","Double"],"Values":[[">50K","0.922785222530365"],[">50K","0.922785222530365"]]}}}} 
            //{ "output1": { "type": "table", "value": { "ColumnNames": [ "Scored Labels", "Scored Probabilities" ], "ColumnTypes": [ "String", "Double" ], "Values": [ [ ">50K", "0.922785222530365" ], [ ">50K", "0.922785222530365" ] ] } } } 
            var results = JObject.Parse(response.Content);
            string preiction = results["Results"]["output1"]["value"]["Values"].ToString();

            lblResults.Text = preiction;   
        }
    }
}