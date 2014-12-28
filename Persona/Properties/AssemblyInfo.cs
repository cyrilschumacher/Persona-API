using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyTitle("Persona")]
[assembly: AssemblyDescription("Persona-API is A REST service that returns different information from my resume.")]
[assembly: AssemblyProduct("Persona")]
[assembly: AssemblyCopyright("Copyright (c) 2014 Cyril Schumacher.fr")]

[assembly: Guid("9cde79cb-541c-4f15-b39d-9064df1e1dfe")]

[assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyFileVersion("1.0.0.0")]
