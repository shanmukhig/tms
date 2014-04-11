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
        c.Description = "Algorithms and Data Structures - Part 1";
        c.DurationInDays = 2;
        c.Price = 240;
        c.Title = "Algorithms and Data Structures - Part 1";
        c.CourseTopics = new List<CourseTopic>
        {
          new CourseTopic
          {
            SequenceId = 1,
            DurationInHours = 6,
            Title = "Algorithms and Data Structures 1",
            Description = "Algorithms and Data Structures 1",
            CourseTopics = new List<CourseTopic>
            {
              new CourseTopic
              {
                SequenceId = 1,
                DurationInHours = 2,
                Title = "Introduction",
                Description = "Introduction",
              },
              new CourseTopic
              {
                SequenceId = 2,
                DurationInHours = 25,
                Title = "Node Chains",
                Description = "Node Chains",
              },
              new CourseTopic
              {
                SequenceId = 3,
                DurationInHours = 45,
                Title = "Code: Node Chains",
                Description = "Code: Node Chains",
              },
              new CourseTopic
              {
                SequenceId = 4,
                DurationInHours = 2,
                Title = "Linked List",
                Description = "Linked List",
              },
              new CourseTopic
              {
                SequenceId = 5,
                DurationInHours = 25,
                Title = "Add Items",
                Description = "Add Items",
              },
              new CourseTopic
              {
                SequenceId = 6,
                DurationInHours = 45,
                Title = "Remove Items",
                Description = "Remove Items",
              },
              new CourseTopic
              {
                SequenceId = 7,
                DurationInHours = 2,
                Title = "Enumerate",
                Description = "Enumerate",
              },
              new CourseTopic
              {
                SequenceId = 8,
                DurationInHours = 25,
                Title = "Code: Singly Linked List",
                Description = "Code: Singly Linked List",
              },
              new CourseTopic
              {
                SequenceId = 9,
                DurationInHours = 45,
                Title = "Doubly Linked List",
                Description = "Doubly Linked List",
              },
              new CourseTopic
              {
                SequenceId = 10,
                DurationInHours = 2,
                Title = "Code: Doubly Linked List",
                Description = "Code: Doubly Linked List",
              },
              new CourseTopic
              {
                SequenceId = 11,
                DurationInHours = 25,
                Title = "Modern Implementations",
                Description = "Modern Implementations",
              },
              new CourseTopic
              {
                SequenceId = 12,
                DurationInHours = 45,
                Title = "Summary and References",
                Description = "Summary and References",
              }
            },
          },
          new CourseTopic
          {
            SequenceId = 2,
            DurationInHours = 10,
            Title = "Algorithms and Data Structures: Stack",
            Description = "Algorithms and Data Structures: Stack",
            CourseTopics = new List<CourseTopic>
            {
              new CourseTopic
              {
                SequenceId = 1,
                DurationInHours = 37,
                Title = "Introduction",
                Description = "Introduction",
              },
              new CourseTopic
              {
                SequenceId = 2,
                DurationInHours = 27,
                Title = "Push & Pop",
                Description = "Push & Pop",
              },
              new CourseTopic
              {
                SequenceId = 3,
                DurationInHours = 75,
                Title = "Stack (Linked List)",
                Description = "Stack (Linked List)",
              },
              new CourseTopic
              {
                SequenceId = 4,
                DurationInHours = 56,
                Title = "Code: Stack (Linked List)",
                Description = "Code: Stack (Linked List)",
              },
              new CourseTopic
              {
                SequenceId = 5,
                DurationInHours = 37,
                Title = "Stack (Array)",
                Description = "Stack (Array)",
              },
              new CourseTopic
              {
                SequenceId = 6,
                DurationInHours = 26,
                Title = "Code: Stack (Array)",
                Description = "Code: Stack (Array)",
              },
              new CourseTopic
              {
                SequenceId = 7,
                DurationInHours = 26,
                Title = "Demo: Postfix Calculator",
                Description = "Demo: Postfix Calculator",
              },
              new CourseTopic
              {
                SequenceId = 8,
                DurationInHours = 56,
                Title = "Demo: Undo",
                Description = "Demo: Undo",
              },
              new CourseTopic
              {
                SequenceId = 9,
                DurationInHours = 37,
                Title = "Other Implementations",
                Description = "Other Implementations",
              },
              new CourseTopic
              {
                SequenceId = 10,
                DurationInHours = 26,
                Title = "Summary and Reference",
                Description = "Summary and Reference",
              },
            }
          },
          new CourseTopic
          {
            Title = "Algorithms and Data Structures 1: Queue",
            Description = "Algorithms and Data Structures 1: Queue",
            SequenceId = 3,
            DurationInHours = 15,
            CourseTopics = new List<CourseTopic>
            {
              new CourseTopic
              {
                Title = "Introduction",
                Description = "Introduction",
                DurationInHours = 25,
                SequenceId = 1,
              },
              new CourseTopic
              {
                Title = "Enqueue and Dequeue",
                Description = "Enqueue and Dequeue",
                DurationInHours = 46,
                SequenceId = 2
              },
              new CourseTopic
              {
                Title = "Linked List Implementation",
                Description = "Linked List Implementation",
                DurationInHours = 56,
                SequenceId = 3,
              },
              new CourseTopic
              {
                Title = "Code: Linked List Implementation",
                Description = "Code: Linked List Implementation",
                DurationInHours = 45,
                SequenceId = 4
              },
              new CourseTopic
              {
                Title = "Demo: Queue",
                Description = "Demo: Queue",
                DurationInHours = 36,
                SequenceId = 5,
              },
              new CourseTopic
              {
                Title = "Array Implementation",
                Description = "Array Implementation",
                DurationInHours = 46,
                SequenceId = 6
              },
              new CourseTopic
              {
                Title = "Code: Array Implementation",
                Description = "Code: Array Implementation",
                DurationInHours = 25,
                SequenceId = 7,
              },
              new CourseTopic
              {
                Title = "Priority Queue",
                Description = "Priority Queue",
                DurationInHours = 46,
                SequenceId = 8
              },
              new CourseTopic
              {
                Title = "Code: Priority Queue",
                Description = "Code: Priority Queue",
                DurationInHours = 58,
                SequenceId = 9
              },
              new CourseTopic
              {
                Title = "Demo: Priority Queue",
                Description = "Demo: Priority Queue",
                DurationInHours = 52,
                SequenceId = 10,
              },
              new CourseTopic
              {
                Title = ".NET and C++",
                Description = ".NET and C++",
                DurationInHours = 31,
                SequenceId = 11
              },
              new CourseTopic
              {
                Title = "Summary and Reference",
                Description = "Summary and Reference",
                DurationInHours = 43,
                SequenceId = 12,
              }
            }
          },
          new CourseTopic
          {
            Description = "Algorithms and Data Structures: Binary Trees",
            Title = "Algorithms and Data Structures: Binary Trees",
            DurationInHours = 16,
            SequenceId = 4,
            CourseTopics = new List<CourseTopic>
            {
              new CourseTopic
              {
                Description = "Introduction",
                Title = "Introduction",
                DurationInHours = 41,
                SequenceId = 1
              },
              new CourseTopic
              {
                Description = "What is a Tree?",
                Title = "What is a Tree?",
                DurationInHours = 27,
                SequenceId = 2
              },
              new CourseTopic
              {
                Description = "Binary Trees",
                Title = "Binary Trees",
                DurationInHours = 32,
                SequenceId = 3
              },
              new CourseTopic
              {
                Description = "Adding Data",
                Title = "Adding Data",
                DurationInHours = 36,
                SequenceId = 4
              },
              new CourseTopic
              {
                Description = "Finding Data",
                Title = "Finding Data",
                DurationInHours = 43,
                SequenceId = 5
              },
              new CourseTopic
              {
                Description = "Removing Data",
                Title = "Removing Data",
                DurationInHours = 19,
                SequenceId = 6
              },
              new CourseTopic
              {
                Description = "Traversals",
                Title = "Traversals",
                DurationInHours = 51,
                SequenceId = 7
              },
              new CourseTopic
              {
                Description = "Code: Binary Tree",
                Title = "Code: Binary Tree",
                DurationInHours = 43,
                SequenceId = 8
              },
              new CourseTopic
              {
                Description = "Demo: Sorting Words",
                Title = "Demo: Sorting Words",
                DurationInHours = 29,
                SequenceId = 9
              },
              new CourseTopic
              {
                Description = "Summary",
                Title = "Summary",
                DurationInHours = 36,
                SequenceId = 10
              }
            }
          },
          new CourseTopic
          {
            Description = "Algorithms and Data Structures: Hash Tables",
            Title = "Algorithms and Data Structures: Hash Tables",
            DurationInHours = 16,
            SequenceId = 5,
            CourseTopics = new List<CourseTopic>
            {
              new CourseTopic
              {
                Description = "Introduction",
                Title = "Introduction",
                DurationInHours = 41,
                SequenceId = 1
              },
              new CourseTopic
              {
                Description = "Hash Tables",
                Title = "Hash Tables",
                DurationInHours = 27,
                SequenceId = 2
              },
              new CourseTopic
              {
                Description = "Hashing Overview",
                Title = "Hashing Overview",
                DurationInHours = 32,
                SequenceId = 3
              },
              new CourseTopic
              {
                Description = "String Hashing",
                Title = "String Hashing",
                DurationInHours = 36,
                SequenceId = 4
              },
              new CourseTopic
              {
                Description = "Demo: String Hashing",
                Title = "Demo: String Hashing",
                DurationInHours = 43,
                SequenceId = 5
              },
              new CourseTopic
              {
                Description = "Adding Data",
                Title = "Adding Data",
                DurationInHours = 19,
                SequenceId = 6
              },
              new CourseTopic
              {
                Description = "Handling Collisions",
                Title = "Handling Collisions",
                DurationInHours = 51,
                SequenceId = 7
              },
              new CourseTopic
              {
                Description = "Growing the Table",
                Title = "Growing the Table",
                DurationInHours = 43,
                SequenceId = 8
              },
              new CourseTopic
              {
                Description = "Removing Data",
                Title = "Removing Data",
                DurationInHours = 29,
                SequenceId = 9
              },
              new CourseTopic
              {
                Description = "Finding Data",
                Title = "Finding Data",
                DurationInHours = 36,
                SequenceId = 10
              },

              new CourseTopic
              {
                Description = "Enumerating",
                Title = "Enumerating",
                DurationInHours = 51,
                SequenceId = 11
              },
              new CourseTopic
              {
                Description = "Code: Hash Table",
                Title = "Code: Hash Table",
                DurationInHours = 43,
                SequenceId = 12
              },
              new CourseTopic
              {
                Description = "Demo: Counting Words",
                Title = "Demo: Counting Words",
                DurationInHours = 29,
                SequenceId = 13
              },
              new CourseTopic
              {
                Description = "Summary",
                Title = "Summary",
                DurationInHours = 36,
                SequenceId = 14
              }
            }
          }
        };
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
      //      c.Title = ".NET Fundamentals";
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
        "{'Code':'AF', 'Title':'AFGHANISTAN'}",
        "{'Code':'AL', 'Title':'ALBANIA'}",
        "{'Code':'DZ', 'Title':'ALGERIA'}",
        "{'Code':'AS', 'Title':'AMERICAN SAMOA'}",
        "{'Code':'AD', 'Title':'ANDORRA'}",
        "{'Code':'AO', 'Title':'ANGOLA'}",
        "{'Code':'AI', 'Title':'ANGUILLA'}",
        "{'Code':'AQ', 'Title':'ANTARCTICA'}",
        "{'Code':'AG', 'Title':'ANTIGUA AND BARBUDA'}",
        "{'Code':'AR', 'Title':'ARGENTINA'}",
        "{'Code':'AM', 'Title':'ARMENIA'}",
        "{'Code':'AW', 'Title':'ARUBA'}",
        "{'Code':'AU', 'Title':'AUSTRALIA'}",
        "{'Code':'AT', 'Title':'AUSTRIA'}",
        "{'Code':'AZ', 'Title':'AZERBAIJAN'}",
        "{'Code':'BS', 'Title':'BAHAMAS'}",
        "{'Code':'BH', 'Title':'BAHRAIN'}",
        "{'Code':'BD', 'Title':'BANGLADESH'}",
        "{'Code':'BB', 'Title':'BARBADOS'}",
        "{'Code':'BY', 'Title':'BELARUS'}",
        "{'Code':'BE', 'Title':'BELGIUM'}",
        "{'Code':'BZ', 'Title':'BELIZE'}",
        "{'Code':'BJ', 'Title':'BENIN'}",
        "{'Code':'BM', 'Title':'BERMUDA'}",
        "{'Code':'BT', 'Title':'BHUTAN'}",
        "{'Code':'BO', 'Title':'BOLIVIA'}",
        "{'Code':'BA', 'Title':'BOSNIA AND HERZEGOWINA'}",
        "{'Code':'BW', 'Title':'BOTSWANA'}",
        "{'Code':'BV', 'Title':'BOUVET ISLAND'}",
        "{'Code':'BR', 'Title':'BRAZIL'}",
        "{'Code':'IO', 'Title':'BRITISH INDIAN OCEAN TERRITORY'}",
        "{'Code':'BN', 'Title':'BRUNEI DARUSSALAM'}",
        "{'Code':'BG', 'Title':'BULGARIA'}",
        "{'Code':'BF', 'Title':'BURKINA FASO'}",
        "{'Code':'BI', 'Title':'BURUNDI'}",
        "{'Code':'KH', 'Title':'CAMBODIA'}",
        "{'Code':'CM', 'Title':'CAMEROON'}",
        "{'Code':'CA', 'Title':'CANADA'}",
        "{'Code':'CV', 'Title':'CAPE VERDE'}",
        "{'Code':'KY', 'Title':'CAYMAN ISLANDS'}",
        "{'Code':'CF', 'Title':'CENTRAL AFRICAN REPUBLIC'}",
        "{'Code':'TD', 'Title':'CHAD'}",
        "{'Code':'CL', 'Title':'CHILE'}",
        "{'Code':'CN', 'Title':'CHINA'}",
        "{'Code':'CX', 'Title':'CHRISTMAS ISLAND'}",
        "{'Code':'CC', 'Title':'COCOS (KEELING) ISLANDS'}",
        "{'Code':'CO', 'Title':'COLOMBIA'}",
        "{'Code':'KM', 'Title':'COMOROS'}",
        "{'Code':'CG', 'Title':'CONGO'}",
        "{'Code':'CD', 'Title':'CONGO, THE DRC'}",
        "{'Code':'CK', 'Title':'COOK ISLANDS'}",
        "{'Code':'CR', 'Title':'COSTA RICA'}",
        "{'Code':'CI', 'Title':'COTE D'IVOIRE'}",
        "{'Code':'HR', 'Title':'CROATIA (local name: Hrvatska)'}",
        "{'Code':'CU', 'Title':'CUBA'}",
        "{'Code':'CY', 'Title':'CYPRUS'}",
        "{'Code':'CZ', 'Title':'CZECH REPUBLIC'}",
        "{'Code':'DK', 'Title':'DENMARK'}",
        "{'Code':'DJ', 'Title':'DJIBOUTI'}",
        "{'Code':'DM', 'Title':'DOMINICA'}",
        "{'Code':'DO', 'Title':'DOMINICAN REPUBLIC'}",
        "{'Code':'TP', 'Title':'EAST TIMOR'}",
        "{'Code':'EC', 'Title':'ECUADOR'}",
        "{'Code':'EG', 'Title':'EGYPT'}",
        "{'Code':'SV', 'Title':'EL SALVADOR'}",
        "{'Code':'GQ', 'Title':'EQUATORIAL GUINEA'}",
        "{'Code':'ER', 'Title':'ERITREA'}",
        "{'Code':'EE', 'Title':'ESTONIA'}",
        "{'Code':'ET', 'Title':'ETHIOPIA'}",
        "{'Code':'FK', 'Title':'FALKLAND ISLANDS (MALVINAS)'}",
        "{'Code':'FO', 'Title':'FAROE ISLANDS'}",
        "{'Code':'FJ', 'Title':'FIJI'}",
        "{'Code':'FI', 'Title':'FINLAND'}",
        "{'Code':'FR', 'Title':'FRANCE'}",
        "{'Code':'FX', 'Title':'FRANCE, METROPOLITAN'}",
        "{'Code':'GF', 'Title':'FRENCH GUIANA'}",
        "{'Code':'PF', 'Title':'FRENCH POLYNESIA'}",
        "{'Code':'TF', 'Title':'FRENCH SOUTHERN TERRITORIES'}",
        "{'Code':'GA', 'Title':'GABON'}",
        "{'Code':'GM', 'Title':'GAMBIA'}",
        "{'Code':'GE', 'Title':'GEORGIA'}",
        "{'Code':'DE', 'Title':'GERMANY'}",
        "{'Code':'GH', 'Title':'GHANA'}",
        "{'Code':'GI', 'Title':'GIBRALTAR'}",
        "{'Code':'GR', 'Title':'GREECE'}",
        "{'Code':'GL', 'Title':'GREENLAND'}",
        "{'Code':'GD', 'Title':'GRENADA'}",
        "{'Code':'GP', 'Title':'GUADELOUPE'}",
        "{'Code':'GU', 'Title':'GUAM'}",
        "{'Code':'GT', 'Title':'GUATEMALA'}",
        "{'Code':'GN', 'Title':'GUINEA'}",
        "{'Code':'GW', 'Title':'GUINEA-BISSAU'}",
        "{'Code':'GY', 'Title':'GUYANA'}",
        "{'Code':'HT', 'Title':'HAITI'}",
        "{'Code':'HM', 'Title':'HEARD AND MC DONALD ISLANDS'}",
        "{'Code':'VA', 'Title':'HOLY SEE (VATICAN CITY STATE)'}",
        "{'Code':'HN', 'Title':'HONDURAS'}",
        "{'Code':'HK', 'Title':'HONG KONG'}",
        "{'Code':'HU', 'Title':'HUNGARY'}",
        "{'Code':'IS', 'Title':'ICELAND'}",
        "{'Code':'IN', 'Title':'INDIA'}",
        "{'Code':'ID', 'Title':'INDONESIA'}",
        "{'Code':'IR', 'Title':'IRAN (ISLAMIC REPUBLIC OF)'}",
        "{'Code':'IQ', 'Title':'IRAQ'}",
        "{'Code':'IE', 'Title':'IRELAND'}",
        "{'Code':'IL', 'Title':'ISRAEL'}",
        "{'Code':'IT', 'Title':'ITALY'}",
        "{'Code':'JM', 'Title':'JAMAICA'}",
        "{'Code':'JP', 'Title':'JAPAN'}",
        "{'Code':'JO', 'Title':'JORDAN'}",
        "{'Code':'KZ', 'Title':'KAZAKHSTAN'}",
        "{'Code':'KE', 'Title':'KENYA'}",
        "{'Code':'KI', 'Title':'KIRIBATI'}",
        "{'Code':'KP', 'Title':'KOREA, D.P.R.O.'}",
        "{'Code':'KR', 'Title':'KOREA, REPUBLIC OF'}",
        "{'Code':'KW', 'Title':'KUWAIT'}",
        "{'Code':'KG', 'Title':'KYRGYZSTAN'}",
        "{'Code':'LA', 'Title':'LAOS'}",
        "{'Code':'LV', 'Title':'LATVIA'}",
        "{'Code':'LB', 'Title':'LEBANON'}",
        "{'Code':'LS', 'Title':'LESOTHO'}",
        "{'Code':'LR', 'Title':'LIBERIA'}",
        "{'Code':'LY', 'Title':'LIBYAN ARAB JAMAHIRIYA'}",
        "{'Code':'LI', 'Title':'LIECHTENSTEIN'}",
        "{'Code':'LT', 'Title':'LITHUANIA'}",
        "{'Code':'LU', 'Title':'LUXEMBOURG'}",
        "{'Code':'MO', 'Title':'MACAU'}",
        "{'Code':'MK', 'Title':'MACEDONIA'}",
        "{'Code':'MG', 'Title':'MADAGASCAR'}",
        "{'Code':'MW', 'Title':'MALAWI'}",
        "{'Code':'MY', 'Title':'MALAYSIA'}",
        "{'Code':'MV', 'Title':'MALDIVES'}",
        "{'Code':'ML', 'Title':'MALI'}",
        "{'Code':'MT', 'Title':'MALTA'}",
        "{'Code':'MH', 'Title':'MARSHALL ISLANDS'}",
        "{'Code':'MQ', 'Title':'MARTINIQUE'}",
        "{'Code':'MR', 'Title':'MAURITANIA'}",
        "{'Code':'MU', 'Title':'MAURITIUS'}",
        "{'Code':'YT', 'Title':'MAYOTTE'}",
        "{'Code':'MX', 'Title':'MEXICO'}",
        "{'Code':'FM', 'Title':'MICRONESIA, FEDERATED STATES OF'}",
        "{'Code':'MD', 'Title':'MOLDOVA, REPUBLIC OF'}",
        "{'Code':'MC', 'Title':'MONACO'}",
        "{'Code':'MN', 'Title':'MONGOLIA'}",
        "{'Code':'ME', 'Title':'MONTENEGRO'}",
        "{'Code':'MS', 'Title':'MONTSERRAT'}",
        "{'Code':'MA', 'Title':'MOROCCO'}",
        "{'Code':'MZ', 'Title':'MOZAMBIQUE'}",
        "{'Code':'MM', 'Title':'MYANMAR (Burma)'}",
        "{'Code':'NA', 'Title':'NAMIBIA'}",
        "{'Code':'NR', 'Title':'NAURU'}",
        "{'Code':'NP', 'Title':'NEPAL'}",
        "{'Code':'NL', 'Title':'NETHERLANDS'}",
        "{'Code':'AN', 'Title':'NETHERLANDS ANTILLES'}",
        "{'Code':'NC', 'Title':'NEW CALEDONIA'}",
        "{'Code':'NZ', 'Title':'NEW ZEALAND'}",
        "{'Code':'NI', 'Title':'NICARAGUA'}",
        "{'Code':'NE', 'Title':'NIGER'}",
        "{'Code':'NG', 'Title':'NIGERIA'}",
        "{'Code':'NU', 'Title':'NIUE'}",
        "{'Code':'NF', 'Title':'NORFOLK ISLAND'}",
        "{'Code':'MP', 'Title':'NORTHERN MARIANA ISLANDS'}",
        "{'Code':'NO', 'Title':'NORWAY'}",
        "{'Code':'OM', 'Title':'OMAN'}",
        "{'Code':'PK', 'Title':'PAKISTAN'}",
        "{'Code':'PW', 'Title':'PALAU'}",
        "{'Code':'PA', 'Title':'PANAMA'}",
        "{'Code':'PG', 'Title':'PAPUA NEW GUINEA'}",
        "{'Code':'PY', 'Title':'PARAGUAY'}",
        "{'Code':'PE', 'Title':'PERU'}",
        "{'Code':'PH', 'Title':'PHILIPPINES'}",
        "{'Code':'PN', 'Title':'PITCAIRN'}",
        "{'Code':'PL', 'Title':'POLAND'}",
        "{'Code':'PT', 'Title':'PORTUGAL'}",
        "{'Code':'PR', 'Title':'PUERTO RICO'}",
        "{'Code':'QA', 'Title':'QATAR'}",
        "{'Code':'RE', 'Title':'REUNION'}",
        "{'Code':'RO', 'Title':'ROMANIA'}",
        "{'Code':'RU', 'Title':'RUSSIAN FEDERATION'}",
        "{'Code':'RW', 'Title':'RWANDA'}",
        "{'Code':'KN', 'Title':'SAINT KITTS AND NEVIS'}",
        "{'Code':'LC', 'Title':'SAINT LUCIA'}",
        "{'Code':'VC', 'Title':'SAINT VINCENT AND THE GRENADINES'}",
        "{'Code':'WS', 'Title':'SAMOA'}",
        "{'Code':'SM', 'Title':'SAN MARINO'}",
        "{'Code':'ST', 'Title':'SAO TOME AND PRINCIPE'}",
        "{'Code':'SA', 'Title':'SAUDI ARABIA'}",
        "{'Code':'SN', 'Title':'SENEGAL'}",
        "{'Code':'RS', 'Title':'SERBIA'}",
        "{'Code':'SC', 'Title':'SEYCHELLES'}",
        "{'Code':'SL', 'Title':'SIERRA LEONE'}",
        "{'Code':'SG', 'Title':'SINGAPORE'}",
        "{'Code':'SK', 'Title':'SLOVAKIA (Slovak Republic)'}",
        "{'Code':'SI', 'Title':'SLOVENIA'}",
        "{'Code':'SB', 'Title':'SOLOMON ISLANDS'}",
        "{'Code':'SO', 'Title':'SOMALIA'}",
        "{'Code':'ZA', 'Title':'SOUTH AFRICA'}",
        "{'Code':'SS', 'Title':'SOUTH SUDAN'}",
        "{'Code':'GS', 'Title':'SOUTH GEORGIA AND SOUTH S.S.'}",
        "{'Code':'ES', 'Title':'SPAIN'}",
        "{'Code':'LK', 'Title':'SRI LANKA'}",
        "{'Code':'SH', 'Title':'ST. HELENA'}",
        "{'Code':'PM', 'Title':'ST. PIERRE AND MIQUELON'}",
        "{'Code':'SD', 'Title':'SUDAN'}",
        "{'Code':'SR', 'Title':'SURINAME'}",
        "{'Code':'SJ', 'Title':'SVALBARD AND JAN MAYEN ISLANDS'}",
        "{'Code':'SZ', 'Title':'SWAZILAND'}",
        "{'Code':'SE', 'Title':'SWEDEN'}",
        "{'Code':'CH', 'Title':'SWITZERLAND'}",
        "{'Code':'SY', 'Title':'SYRIAN ARAB REPUBLIC'}",
        "{'Code':'TW', 'Title':'TAIWAN, PROVINCE OF CHINA'}",
        "{'Code':'TJ', 'Title':'TAJIKISTAN'}",
        "{'Code':'TZ', 'Title':'TANZANIA, UNITED REPUBLIC OF'}",
        "{'Code':'TH', 'Title':'THAILAND'}",
        "{'Code':'TG', 'Title':'TOGO'}",
        "{'Code':'TK', 'Title':'TOKELAU'}",
        "{'Code':'TO', 'Title':'TONGA'}",
        "{'Code':'TT', 'Title':'TRINIDAD AND TOBAGO'}",
        "{'Code':'TN', 'Title':'TUNISIA'}",
        "{'Code':'TR', 'Title':'TURKEY'}",
        "{'Code':'TM', 'Title':'TURKMENISTAN'}",
        "{'Code':'TC', 'Title':'TURKS AND CAICOS ISLANDS'}",
        "{'Code':'TV', 'Title':'TUVALU'}",
        "{'Code':'UG', 'Title':'UGANDA'}",
        "{'Code':'UA', 'Title':'UKRAINE'}",
        "{'Code':'AE', 'Title':'UNITED ARAB EMIRATES'}",
        "{'Code':'GB', 'Title':'UNITED KINGDOM'}",
        "{'Code':'US', 'Title':'UNITED STATES'}",
        "{'Code':'UM', 'Title':'U.S. MINOR ISLANDS'}",
        "{'Code':'UY', 'Title':'URUGUAY'}",
        "{'Code':'UZ', 'Title':'UZBEKISTAN'}",
        "{'Code':'VU', 'Title':'VANUATU'}",
        "{'Code':'VE', 'Title':'VENEZUELA'}",
        "{'Code':'VN', 'Title':'VIET NAM'}",
        "{'Code':'VG', 'Title':'VIRGIN ISLANDS (BRITISH)'}",
        "{'Code':'VI', 'Title':'VIRGIN ISLANDS (U.S.)'}",
        "{'Code':'WF', 'Title':'WALLIS AND FUTUNA ISLANDS'}",
        "{'Code':'EH', 'Title':'WESTERN SAHARA'}",
        "{'Code':'YE', 'Title':'YEMEN'}",
        "{'Code':'ZM', 'Title':'ZAMBIA'}",
        "{'Code':'ZW', 'Title':'ZIMBABWE'}"
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
        catch (WebException)
        {
          // Handle error
        }
      }
    }
  }
}
