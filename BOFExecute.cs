using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.IO.Compression;
using System.Linq;
using BOFNET;

namespace SharpWechatDecrypt
{
	internal class Execute : BeaconObject
	{
		public Execute(BeaconApi api) : base(api) { }
        public override void Go(string[] args)
        {
            try
            {
                var memStream = new MemoryStream();
                var memStreamWriter = new StreamWriter(memStream);
                memStreamWriter.AutoFlush = true;
                Console.SetOut(memStreamWriter);
                Console.SetError(memStreamWriter);
                // Run main program passing original arguments
                Program.Main(args);

                // Write MemoryStream to Beacon output
                BeaconConsole.WriteLine(Encoding.ASCII.GetString(memStream.ToArray()));

            }
            catch (Exception ex)
            {
                BeaconConsole.WriteLine(String.Format("\nBOF.NET Exception: {0}.", ex));
            }
        }
    }
}
