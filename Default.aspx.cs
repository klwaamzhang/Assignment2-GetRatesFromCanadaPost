using System;
using System.Net;
using System.Web.UI;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data;

namespace Assignment2_GetRatesFromCanadaPost
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create dynymic table
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] {
                    new DataColumn("Service Type", typeof(string)),
                    new DataColumn("Transit Day",typeof(string)),
                    new DataColumn("Regular Price",typeof(string)),
                });

                // request from Canada post api and store the data to the datatable
                dt = PostAPI(dt);

                StringBuilder sb = new StringBuilder();
                sb.Append("<table cellpadding='3' cellspacing='3' style='border: 1px solid #800000;font-size: 12pt;font-family:Arial; margin-top:50px'>");
                //Add Table Header
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<th style='background-color: #E6E6E6;border: 1px solid #000'>" + column.ColumnName + "</th>");
                }
                sb.Append("</tr>");
                //Add Table Rows
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("<tr>");
                    //Add Table Columns
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td style='width:300px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                DynamicTable.Text = sb.ToString();
            }
        }

            

        public DataTable PostAPI (DataTable dt)
        {
                var username = "c6a5778bd92909a6";
                var password = "ade51e327ebd2d642df926";
                var url = "https://ct.soa-gw.canadapost.ca/rs/ship/price";
                var method = "POST";

                String errorString = "";

                mailingscenario mailingScenario = new mailingscenario();
                mailingScenario.parcelcharacteristics = new mailingscenarioParcelcharacteristics();
                mailingScenario.destination = new mailingscenarioDestination();
                mailingscenarioDestinationDomestic destDom = new mailingscenarioDestinationDomestic();
                mailingScenario.destination.domestic = destDom;

                mailingScenario.quotetype = "counter";
                mailingScenario.parcelcharacteristics.weight = 1;
                mailingScenario.originpostalcode = "K2B8J6";
                destDom.postalcode = "J0E1X0";

                try
                {
                    StringBuilder mailingScenarioSb = new StringBuilder();
                    XmlWriter mailingScenarioXml = XmlWriter.Create(mailingScenarioSb);
                    mailingScenarioXml.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
                    XmlSerializer serializerRequest = new XmlSerializer(typeof(mailingscenario));
                    serializerRequest.Serialize(mailingScenarioXml, mailingScenario);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = method;

                    string auth = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
                    request.Headers = new WebHeaderCollection();
                    request.Headers.Add("Authorization", auth);

                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] buffer = encoding.GetBytes(mailingScenarioSb.ToString());
                    request.ContentLength = buffer.Length;
                    request.Headers.Add("Accept-Language", "en-CA");
                    request.Accept = "application/vnd.cpc.ship.rate-v4+xml";
                    request.ContentType = "application/vnd.cpc.ship.rate-v4+xml";
                    Stream PostData = request.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    XmlSerializer serializer = new XmlSerializer(typeof(pricequotes));
                    TextReader reader = new StreamReader(response.GetResponseStream());
                    pricequotes priceQuotes = (pricequotes)serializer.Deserialize(reader);

                    foreach (var priceQuote in priceQuotes.pricequote)
                    {
                        dt.Rows.Add(priceQuote.servicename, priceQuote.servicestandard.expectedtransittime, "$" + priceQuote.pricedetails.due);
                    }

                }
                catch (WebException webEx)
                {
                    HttpWebResponse response = (HttpWebResponse)webEx.Response;

                    if (response != null)
                    {
                        errorString += "HTTP  Response Status: " + webEx.Message + "\r\n";

                        try
                        {
                            errorString += "ERROR!!!";
                        }
                        catch (Exception ex)
                        {
                            errorString += "ERROR: " + ex.Message;
                        }
                    }
                    else
                    {
                        errorString += "ERROR: " + webEx.Message;
                    }

                }
                catch (Exception ex)
                {
                    // Misc Exception
                    errorString += "ERROR: " + ex.Message;
                }

                errStr.Text = errorString;

            return dt;
            }
        
    }
}