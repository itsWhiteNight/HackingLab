﻿using Colorful;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;

namespace winPEAS
{
    //////////////////////////////
    ///////// WMI CLASS //////////
    //////////////////////////////
    public class Wmi
    {
        public static List<string> GetInstalledKBs()
        {
            List<string> KbList = new List<string>();

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\cimv2", "SELECT HotFixID FROM Win32_QuickFixEngineering"))
                {
                    ManagementObjectCollection collection = searcher.Get();

                    foreach (ManagementObject kb in collection)
                    {
                        KbList.Add(kb["HotFixID"].ToString().Remove(0, 2));
                    }
                }
            }
            catch (ManagementException e)
            {
                System.Console.Error.WriteLine(" [!] {0}", e.Message);
            }

            return KbList;
        }

        public static string GetBuildNumber()
        {
            string buildNum = string.Empty;

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\cimv2", "SELECT BuildNumber FROM Win32_OperatingSystem"))
                {
                    ManagementObjectCollection collection = searcher.Get();

                    foreach (ManagementObject num in collection)
                    {
                        buildNum = (string)num["BuildNumber"];
                    }
                }
            }
            catch (ManagementException e)
            {
                System.Console.Error.WriteLine(" [!] {0}", e.Message);
            }

            return buildNum;
        }
    }

    //////////////////////////////
    ///// VULNERABILITY CLASS ////
    //////////////////////////////
    public class Vulnerability
    {
        public string Identification { get; }
        public string[] KnownExploits { get; }
        public bool Vulnerable { get; private set; }

        public Vulnerability(string id, string[] exploits)
        {
            Identification = id;
            KnownExploits = exploits;
        }

        public void SetAsVulnerable()
            => Vulnerable = true;
    }


    //////////////////////////////
    // VULNERABILITYCOLLECTION CLASS 
    //////////////////////////////
    public class VulnerabilityCollection
    {
        private readonly List<Vulnerability> _vulnerabilities;

        public void SetAsVulnerable(string id)
            => _vulnerabilities.First(e => e.Identification == id).SetAsVulnerable();

        public VulnerabilityCollection()
        {
            _vulnerabilities = Populate();
        }

        public void ShowResults()
        {
            foreach (Vulnerability vuln in _vulnerabilities.Where(i => i.Vulnerable))
            {
                Beaprint.BadPrint(String.Format("       [!] {0} : VULNERABLE", vuln.Identification));

                foreach (string exploit in vuln.KnownExploits)
                    Beaprint.BadPrint(String.Format("        [>] {0}", exploit));

                System.Console.WriteLine();
            }

            if (_vulnerabilities.Any(e => e.Vulnerable))
            {
                if (Program.using_ansi)
                {
                    System.Console.WriteLine(Beaprint.GRAY + "    Finished. Found " + Beaprint.ansi_color_bad + _vulnerabilities.Count(i => i.Vulnerable) + Beaprint.GRAY + " potential vulnerabilities." + Beaprint.NOCOLOR);
                }
                else
                {
                    string iniPrint = "    Finished. Found {0} potential vulnerabilities.";
                    Formatter[] colors = new Formatter[]
                    {
                        new Formatter(_vulnerabilities.Count(i => i.Vulnerable), Beaprint.color_bad),
                    };
                    Colorful.Console.WriteLineFormatted(iniPrint, Color.Gray, colors);
                }
            }
            else
                Beaprint.GrayPrint("      Finished. Found 0 vulnerabilities.\r\n");
        }

        private List<Vulnerability> Populate()
        {
            return new List<Vulnerability>()
            {
                new Vulnerability(
                    id: "CVE-2019-0836",
                    exploits: new string[] { "https://exploit-db.com/exploits/46718", "https://decoder.cloud/2019/04/29/combinig-luafv-postluafvpostreadwrite-race-condition-pe-with-diaghub-collector-exploit-from-standard-user-to-system/" }
                    ),

                new Vulnerability(
                    id: "CVE-2019-0841",
                    exploits: new string[] { "https://github.com/rogue-kdc/CVE-2019-0841", "https://rastamouse.me/tags/cve-2019-0841/" }
                    ),

                new Vulnerability(
                    id: "CVE-2019-1064",
                    exploits: new string[] { "https://www.rythmstick.net/posts/cve-2019-1064/" }
                    ),

                new Vulnerability(
                    id: "CVE-2019-1130",
                    exploits: new string[] { "https://github.com/S3cur3Th1sSh1t/SharpByeBear" }
                    ),

                new Vulnerability(
                    id: "CVE-2019-1253",
                    exploits: new string[] { "https://github.com/padovah4ck/CVE-2019-1253" }
                    ),

                new Vulnerability(
                    id: "CVE-2019-1315",
                    exploits: new string[] { "https://offsec.almond.consulting/windows-error-reporting-arbitrary-file-move-eop.html" }
                    )
            };

        }
    }


    //////////////////////////////
    //////// CVEs CLASSES ////////
    //////////////////////////////
    internal static class CVE_2019_0836
    {
        private const string name = "CVE-2019-0836";

        public static void Check(VulnerabilityCollection vulnerabilities, string BuildNumber, List<string> installedKBs)
        {
            List<string> Supersedence = new List<string>();

            switch (BuildNumber)
            {
                case "10240":

                    Supersedence.AddRange(new string[] {
                        "4493475", "4498375", "4499154", "4505051", "4503291",
                        "4507458", "4512497", "4517276", "4516070", "4522009",
                        "4520011", "4524153"
                    });

                    break;

                case "10586":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "14393":

                    Supersedence.AddRange(new string[] {
                        "4493470", "4493473", "4499418", "4494440", "4499177",
                        "4505052", "4503267", "4503294", "4509475", "4507459",
                        "4507460", "4512495", "4512517", "4516044", "4516061",
                        "4522010", "4519998", "4524152"
                    });

                    break;

                case "15063":

                    Supersedence.AddRange(new string[] {
                        "4493474", "4493436", "4499162", "4499181", "4502112",
                        "4505055", "4503279", "4503289", "4509476", "4507450",
                        "4507467", "4512474", "4512507", "4516059", "4516068",
                        "4522011", "4520010", "4524151"
                    });

                    break;

                case "16299":

                    Supersedence.AddRange(new string[] {
                        "4493441", "4493440", "4499147", "4499179", "4505062",
                        "4503281", "4503284", "4509477", "4507455", "4507465",
                        "4512494", "4512516", "4516066", "4516071", "4522012",
                        "4520004", "4524150"
                    });

                    break;

                case "17134":

                    Supersedence.AddRange(new string[] {
                        "4493464", "4493437", "4499167", "4499183", "4505064",
                        "4503286", "4503288", "4509478", "4507435", "4507466",
                        "4512501", "4512509", "4516045", "4516058", "4522014",
                        "4520008", "4524149"
                    });

                    break;

                case "17763":

                    Supersedence.AddRange(new string[] {
                        "4493509", "4495667", "4494441", "4497934", "4501835",
                        "4505056", "4501371", "4503327", "4509479", "4505658",
                        "4507469", "4511553", "4512534", "4512578", "4516077",
                        "4522015", "4519338", "4524148"
                    });

                    break;

                default:
                    return;
            }

            IEnumerable<string> x = Supersedence.Intersect(installedKBs);

            if (!x.Any())
                vulnerabilities.SetAsVulnerable(name);
        }
    }


    internal static class CVE_2019_0841
    {
        private const string name = "CVE-2019-0841";

        public static void Check(VulnerabilityCollection vulnerabilities, string BuildNumber, List<string> installedKBs)
        {
            List<string> Supersedence = new List<string>();

            switch (BuildNumber)
            {
                case "10240":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "10586":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "14393":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "15063":

                    Supersedence.AddRange(new string[] {
                        "4493474", "4493436", "4499162", "4499181", "4502112",
                        "4505055", "4503279", "4503289", "4509476", "4507450",
                        "4507467", "4512474", "4512507", "4516059", "4516068",
                        "4522011", "4520010", "4524151"
                    });

                    break;

                case "16299":

                    Supersedence.AddRange(new string[] {
                        "4493441", "4493440", "4499147", "4499179", "4505062",
                        "4503281", "4503284", "4509477", "4507455", "4507465",
                        "4512494", "4512516", "4516066", "4516071", "4522012",
                        "4520004", "4524150"
                    });

                    break;

                case "17134":

                    Supersedence.AddRange(new string[] {
                        "4493464", "4493437", "4499167", "4499183", "4505064",
                        "4503286", "4503288", "4509478", "4507435", "4507466",
                        "4512501", "4512509", "4516045", "4516058", "4522014",
                        "4520008", "4524149"
                    });

                    break;

                case "17763":

                    Supersedence.AddRange(new string[] {
                        "4493509", "4495667", "4494441", "4497934", "4501835",
                        "4505056", "4501371", "4503327", "4509479", "4505658",
                        "4507469", "4511553", "4512534", "4512578", "4516077",
                        "4522015", "4519338", "4524148"
                    });

                    break;

                default:
                    return;
            }

            IEnumerable<string> x = Supersedence.Intersect(installedKBs);

            if (!x.Any())
                vulnerabilities.SetAsVulnerable(name);
        }
    }

    internal static class CVE_2019_1064
    {
        private const string name = "CVE-2019-1064";

        public static void Check(VulnerabilityCollection vulnerabilities, string BuildNumber, List<string> installedKBs)
        {
            List<string> Supersedence = new List<string>();

            switch (BuildNumber)
            {
                case "10240":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "10586":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "14393":

                    Supersedence.AddRange(new string[] {
                        "4503267", "4503294", "4509475", "4507459", "4507460",
                        "4512495", "4512517", "4516044", "4516061", "4522010",
                        "4519998", "4524152"
                    });

                    break;

                case "15063":

                    Supersedence.AddRange(new string[] {
                        "4503279", "4503289", "4509476", "4507450", "4507467",
                        "4512474", "4512507", "4516059", "4516068", "4522011",
                        "4520010", "4524151"
                    });

                    break;

                case "16299":

                    Supersedence.AddRange(new string[] {
                        "4503284", "4503281", "4509477", "4507455", "4507465",
                        "4512494", "4512516", "4516066", "4516071", "4522012",
                        "4520004", "4524150"
                    });

                    break;

                case "17134":

                    Supersedence.AddRange(new string[] {
                        "4503286", "4503288", "4509478", "4507435", "4507466",
                        "4512501", "4512509", "4516045", "4516058", "4522014",
                        "4520008", "4524149"
                    });

                    break;

                case "17763":

                    Supersedence.AddRange(new string[] {
                        "4503327", "4501371", "4509479", "4505658", "4507469",
                        "4511553", "4512534", "4512578", "4516077", "4522015",
                        "4519338", "4524148"
                    });

                    break;

                case "18362":

                    Supersedence.AddRange(new string[] {
                        "4503293", "4501375", "4505903", "4507453", "4512508",
                        "4512941", "4515384", "4517211", "4522016", "4517389",
                        "4524147"
                    });

                    break;

                default:
                    return;
            }

            IEnumerable<string> x = Supersedence.Intersect(installedKBs);

            if (!x.Any())
                vulnerabilities.SetAsVulnerable(name);
        }
    }

    internal static class CVE_2019_1130
    {
        private const string name = "CVE-2019-1130";

        public static void Check(VulnerabilityCollection vulnerabilities, string BuildNumber, List<string> installedKBs)
        {
            List<string> Supersedence = new List<string>();

            switch (BuildNumber)
            {
                case "10240":

                    Supersedence.AddRange(new string[] {
                        "4507458", "4512497", "4517276", "4516070", "4522009",
                        "4520011", "4524153"
                    });

                    break;

                case "10586":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "14393":

                    Supersedence.AddRange(new string[] {
                        "4507460", "4507459", "4512495", "4512517", "4516044",
                        "4516061", "4522010", "4519998", "4524152"
                    });

                    break;

                case "15063":

                    Supersedence.AddRange(new string[] {
                        "4507450", "4507467", "4512474", "4512507", "4516059",
                        "4516068", "4522011", "4520010", "4524151"
                    });

                    break;

                case "16299":

                    Supersedence.AddRange(new string[] {
                        "4507455", "4507465", "4512494", "4512516", "4516066",
                        "4516071", "4522012", "4520004", "4524150"
                    });

                    break;

                case "17134":

                    Supersedence.AddRange(new string[] {
                        "4507435", "4507466", "4512501", "4512509", "4516045",
                        "4516058", "4522014", "4520008", "4524149"
                    });

                    break;

                case "17763":

                    Supersedence.AddRange(new string[] {
                        "4507469", "4505658", "4511553", "4512534", "4512578",
                        "4516077", "4522015", "4519338", "4524148"
                    });

                    break;

                case "18362":

                    Supersedence.AddRange(new string[] {
                        "4507453", "4505903", "4512508", "4512941", "4515384",
                        "4517211", "4522016", "4517389", "4524147"
                    });

                    break;

                default:
                    return;
            }

            IEnumerable<string> x = Supersedence.Intersect(installedKBs);

            if (!x.Any())
                vulnerabilities.SetAsVulnerable(name);
        }
    }

    internal static class CVE_2019_1253
    {
        private const string name = "CVE-2019-1253";

        public static void Check(VulnerabilityCollection vulnerabilities, string BuildNumber, List<string> installedKBs)
        {
            List<string> Supersedence = new List<string>();

            switch (BuildNumber)
            {
                case "10240":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "10586":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "14393":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "15063":

                    Supersedence.AddRange(new string[] {
                        "4516068", "4516059", "4522011", "4520010", "4524151"
                    });

                    break;

                case "16299":

                    Supersedence.AddRange(new string[] {
                        "4516066", "4516071", "4522012", "4520004", "4524150"
                    });

                    break;

                case "17134":

                    Supersedence.AddRange(new string[] {
                        "4516058", "4516045", "4522014", "4520008", "4524149"
                    });

                    break;

                case "17763":

                    Supersedence.AddRange(new string[] {
                        "4512578", "4516077", "4522015", "4519338", "4524148"
                    });

                    break;

                case "18362":

                    Supersedence.AddRange(new string[] {
                        "4515384", "4517211", "4522016", "4517389", "4524147"
                    });

                    break;

                default:
                    return;
            }

            IEnumerable<string> x = Supersedence.Intersect(installedKBs);

            if (!x.Any())
                vulnerabilities.SetAsVulnerable(name);
        }
    }


    internal static class CVE_2019_1315
    {
        private const string name = "CVE-2019-1315";

        public static void Check(VulnerabilityCollection vulnerabilities, string BuildNumber, List<string> installedKBs)
        {
            List<string> Supersedence = new List<string>();

            switch (BuildNumber)
            {
                case "10240":

                    Supersedence.AddRange(new string[] {
                        "4520011"
                    });

                    break;

                case "10586":

                    Supersedence.AddRange(new string[] {
                        //
                    });

                    break;

                case "14393":

                    Supersedence.AddRange(new string[] {
                        "4519998"
                    });

                    break;

                case "15063":

                    Supersedence.AddRange(new string[] {
                        "4520010"
                    });

                    break;

                case "16299":

                    Supersedence.AddRange(new string[] {
                        "4520004"
                    });

                    break;

                case "17134":

                    Supersedence.AddRange(new string[] {
                        "4520008"
                    });

                    break;

                case "17763":

                    Supersedence.AddRange(new string[] {
                        "4519338"
                    });

                    break;

                case "18362":

                    Supersedence.AddRange(new string[] {
                        "4517389"
                    });

                    break;

                default:
                    return;
            }

            IEnumerable<string> x = Supersedence.Intersect(installedKBs);

            if (!x.Any())
                vulnerabilities.SetAsVulnerable(name);
        }
    }


    //////////////////////////////
    ////// MAIN WATSON CLASS /////
    //////////////////////////////
    class Watson
    {
        public static void FindVulns()
        {
            if (Program.using_ansi)
            {
                System.Console.WriteLine(Beaprint.YELLOW + "  [?] " + Beaprint.LBLUE + "Windows vulns search powered by" + Beaprint.LRED + "Watson" + Beaprint.LBLUE + "(https://github.com/rasta-mouse/Watson)" + Beaprint.NOCOLOR);
            }
            else
            {
                string iniPrint = "  {0} Windows vulns search powered by {1} (https://github.com/rasta-mouse/Watson)";
                Formatter[] colors = new Formatter[]
                {
                 new Formatter("[?]", Color.Yellow),
                 new Formatter("Watson", Color.OrangeRed),
                };
                Colorful.Console.WriteLineFormatted(iniPrint, Color.MediumPurple, colors);
            }

            List<string> supportedVersions = new List<string>()
            {
                "10240", //1507
                "10586", //1511
                "14393", //1607 & 2K16
                "15063", //1703
                "16299", //1709
                "17134", //1803
                "17763", //1809 & 2K19
                "18362" //1903
                //"18363", //1909
            };

            // Get OS Build number
            string buildNumber = Wmi.GetBuildNumber();
            if (!string.IsNullOrEmpty(buildNumber))
            {
                string iniPrint = "    {0}: {1}";
                Formatter[] colors = new Formatter[]
                {
                 new Formatter("OS Build Number", Beaprint.color_key),
                 new Formatter(buildNumber, Beaprint.color_default),
                };
                Colorful.Console.WriteLineFormatted(iniPrint, Beaprint.color_key, colors);
            }
            else
                return;

            if (!supportedVersions.Contains(buildNumber))
            {
                Colorful.Console.WriteLine("   Windows version not supported\r\n", Beaprint.color_good);
                return;
            }

            // List of KBs installed
            List<string> installedKBs = Wmi.GetInstalledKBs();

            // List of Vulnerabilities
            VulnerabilityCollection vulnerabiltiies = new VulnerabilityCollection();

            // Check each one
            CVE_2019_0836.Check(vulnerabiltiies, buildNumber, installedKBs);
            CVE_2019_0841.Check(vulnerabiltiies, buildNumber, installedKBs);
            CVE_2019_1064.Check(vulnerabiltiies, buildNumber, installedKBs);
            CVE_2019_1130.Check(vulnerabiltiies, buildNumber, installedKBs);
            CVE_2019_1253.Check(vulnerabiltiies, buildNumber, installedKBs);
            CVE_2019_1315.Check(vulnerabiltiies, buildNumber, installedKBs);

            // Print the results
            vulnerabiltiies.ShowResults();

        }
    }
}
