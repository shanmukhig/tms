/*============================================================
** 
** Class:  SchemaGen
**
** <OWNER>Shanmukhi Goli</OWNER> 
**
** Purpose: 
** 
===========================================================*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TMS.Entities;
using TMS.Entities.Enum;

namespace TMS.ServiceAPI.Tests
{
  [TestClass]
  public class SchemaGen
  {
    [TestMethod]
    public void MyTestMethod3()
    {
      User user =
        Builder<User>.CreateNew()
          .With(user1 => user1.Name = "Shamukhi Goli")
          .With(user1 => user1.UserName = "shanmukhig")
          .With(user1 => user1.Password = "Hashedvalue!!!")
          .Build();
      string serializeObject = JsonConvert.SerializeObject(user);
    }

    [TestMethod]
    public void TestMethod2()
    {
      IList<Lead> leads = Builder<Lead>.CreateListOfSize(100).All().Do(lead =>
      {
        //lead.LeadSource = LeadSource.DirectCall;
        //lead.LastName = "George";
        lead.AssignedTo = "5330108da798151680dfc1e1";
        lead.BestTimeToContact = new List<DateTime>
        {
          DateTime.Today,
          DateTime.Today.AddDays(1),
          DateTime.Today.AddDays(-1)
        };
        //lead.City = "Washington";
        //lead.ClientStatus = ClientStatus.NeedTimeToDecide;
        lead.CommunicationDetails = new List<CommunicationDetail>
        {
          new CommunicationDetail
          {
            CommunicationType = CommunicationType.Email,
            Uri = "test@test.com"
          },
          new CommunicationDetail
          {
            CommunicationType = CommunicationType.Facebook,
            Uri = "@test"
          }
        };
        //lead.Country = "India";
        lead.Courses = new List<CourseRequested>
        {
          new CourseRequested
          {
            AmountQuoted = 1,
            CourseId = "53300b2ca79815168020b551",
            ServiceRequired = ServiceRequired.Training
          }
        };
        //lead.DemoDateTime = DateTime.Today;
        lead.Description = "Enquiring for a course";
        //lead.ExpectedDateOfJoin = DateTime.Today;
        //lead.FirstName = "Williams";
        //lead.LeadType = LeadType.Individual;
        //lead.PreferredCommunicationType = CommunicationType.Email;
        lead.ReferredBy = "5330108da798151680dfc1e1";
        //lead.Salutation = Salutation.Dr;
        //lead.Status = Status.Active;
      }).Build();

      //IList<Lead> leads = Builder<Lead>.CreateListOfSize(1).All().Do(lead =>
      //{
      //  lead.AssignedTo = 
      //}).Build();

      //for (int i = 0; i < 10; i++)
      //{
      //IList<Lead> leads = Builder<Lead>.CreateListOfSize(10).All().Do(l => l.Courses = new List<string> {"1", "2"}).Build();
      string serializeObject = JsonConvert.SerializeObject(leads);
      //Console.WriteLine(serializeObject);
      //}
    }


    [TestMethod]
    public void TestMethod1()
    {

      IList<Course> courses = Builder<Course>.CreateListOfSize(1).All().Do(c =>
      {
        c.Description = "mongoDB Training";
        c.DurationInDays = 180;
        c.CourseTopics = new List<CourseTopic>
        {
          new CourseTopic
          {
            Duration = "10hrs",
            Progress = CourseDetailStatus.NotStarted,
            IsTagged = false
          },
        };
        c.Name = "mongoDB Traning";
        c.Price = 120;
        c.Status = Status.Active;
      }).Build();

      //IList<Course> courses =
      //  Builder<Course>.CreateListOfSize(1).All().Do
      //    (c =>
      //    {
      //      c.Description = ".NET Fundamentals";
      //      c.DurationInDays = 180;
      //      c.CourseTopics = new List<CourseTopic>
      //      {
      //        new CourseTopic
      //        {
      //          Duration = "10hrs",
      //          IsTagged = false,
      //          Progress = CourseDetailStatus.NotStarted,
      //          Title = "What is .NET?"
      //        },
      //        new CourseTopic
      //        {
      //          Duration = "10hrs",
      //          IsTagged = false,
      //          Progress = CourseDetailStatus.NotStarted,
      //          Title = "What is CLR?"
      //        }
      //      };
      //      c.Name = ".NET Fundamentals";
      //      c.Price = 120;
      //      c.Status = Status.Active;
      //    }).Build();
      string serializeObject = JsonConvert.SerializeObject(courses.Single());
    }

    [TestMethod]
    public void MyTestMethod()
    {
      CreateObject();
    }

    public void CreateObject()
    {
      const string URL = "http://localhost/TMS/api/CountryAPI";

      #region data

      List<string> countries = new List<string>
      {
        "{'Code':'AF', 'Name':'AFGHANISTAN'}",
        "{'Code':'AL', 'Name':'ALBANIA'}",
        "{'Code':'DZ', 'Name':'ALGERIA'}",
        "{'Code':'AS', 'Name':'AMERICAN SAMOA'}",
        "{'Code':'AD', 'Name':'ANDORRA'}",
        "{'Code':'AO', 'Name':'ANGOLA'}",
        "{'Code':'AI', 'Name':'ANGUILLA'}",
        "{'Code':'AQ', 'Name':'ANTARCTICA'}",
        "{'Code':'AG', 'Name':'ANTIGUA AND BARBUDA'}",
        "{'Code':'AR', 'Name':'ARGENTINA'}",
        "{'Code':'AM', 'Name':'ARMENIA'}",
        "{'Code':'AW', 'Name':'ARUBA'}",
        "{'Code':'AU', 'Name':'AUSTRALIA'}",
        "{'Code':'AT', 'Name':'AUSTRIA'}",
        "{'Code':'AZ', 'Name':'AZERBAIJAN'}",
        "{'Code':'BS', 'Name':'BAHAMAS'}",
        "{'Code':'BH', 'Name':'BAHRAIN'}",
        "{'Code':'BD', 'Name':'BANGLADESH'}",
        "{'Code':'BB', 'Name':'BARBADOS'}",
        "{'Code':'BY', 'Name':'BELARUS'}",
        "{'Code':'BE', 'Name':'BELGIUM'}",
        "{'Code':'BZ', 'Name':'BELIZE'}",
        "{'Code':'BJ', 'Name':'BENIN'}",
        "{'Code':'BM', 'Name':'BERMUDA'}",
        "{'Code':'BT', 'Name':'BHUTAN'}",
        "{'Code':'BO', 'Name':'BOLIVIA'}",
        "{'Code':'BA', 'Name':'BOSNIA AND HERZEGOWINA'}",
        "{'Code':'BW', 'Name':'BOTSWANA'}",
        "{'Code':'BV', 'Name':'BOUVET ISLAND'}",
        "{'Code':'BR', 'Name':'BRAZIL'}",
        "{'Code':'IO', 'Name':'BRITISH INDIAN OCEAN TERRITORY'}",
        "{'Code':'BN', 'Name':'BRUNEI DARUSSALAM'}",
        "{'Code':'BG', 'Name':'BULGARIA'}",
        "{'Code':'BF', 'Name':'BURKINA FASO'}",
        "{'Code':'BI', 'Name':'BURUNDI'}",
        "{'Code':'KH', 'Name':'CAMBODIA'}",
        "{'Code':'CM', 'Name':'CAMEROON'}",
        "{'Code':'CA', 'Name':'CANADA'}",
        "{'Code':'CV', 'Name':'CAPE VERDE'}",
        "{'Code':'KY', 'Name':'CAYMAN ISLANDS'}",
        "{'Code':'CF', 'Name':'CENTRAL AFRICAN REPUBLIC'}",
        "{'Code':'TD', 'Name':'CHAD'}",
        "{'Code':'CL', 'Name':'CHILE'}",
        "{'Code':'CN', 'Name':'CHINA'}",
        "{'Code':'CX', 'Name':'CHRISTMAS ISLAND'}",
        "{'Code':'CC', 'Name':'COCOS (KEELING) ISLANDS'}",
        "{'Code':'CO', 'Name':'COLOMBIA'}",
        "{'Code':'KM', 'Name':'COMOROS'}",
        "{'Code':'CG', 'Name':'CONGO'}",
        "{'Code':'CD', 'Name':'CONGO, THE DRC'}",
        "{'Code':'CK', 'Name':'COOK ISLANDS'}",
        "{'Code':'CR', 'Name':'COSTA RICA'}",
        "{'Code':'CI', 'Name':'COTE D'IVOIRE'}",
        "{'Code':'HR', 'Name':'CROATIA (local name: Hrvatska)'}",
        "{'Code':'CU', 'Name':'CUBA'}",
        "{'Code':'CY', 'Name':'CYPRUS'}",
        "{'Code':'CZ', 'Name':'CZECH REPUBLIC'}",
        "{'Code':'DK', 'Name':'DENMARK'}",
        "{'Code':'DJ', 'Name':'DJIBOUTI'}",
        "{'Code':'DM', 'Name':'DOMINICA'}",
        "{'Code':'DO', 'Name':'DOMINICAN REPUBLIC'}",
        "{'Code':'TP', 'Name':'EAST TIMOR'}",
        "{'Code':'EC', 'Name':'ECUADOR'}",
        "{'Code':'EG', 'Name':'EGYPT'}",
        "{'Code':'SV', 'Name':'EL SALVADOR'}",
        "{'Code':'GQ', 'Name':'EQUATORIAL GUINEA'}",
        "{'Code':'ER', 'Name':'ERITREA'}",
        "{'Code':'EE', 'Name':'ESTONIA'}",
        "{'Code':'ET', 'Name':'ETHIOPIA'}",
        "{'Code':'FK', 'Name':'FALKLAND ISLANDS (MALVINAS)'}",
        "{'Code':'FO', 'Name':'FAROE ISLANDS'}",
        "{'Code':'FJ', 'Name':'FIJI'}",
        "{'Code':'FI', 'Name':'FINLAND'}",
        "{'Code':'FR', 'Name':'FRANCE'}",
        "{'Code':'FX', 'Name':'FRANCE, METROPOLITAN'}",
        "{'Code':'GF', 'Name':'FRENCH GUIANA'}",
        "{'Code':'PF', 'Name':'FRENCH POLYNESIA'}",
        "{'Code':'TF', 'Name':'FRENCH SOUTHERN TERRITORIES'}",
        "{'Code':'GA', 'Name':'GABON'}",
        "{'Code':'GM', 'Name':'GAMBIA'}",
        "{'Code':'GE', 'Name':'GEORGIA'}",
        "{'Code':'DE', 'Name':'GERMANY'}",
        "{'Code':'GH', 'Name':'GHANA'}",
        "{'Code':'GI', 'Name':'GIBRALTAR'}",
        "{'Code':'GR', 'Name':'GREECE'}",
        "{'Code':'GL', 'Name':'GREENLAND'}",
        "{'Code':'GD', 'Name':'GRENADA'}",
        "{'Code':'GP', 'Name':'GUADELOUPE'}",
        "{'Code':'GU', 'Name':'GUAM'}",
        "{'Code':'GT', 'Name':'GUATEMALA'}",
        "{'Code':'GN', 'Name':'GUINEA'}",
        "{'Code':'GW', 'Name':'GUINEA-BISSAU'}",
        "{'Code':'GY', 'Name':'GUYANA'}",
        "{'Code':'HT', 'Name':'HAITI'}",
        "{'Code':'HM', 'Name':'HEARD AND MC DONALD ISLANDS'}",
        "{'Code':'VA', 'Name':'HOLY SEE (VATICAN CITY STATE)'}",
        "{'Code':'HN', 'Name':'HONDURAS'}",
        "{'Code':'HK', 'Name':'HONG KONG'}",
        "{'Code':'HU', 'Name':'HUNGARY'}",
        "{'Code':'IS', 'Name':'ICELAND'}",
        "{'Code':'IN', 'Name':'INDIA'}",
        "{'Code':'ID', 'Name':'INDONESIA'}",
        "{'Code':'IR', 'Name':'IRAN (ISLAMIC REPUBLIC OF)'}",
        "{'Code':'IQ', 'Name':'IRAQ'}",
        "{'Code':'IE', 'Name':'IRELAND'}",
        "{'Code':'IL', 'Name':'ISRAEL'}",
        "{'Code':'IT', 'Name':'ITALY'}",
        "{'Code':'JM', 'Name':'JAMAICA'}",
        "{'Code':'JP', 'Name':'JAPAN'}",
        "{'Code':'JO', 'Name':'JORDAN'}",
        "{'Code':'KZ', 'Name':'KAZAKHSTAN'}",
        "{'Code':'KE', 'Name':'KENYA'}",
        "{'Code':'KI', 'Name':'KIRIBATI'}",
        "{'Code':'KP', 'Name':'KOREA, D.P.R.O.'}",
        "{'Code':'KR', 'Name':'KOREA, REPUBLIC OF'}",
        "{'Code':'KW', 'Name':'KUWAIT'}",
        "{'Code':'KG', 'Name':'KYRGYZSTAN'}",
        "{'Code':'LA', 'Name':'LAOS'}",
        "{'Code':'LV', 'Name':'LATVIA'}",
        "{'Code':'LB', 'Name':'LEBANON'}",
        "{'Code':'LS', 'Name':'LESOTHO'}",
        "{'Code':'LR', 'Name':'LIBERIA'}",
        "{'Code':'LY', 'Name':'LIBYAN ARAB JAMAHIRIYA'}",
        "{'Code':'LI', 'Name':'LIECHTENSTEIN'}",
        "{'Code':'LT', 'Name':'LITHUANIA'}",
        "{'Code':'LU', 'Name':'LUXEMBOURG'}",
        "{'Code':'MO', 'Name':'MACAU'}",
        "{'Code':'MK', 'Name':'MACEDONIA'}",
        "{'Code':'MG', 'Name':'MADAGASCAR'}",
        "{'Code':'MW', 'Name':'MALAWI'}",
        "{'Code':'MY', 'Name':'MALAYSIA'}",
        "{'Code':'MV', 'Name':'MALDIVES'}",
        "{'Code':'ML', 'Name':'MALI'}",
        "{'Code':'MT', 'Name':'MALTA'}",
        "{'Code':'MH', 'Name':'MARSHALL ISLANDS'}",
        "{'Code':'MQ', 'Name':'MARTINIQUE'}",
        "{'Code':'MR', 'Name':'MAURITANIA'}",
        "{'Code':'MU', 'Name':'MAURITIUS'}",
        "{'Code':'YT', 'Name':'MAYOTTE'}",
        "{'Code':'MX', 'Name':'MEXICO'}",
        "{'Code':'FM', 'Name':'MICRONESIA, FEDERATED STATES OF'}",
        "{'Code':'MD', 'Name':'MOLDOVA, REPUBLIC OF'}",
        "{'Code':'MC', 'Name':'MONACO'}",
        "{'Code':'MN', 'Name':'MONGOLIA'}",
        "{'Code':'ME', 'Name':'MONTENEGRO'}",
        "{'Code':'MS', 'Name':'MONTSERRAT'}",
        "{'Code':'MA', 'Name':'MOROCCO'}",
        "{'Code':'MZ', 'Name':'MOZAMBIQUE'}",
        "{'Code':'MM', 'Name':'MYANMAR (Burma)'}",
        "{'Code':'NA', 'Name':'NAMIBIA'}",
        "{'Code':'NR', 'Name':'NAURU'}",
        "{'Code':'NP', 'Name':'NEPAL'}",
        "{'Code':'NL', 'Name':'NETHERLANDS'}",
        "{'Code':'AN', 'Name':'NETHERLANDS ANTILLES'}",
        "{'Code':'NC', 'Name':'NEW CALEDONIA'}",
        "{'Code':'NZ', 'Name':'NEW ZEALAND'}",
        "{'Code':'NI', 'Name':'NICARAGUA'}",
        "{'Code':'NE', 'Name':'NIGER'}",
        "{'Code':'NG', 'Name':'NIGERIA'}",
        "{'Code':'NU', 'Name':'NIUE'}",
        "{'Code':'NF', 'Name':'NORFOLK ISLAND'}",
        "{'Code':'MP', 'Name':'NORTHERN MARIANA ISLANDS'}",
        "{'Code':'NO', 'Name':'NORWAY'}",
        "{'Code':'OM', 'Name':'OMAN'}",
        "{'Code':'PK', 'Name':'PAKISTAN'}",
        "{'Code':'PW', 'Name':'PALAU'}",
        "{'Code':'PA', 'Name':'PANAMA'}",
        "{'Code':'PG', 'Name':'PAPUA NEW GUINEA'}",
        "{'Code':'PY', 'Name':'PARAGUAY'}",
        "{'Code':'PE', 'Name':'PERU'}",
        "{'Code':'PH', 'Name':'PHILIPPINES'}",
        "{'Code':'PN', 'Name':'PITCAIRN'}",
        "{'Code':'PL', 'Name':'POLAND'}",
        "{'Code':'PT', 'Name':'PORTUGAL'}",
        "{'Code':'PR', 'Name':'PUERTO RICO'}",
        "{'Code':'QA', 'Name':'QATAR'}",
        "{'Code':'RE', 'Name':'REUNION'}",
        "{'Code':'RO', 'Name':'ROMANIA'}",
        "{'Code':'RU', 'Name':'RUSSIAN FEDERATION'}",
        "{'Code':'RW', 'Name':'RWANDA'}",
        "{'Code':'KN', 'Name':'SAINT KITTS AND NEVIS'}",
        "{'Code':'LC', 'Name':'SAINT LUCIA'}",
        "{'Code':'VC', 'Name':'SAINT VINCENT AND THE GRENADINES'}",
        "{'Code':'WS', 'Name':'SAMOA'}",
        "{'Code':'SM', 'Name':'SAN MARINO'}",
        "{'Code':'ST', 'Name':'SAO TOME AND PRINCIPE'}",
        "{'Code':'SA', 'Name':'SAUDI ARABIA'}",
        "{'Code':'SN', 'Name':'SENEGAL'}",
        "{'Code':'RS', 'Name':'SERBIA'}",
        "{'Code':'SC', 'Name':'SEYCHELLES'}",
        "{'Code':'SL', 'Name':'SIERRA LEONE'}",
        "{'Code':'SG', 'Name':'SINGAPORE'}",
        "{'Code':'SK', 'Name':'SLOVAKIA (Slovak Republic)'}",
        "{'Code':'SI', 'Name':'SLOVENIA'}",
        "{'Code':'SB', 'Name':'SOLOMON ISLANDS'}",
        "{'Code':'SO', 'Name':'SOMALIA'}",
        "{'Code':'ZA', 'Name':'SOUTH AFRICA'}",
        "{'Code':'SS', 'Name':'SOUTH SUDAN'}",
        "{'Code':'GS', 'Name':'SOUTH GEORGIA AND SOUTH S.S.'}",
        "{'Code':'ES', 'Name':'SPAIN'}",
        "{'Code':'LK', 'Name':'SRI LANKA'}",
        "{'Code':'SH', 'Name':'ST. HELENA'}",
        "{'Code':'PM', 'Name':'ST. PIERRE AND MIQUELON'}",
        "{'Code':'SD', 'Name':'SUDAN'}",
        "{'Code':'SR', 'Name':'SURINAME'}",
        "{'Code':'SJ', 'Name':'SVALBARD AND JAN MAYEN ISLANDS'}",
        "{'Code':'SZ', 'Name':'SWAZILAND'}",
        "{'Code':'SE', 'Name':'SWEDEN'}",
        "{'Code':'CH', 'Name':'SWITZERLAND'}",
        "{'Code':'SY', 'Name':'SYRIAN ARAB REPUBLIC'}",
        "{'Code':'TW', 'Name':'TAIWAN, PROVINCE OF CHINA'}",
        "{'Code':'TJ', 'Name':'TAJIKISTAN'}",
        "{'Code':'TZ', 'Name':'TANZANIA, UNITED REPUBLIC OF'}",
        "{'Code':'TH', 'Name':'THAILAND'}",
        "{'Code':'TG', 'Name':'TOGO'}",
        "{'Code':'TK', 'Name':'TOKELAU'}",
        "{'Code':'TO', 'Name':'TONGA'}",
        "{'Code':'TT', 'Name':'TRINIDAD AND TOBAGO'}",
        "{'Code':'TN', 'Name':'TUNISIA'}",
        "{'Code':'TR', 'Name':'TURKEY'}",
        "{'Code':'TM', 'Name':'TURKMENISTAN'}",
        "{'Code':'TC', 'Name':'TURKS AND CAICOS ISLANDS'}",
        "{'Code':'TV', 'Name':'TUVALU'}",
        "{'Code':'UG', 'Name':'UGANDA'}",
        "{'Code':'UA', 'Name':'UKRAINE'}",
        "{'Code':'AE', 'Name':'UNITED ARAB EMIRATES'}",
        "{'Code':'GB', 'Name':'UNITED KINGDOM'}",
        "{'Code':'US', 'Name':'UNITED STATES'}",
        "{'Code':'UM', 'Name':'U.S. MINOR ISLANDS'}",
        "{'Code':'UY', 'Name':'URUGUAY'}",
        "{'Code':'UZ', 'Name':'UZBEKISTAN'}",
        "{'Code':'VU', 'Name':'VANUATU'}",
        "{'Code':'VE', 'Name':'VENEZUELA'}",
        "{'Code':'VN', 'Name':'VIET NAM'}",
        "{'Code':'VG', 'Name':'VIRGIN ISLANDS (BRITISH)'}",
        "{'Code':'VI', 'Name':'VIRGIN ISLANDS (U.S.)'}",
        "{'Code':'WF', 'Name':'WALLIS AND FUTUNA ISLANDS'}",
        "{'Code':'EH', 'Name':'WESTERN SAHARA'}",
        "{'Code':'YE', 'Name':'YEMEN'}",
        "{'Code':'ZM', 'Name':'ZAMBIA'}",
        "{'Code':'ZW', 'Name':'ZIMBABWE'}"
      };

      #endregion

      foreach (string country in countries)
      {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "POST";
        //string postData = string.Format("param1=something&param2=something_else");
        byte[] data = Encoding.UTF8.GetBytes(country);

        request.ContentType = "application/json";
        request.Accept = "application/json";
        request.ContentLength = data.Length;

        using (Stream requestStream = request.GetRequestStream())
        {
          requestStream.Write(data, 0, data.Length);
        }

        try
        {
          using (WebResponse response = request.GetResponse())
          {
            // Do something with response
          }
        }
        catch (WebException ex)
        {
          // Handle error
        }
      }
    }
  }
}
