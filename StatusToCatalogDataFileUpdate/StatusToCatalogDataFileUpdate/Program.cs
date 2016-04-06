using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

namespace StatusToCatalogDataFileUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"status_old.json";

            // Open the file to read from.
            string[] readText = File.ReadAllLines(path);

            var sb = new StringBuilder();

            string[] wrongNames =
            {
                "accname-aam-1.1",
                "appmanifest",
                "compositing-1",
                "css3-images",
                "css3-mediaqueries",
                "css3-multicol",
                "css3-sizing",
                "css3-values",
                "css4-images",
                "css-cascase-3",
                "css-conditional",
                "css-device-adapt",
                "css-exclusions",
                "css-logical-props",
                "css-masking-1",
                "cssom-view",
                "css-position",
                "css-shapes",
                "css-values",
                "css-variables-1",
                "deviceorientation",
                "directory-upload",
                "dom",
                "ecmascript",
                "fetch",
                "fido-2",
                "file-writer-api",
                "filter-effects",
                "filters-2",
                "form-http-extensions",
                "html",
                "html-aapi",
                "mathml3",
                "mediacapture",
                "media-frags",
                "microdata",
                "motion-1",
                "navigatorcores",
                "network-error-logging",
                "p3p",
                "page-visibility-3",
                "pointerevents-2",
                "preload",
                "speech-api",
                "streams",
                "subresourceintegrity",
                "svg",
                "wai-aria",
                "wai-aria-1.1",
                "web-bluetooth",
                "webdatabase",
                "webmessaging",
                "web-nfc",
                "webstorage",
                "woff",
                "woff2"
            };

            string[] rightNames=
            {
                "",
                "",
                "compositing-1",
                "css-images-3",
                "",
                "css-multicol-3",
                "css-sizing-3",
                "",
                "css-image-4",
                "css-cascade-3",
                "css-conditional-3",
                "css-deviceadapt-1",
                "css-exclusions-1",
                "css-logical-props-1",
                "css-masking-1",
                "cssom-view-1",
                "css-position-3",
                "css-shapes-1",
                "",
                "",
                "orientation-event",
                "file-system-api",
                "whatwg-dom",
                "es6",
                "whatwg-fetch",
                "webauthn",
                "file-system",
                "filter-effects-1",
                "",
                "",
                "html51",
                "",
                "",
                "html-media-capture",
                "",
                "",
                "motion-1",
                "navigatorcores",
                "",
                "",
                "page-visibility",
                "pointerevents",
                "",
                "speech-api",
                "",
                "sri",
                "svg2",
                "",
                "",
                "web-bluetooth",
                "webdatabase",
                "webmessaging",
                "web-nfc",
                "webstorage",
                "",
                ""
            };

            foreach (var l in readText)
            {
                var replacement = string.Empty;
                for (var i = 0; i < wrongNames.Length; i++)
                {
                    if (l.Contains("\"spec\": \"" + wrongNames[i] + "\""))
                    {
                        replacement = l.Replace("\"" + wrongNames[i] + "\"", "\"" + rightNames[i] + "\"");
                        break;
                    }
                }
                if (replacement == string.Empty)
                {
                    sb.AppendLine(l);
                }
                else
                {
                    sb.AppendLine(replacement);
                    Console.WriteLine(replacement);
                }

            }

            File.WriteAllText("status.json", sb.ToString());

            Console.WriteLine("Done!");
            Console.ReadKey();

        }
    }
}
